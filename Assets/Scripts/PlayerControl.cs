using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    // Start is called before the first frame update
    protected virtual void Start()
    {
        m_name = gameObject.name;
        m_rb = gameObject.GetComponent<Rigidbody2D>();
        m_transform = gameObject.GetComponent<Transform>();
        m_anim = gameObject.GetComponent<Animator>();
        m_sprite = gameObject.GetComponent <SpriteRenderer>();
        m_coll = gameObject.GetComponent<BoxCollider2D>();
        spawnPoint = GameObject.Find("SpawnPoint"+m_name); 
        moveSpeed = GameManager.Instance.moveSpeed;
        jmpSpeed = GameManager.Instance.jumpSpeed;
        MinHeight = GameManager.Instance.MinHeight;
        if (spawnPoint != null)
        {
            transform.position = spawnPoint.transform.position;
        }

    }
    protected virtual void Update()
    {
        KeyMove();
    }
    /// <summary>
    /// 键盘ADW控制移动跳跃，以及动画机反馈
    /// </summary>
    protected void KeyMove()
    {
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    Debug.Log("W pressed");
        //}
        if (Input.GetKeyDown(KeyCode.W) && IsGround())
        {
            m_rb.velocity = Vector2.up * jmpSpeed;
            //m_anim.SetFloat("state", 2);
            //Debug.Log("W pressed");
        }
        else if(Input.GetKey(KeyCode.A))
        {
            m_rb.velocity = Vector2.left * moveSpeed * (IsGround() ? 1f : 0.5f);
            //m_anim.SetFloat("state", 1);
            m_sprite.flipX = true;
            //Debug.Log("A pressed");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            m_rb.velocity = Vector2.right * moveSpeed * (IsGround() ? 1f : 0.5f);
            //m_anim.SetFloat("state", 1);
            m_sprite.flipX = false;
            //Debug.Log("D pressed");
        }
        //else 
        //{
        //    m_anim.SetFloat("state", 0);
        //}
        m_anim.SetFloat("horizontal", m_rb.velocity.x);
        m_anim.SetFloat("vertical",m_rb.velocity.y);
        m_anim.SetFloat("speed", m_rb.velocity.magnitude);
    }
    public bool IsGround()
    {
        return Physics2D.BoxCast(m_coll.bounds.center, m_coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
