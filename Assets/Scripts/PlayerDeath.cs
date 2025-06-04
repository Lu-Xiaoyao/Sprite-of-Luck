using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AllControl;
/// <summary>
/// π©Player∫ÕYaYa∏¥”√
/// </summary>
public class PlayerDeath : MonoBehaviour
{
    private string m_name;
    private string f_name; //friend_name
    protected Transform m_transform;
    protected Animator m_anim;
    protected GameObject spawnPoint;
    protected PlayerDeath f_death;
    [SerializeField] protected float MinHeight;
    // Start is called before the first frame update
    void Start()
    {
        m_name = gameObject.name;
        if (m_name == "Player")
            f_name = "YaYa";
        else
            f_name = "Player";
        m_transform = gameObject.GetComponent<Transform>();
        m_anim = gameObject.GetComponent <Animator>();
        MinHeight = GameManager.Instance.MinHeight;
        f_death = GameObject.Find(f_name).GetComponent<PlayerDeath>();
        spawnPoint = GameObject.Find("SpawnPoint"+m_name);
        Debug.Log("SpawnPoint" + m_name);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_transform.position.y < MinHeight)
        {
            Die();
            if (f_death != null)
            {
                f_death.Die();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            Die();
            if (f_death != null)
            {
                f_death.Die();
            }
        }
    }
    protected internal void Die()
    {
        if (spawnPoint != null)
        {
            m_anim.SetTrigger("death");
            Invoke("Respawn", 2f);
        }
    }

    protected void Respawn()
    {
        m_anim.ResetTrigger("death");
        m_anim.SetTrigger("respawn");
        transform.position = spawnPoint.transform.position;
    }
}
