using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static AllControl;
public class PlayerControl : MonoBehaviour
{
    protected string m_name;
    protected Rigidbody2D m_rb;
    protected Transform m_transform;
    protected Animator m_anim;
    protected SpriteRenderer m_sprite;
    protected BoxCollider2D m_coll;
    [SerializeField] protected GameObject spawnPoint;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float jmpSpeed;
    [SerializeField] protected LayerMask jumpableGround;
    [SerializeField] protected float MinHeight;
    [SerializeField] protected float airControlMultiplier; // 空中控制系数
    [SerializeField] protected float gravityScale; // 重力缩放
    protected InputActions inputActions;
    protected string currentScene;
    [SerializeField] private AudioSource jumpSound;

    protected virtual void Start()
    {
        m_name = gameObject.name;
        m_rb = gameObject.GetComponent<Rigidbody2D>();
        m_transform = gameObject.GetComponent<Transform>();
        m_anim = gameObject.GetComponent<Animator>();
        m_sprite = gameObject.GetComponent<SpriteRenderer>();
        m_coll = gameObject.GetComponent<BoxCollider2D>();
        spawnPoint = GameObject.Find("SpawnPoints/SpawnPoint" + m_name);
        //jumpableGround = LayerMask.GetMask("Ground");
        moveSpeed = GameManager.Instance.moveSpeed;
        jmpSpeed = GameManager.Instance.jumpSpeed;
        MinHeight = GameManager.Instance.MinHeight;
        
        // 强制使用脚本中定义的默认值
        airControlMultiplier = GameManager.Instance.airControlMultiplier;
        gravityScale = GameManager.Instance.gravityScale;
        m_rb.gravityScale = gravityScale;
        
        // 设置Rigidbody2D的碰撞检测模式为连续检测
        m_rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        
        if (spawnPoint != null)
        {
            transform.position = spawnPoint.transform.position;
        }

        inputActions = new InputActions();
        currentScene = SceneManager.GetActiveScene().name;
        
        if (currentScene == "Level1" || currentScene == "Level2")
        {
            inputActions.SynchControl.Enable();
        }
        else if (currentScene == "Level3")
        {
            inputActions.IndivControl.Enable();
        }
    }

    protected virtual void Update()
    {
        HandleMovement();
    }

    protected void HandleMovement()
    {
        Vector2 moveInput = Vector2.zero;
        bool jumpInput = false;

        if (currentScene == "Level1" || currentScene == "Level2")
        {
            moveInput = inputActions.SynchControl.Move.ReadValue<Vector2>();
            jumpInput = inputActions.SynchControl.Jump.triggered;
        }
        else if (currentScene == "Level3")
        {
            if (m_name == "Player")
            {
                moveInput = inputActions.IndivControl.Move1.ReadValue<Vector2>();
                jumpInput = inputActions.IndivControl.Jump1.triggered;
            }
            else if (m_name == "YaYa")
            {
                moveInput = inputActions.IndivControl.Move2.ReadValue<Vector2>();
                jumpInput = inputActions.IndivControl.Jump2.triggered;
            }
        }

        // 处理跳跃
        if (jumpInput && IsGround())
        {
            m_rb.velocity = Vector2.up * jmpSpeed;
            jumpSound.Play();
        }

        // 处理移动
        if (moveInput.x != 0)
        {
            float moveMultiplier = IsGround() ? 1f : airControlMultiplier;
            m_rb.velocity = new Vector2(moveInput.x * moveSpeed * moveMultiplier, m_rb.velocity.y);
            m_sprite.flipX = moveInput.x < 0;
        }

        // 更新动画参数
        m_anim.SetFloat("horizontal", m_rb.velocity.x);
        m_anim.SetFloat("vertical", m_rb.velocity.y);
        m_anim.SetFloat("speed", m_rb.velocity.magnitude);
    }
    public bool IsGround()
    {
        return Physics2D.BoxCast(m_coll.bounds.center, m_coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
