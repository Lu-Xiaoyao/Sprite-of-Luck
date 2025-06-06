using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YaYaFollow : MonoBehaviour
{
    //持有组件
    [SerializeField] protected Transform player;
    [SerializeField] protected Transform m_tran;
    protected Animator m_anim;
    protected Rigidbody2D m_rb;
    protected GameObject spawnPoint;
    protected GameObject maxPoint;
    //规定移动的范围
    [SerializeField] protected float XMax;
    [SerializeField] protected float XMin;
    [SerializeField] protected float Y;
    //跟随相关：标准距离以及目标位置
    protected float XDistince;
    protected float XTarget;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        m_tran = gameObject.GetComponent<Transform>();
        m_anim = gameObject.GetComponent<Animator>();
        m_rb = gameObject.GetComponent<Rigidbody2D>();
        spawnPoint = GameObject.Find("SpawnPoints/SpawnPointYaYa");
        maxPoint = GameObject.Find("SpawnPoints/MaxPointYaYa");
        if (spawnPoint != null)
        {
            m_tran.position = spawnPoint.transform.position;
            XMin = spawnPoint.transform.position.x;
            Y = spawnPoint.transform.position.y;
        }
        if (maxPoint != null) 
        {
            XMax = maxPoint.transform.position.x;
        }
        XMax = 91.94f;
        XDistince = player.position.x - m_tran.position.x;
    }

    protected void FixedUpdate()
    {
        YaYaMove();
    }
    protected void YaYaMove()
    {
        XTarget = player.position.x - XDistince;
        XTarget = XTarget > XMax ? XMax : XTarget;
        if (Mathf.Abs(XTarget - m_tran.position.x) > 0.1f)
        {
            m_tran.Translate(new Vector3(XTarget-m_tran.position.x, 0, 0),Space.Self);
            m_anim.SetFloat("horizontal", 1);
            m_anim.SetFloat("speed", 1);
        }
        else
        {
            m_anim.SetFloat("horizontal", 0);
            m_anim.SetFloat("speed", 0);
        }
        m_anim.SetFloat("vertical", m_rb.velocity.y);
        //Debug.Log("horizontal:" + m_rb.velocity.x + ", vertical:" + m_rb.velocity.y);
    }
}
