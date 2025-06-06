using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AllControl;
/// <summary>
/// 第二关雅雅的移动控制，仅负责位置修正，需要同时挂载PlayerControl脚本，实现移动以及供Player调用
/// </summary>
public class YaYaFollow2 : MonoBehaviour
{
    //持有组件
    [SerializeField] protected Transform player_tran;
    private Rigidbody2D m_rb;
    private Animator m_anim;
    private float moveSpeed = GameManager.Instance.moveSpeed;
    //跟随相关：标准距离以及目标位置
    protected float XDistance;
    void Start()
    {
        //各种组件持有
        player_tran = GameObject.Find("Player").transform;
        m_rb = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();

        //XDistince = player_tran.position.x - transform.position.x;
    }
    void Update()
    {
        PositionFix();
    }
    /// <summary>
    /// 雅雅x坐标位置自动修正，如果和玩家错开自动跟随归位
    /// 不会自动跳跃、踩空会掉下去，要求玩家同时关注两条路况
    /// </summary>
    protected void PositionFix()
    {
        XDistance = player_tran.position.x - transform.position.x;
        if(XDistance > 0.5f || XDistance < -0.5f)
        {
            m_rb.velocity = new Vector2(Mathf.Sign(XDistance) * moveSpeed, m_rb.velocity.y);
        }
        //transform.Translate(new Vector3(XTarget - transform.position.x, 0, 0), Space.Self);
        m_anim.SetFloat("horizontal", m_rb.velocity.x);
        m_anim.SetFloat("vertical", m_rb.velocity.y);
        m_anim.SetFloat("speed", m_rb.velocity.x + m_rb.velocity.y);
        //Target = player.position - Distince;
        //m_anim.SetFloat("speed", Target.x - transform.position.x + Target.y - transform.position.y);
        //m_sprite.flipX = (Target.x < transform.position.x);
        //m_anim.SetFloat("horizontal", Target.x - transform.position.x);
        //m_anim.SetFloat("vertical", m_rb.velocity.y);
        //transform.Translate(new Vector3(Target.x - transform.position.x, Target.y - transform.position.y, 0), Space.Self);
    }
}
