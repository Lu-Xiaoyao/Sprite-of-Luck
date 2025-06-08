using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AllControl;
/// <summary>
/// ��Player��YaYa����
/// </summary>
public class PlayerDeath : MonoBehaviour
{
    private string m_name;
    private string f_name; //friend_name
    protected Transform m_transform;
    protected Animator m_anim;
    protected GameObject spawnPoint;
    protected PlayerDeath f_death;
    protected PlayerControl m_control;
    [SerializeField] protected float MinHeight;
    [SerializeField] private AudioSource deathSound;
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
        m_control = gameObject.GetComponent<PlayerControl>();
        MinHeight = GameManager.Instance.MinHeight;
        f_death = GameObject.Find(f_name).GetComponent<PlayerDeath>();
        spawnPoint = GameObject.Find("SpawnPoints/SpawnPoint" + m_name);
        Debug.Log("SpawnPoint" + m_name);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_transform.position.y < MinHeight)
        {
            deathSound.Play();
            Respawn();
            if (f_death != null)
            {
                f_death.Respawn();
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
        deathSound.Play();
        if (spawnPoint != null)
        {
            m_anim.SetTrigger("death");
            if(m_control != null)
            {
                m_control.enabled = false;
                m_transform.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
                m_transform.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        Invoke("Respawn",0.5f);
        }
    }

    protected void Respawn()
    {
        m_anim.SetTrigger("respawn");
        transform.position = spawnPoint.transform.position;
        if(m_name == "Player")
        {
            GameManager.Instance.spawnTimes++;
        }
        if (m_control != null)
        {
            m_control.enabled = true;
            m_transform.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}