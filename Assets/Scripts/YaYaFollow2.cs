using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AllControl;
/// <summary>
/// �ڶ������ŵ��ƶ����ƣ���Ϊ��β����������Ҫͬ���������͵�һ�ص�����ű�ûɶ��ϵ���̳���PlayerControll
/// </summary>
public class YaYaFollow2 : PlayerControl
{
    //�������
    [SerializeField] protected Transform player_tran;
    //������أ���׼�����Լ�Ŀ��λ��
    protected float XDistance;
    protected override void Start()
    {
        base.Start();
        //�����������
        player_tran = GameObject.Find("Player").transform;
        //XDistince = player_tran.position.x - m_transform.position.x;
    }
    protected override void Update()
    {
        base.Update();
        PositionFix();
    }
    /// <summary>
    /// ����x����λ���Զ��������������Ҵ��Զ������λ
    /// �����Զ���Ծ���ȿջ����ȥ��Ҫ�����ͬʱ��ע����·��
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
