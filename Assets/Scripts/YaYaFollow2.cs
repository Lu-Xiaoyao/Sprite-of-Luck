using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AllControl;
/// <summary>
/// 第二关雅雅的移动控制，因为这次不但跟随而且要同步动作，和第一关的自身脚本没啥关系，继承自PlayerControll
/// </summary>
public class YaYaFollow2 : PlayerControl
{
    //持有组件
    [SerializeField] protected Transform player_tran;
    //跟随相关：标准距离以及目标位置
    protected float XDistance;
    protected override void Start()
    {
        base.Start();
        //各种组件持有
        player_tran = GameObject.Find("Player").transform;
        //XDistince = player_tran.position.x - m_transform.position.x;
    }
    protected override void Update()
    {
        base.Update();
        PositionFix();
    }
    /// <summary>
    /// 雅雅x坐标位置自动修正，如果和玩家错开自动跟随归位
    /// 不会自动跳跃、踩空会掉下去，要求玩家同时关注两条路况
    /// </summary>
    protected void PositionFix()
    {
        XDistance = player_tran.position.x - m_transform.position.x;
        if(XDistance > 0.5f || XDistance < -0.5f)
        {
            m_rb.velocity = new Vector2(Mathf.Sign(XDistance) * moveSpeed, m_rb.velocity.y);
        }
        //m_transform.Translate(new Vector3(XTarget - m_transform.position.x, 0, 0), Space.Self);
        m_anim.SetFloat("horizontal", m_rb.velocity.x);
        m_anim.SetFloat("vertical", m_rb.velocity.y);
        m_anim.SetFloat("speed", m_rb.velocity.x + m_rb.velocity.y);
        //Target = player.position - Distince;
        //m_anim.SetFloat("speed", Target.x - m_transform.position.x + Target.y - m_transform.position.y);
        //m_sprite.flipX = (Target.x < m_transform.position.x);
        //m_anim.SetFloat("horizontal", Target.x - m_transform.position.x);
        //m_anim.SetFloat("vertical", m_rb.velocity.y);
        //m_transform.Translate(new Vector3(Target.x - m_transform.position.x, Target.y - m_transform.position.y, 0), Space.Self);
    }
}
