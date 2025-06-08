using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 检查点设置，本脚本只挂在Player的检查点上。检查点名称注意格式
/// </summary>
public class CheckPoint : MonoBehaviour
{
    private Transform y_check;
    private Transform m_spawn;
    private Transform y_spawn;
    private SpriteRenderer m_renderer;
    private SpriteRenderer y_renderer;
    // Start is called before the first frame update
    void Start()
    {
        y_check = transform.parent.Find(gameObject.name + "YaYa");
        m_spawn = transform.parent.Find("SpawnPointPlayer");
        y_spawn = transform.parent.Find("SpawnPointYaYa");
        m_renderer = GetComponent<SpriteRenderer>();
        y_renderer = y_check.gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(transform.position.y > m_spawn.position.y)
            {
                m_spawn.position = transform.position;
                y_spawn.position = y_check.position; 
                y_renderer.color = new Color(y_renderer.color.r,y_renderer.color.g,y_renderer.color.b,1f);
                m_renderer.color = new Color(m_renderer.color.r,m_renderer.color.g,m_renderer.color.b,1f); 
            }
        }
    }
}
