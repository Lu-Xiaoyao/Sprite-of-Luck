using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AllControl;
/// <summary>
/// �ڶ������ŵ��ƶ����ƣ�������λ����������Ҫͬʱ����PlayerControl�ű���ʵ���ƶ��Լ���Player����
/// </summary>
public class YaYaFollow2 : MonoBehaviour
{
    //�������
    [SerializeField] protected Transform player_tran;
    private Rigidbody2D m_rb;
    private Animator m_anim;
    private float moveSpeed = GameManager.Instance.moveSpeed;
    //������أ���׼�����Լ�Ŀ��λ��
    protected float XDistance;
    void Start()
    {
        //�����������
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
    /// ����x����λ���Զ��������������Ҵ����Զ������λ
    /// �����Զ���Ծ���ȿջ����ȥ��Ҫ�����ͬʱ��ע����·��
    /// </summary>
    protected void PositionFix()
    {
        if(Mathf.Abs(player_tran.position.y - transform.position.y) > 1f)
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
}
