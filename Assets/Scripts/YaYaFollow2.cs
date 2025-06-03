using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YaYaFollow2 : MonoBehaviour
{
    //持有组件
    [SerializeField] protected Transform player_tran;
    [SerializeField] protected Transform m_tran;
    protected PlayerControl2 player_control;
    protected Animator m_anim;
    protected Rigidbody2D m_rb;
    protected GameObject spawnPoint;
    protected SpriteRenderer m_sprite;
    //跟随相关：标准距离以及目标位置
    protected float XDistince;
    protected float XTarget;
    protected float MinHeight;
    protected float jmpSpeed;
    protected float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        player_tran = GameObject.Find("Player").transform;
        m_tran = gameObject.GetComponent<Transform>();
        player_control = GameObject.Find("Player").GetComponent<PlayerControl2>();
        m_anim = gameObject.GetComponent<Animator>();
        m_rb = gameObject.GetComponent<Rigidbody2D>();
        spawnPoint = GameObject.Find("SpawnPointYaYa");
        m_sprite = gameObject.GetComponent<SpriteRenderer>();
        jmpSpeed = player_control.GetJumpSpeed();
        moveSpeed = player_control.GetMoveSpeed();
        MinHeight = -6.0f;
        if (spawnPoint != null)
        {
            m_tran.position = spawnPoint.transform.position;
        }
        XDistince = player_tran.position.x - m_tran.position.x;
    }
    protected void FixedUpdate()
    {
        YaYaMove();
        PositionFix();
        if (m_tran.position.y < MinHeight)
        {
            Die();
            GameObject.Find("Player").GetComponent<PlayerControl2>().Die();
        }
    }
    protected void YaYaMove()
    {
        if (Input.GetKeyDown(KeyCode.W) && player_control.IsGround())
        {
            m_rb.velocity = Vector2.up * jmpSpeed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            m_rb.velocity = Vector2.left * moveSpeed;
            m_sprite.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            m_rb.velocity = Vector2.right * moveSpeed;
            m_sprite.flipX = false;
        }
        m_anim.SetFloat("horizontal", m_rb.velocity.x);
        m_anim.SetFloat("vertical", m_rb.velocity.y);
        m_anim.SetFloat("speed", m_rb.velocity.magnitude);
        
    }
    protected void PositionFix()
    {
        XTarget = player_tran.position.x - XDistince;
        m_tran.Translate(new Vector3(XTarget - m_tran.position.x, 0, 0), Space.Self);
        m_anim.SetFloat("horizontal", XTarget - m_tran.position.x);
        m_anim.SetFloat("vertical", m_rb.velocity.y);
        m_anim.SetFloat("speed", XTarget - m_tran.position.x + m_rb.velocity.y);
        //Target = player.position - Distince;
        //m_anim.SetFloat("speed", Target.x - m_tran.position.x + Target.y - m_tran.position.y);
        //m_sprite.flipX = (Target.x < m_tran.position.x);
        //m_anim.SetFloat("horizontal", Target.x - m_tran.position.x);
        //m_anim.SetFloat("vertical", m_rb.velocity.y);
        //m_tran.Translate(new Vector3(Target.x - m_tran.position.x, Target.y - m_tran.position.y, 0), Space.Self);
    }
    public void Die()
    {
        m_tran.position = spawnPoint.transform.position;
    }
}
