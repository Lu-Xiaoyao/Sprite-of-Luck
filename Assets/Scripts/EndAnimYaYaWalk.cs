using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static AllControl;

public class EndAnimYaYaWalk : MonoBehaviour
{
    private Animator m_anim;
    private Rigidbody2D m_rb;
    // Start is called before the first frame update
    private Transform player;
    private Transform spawnPoint;
    private float moveSpeed = GameManager.Instance.moveSpeed;
    [SerializeField] private AudioSource collectSound;
    [SerializeField] private AudioSource endSound;
    private Button returnButton;
    private bool walk = false;
    
    void Start()
    {
        m_anim = gameObject.GetComponent<Animator>();
        m_rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
        spawnPoint = GameObject.Find("SpawnPoints").transform.Find("SpawnPointYaYa");
        returnButton = GameObject.Find("Canvas2/ReturnButton").GetComponent<Button>();
        returnButton.gameObject.SetActive(false);
        if(spawnPoint != null)
        {
            transform.position = spawnPoint.position;
            Invoke("WalkEnable", 1.5f);
        }
    }
    void WalkEnable()
    {
        walk = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(walk)
        {
            if(player != null && player.position.x - transform.position.x > 2f)
            {
                m_rb.velocity = new Vector2(moveSpeed, 0);
            }
            else
            {
                m_rb.velocity = new Vector2(0, 0);
                endSound.Play();
                walk = false;
                Invoke("CallReturn",2f);
            }
            m_anim.SetFloat("horizontal", m_rb.velocity.x);
            m_anim.SetFloat("speed", m_rb.velocity.x);            
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Strawberry") || collision.gameObject.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);
            collectSound.Play();
        }
    }

    private void CallReturn()
    {
        returnButton.gameObject.SetActive(true);
    }
}
