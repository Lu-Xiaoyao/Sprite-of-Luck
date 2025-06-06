using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierVanish : MonoBehaviour
{
    private Animator m_anim;
    //private Collider2D m_coll;
    private int activeCount = 0;
    [SerializeField] int requiredCount;
    // Start is called before the first frame update
    void Start()
    {
        m_anim = GetComponent<Animator>();
        //m_coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(activeCount == requiredCount)
        {
            m_anim.SetTrigger("Vanish");
            //m_coll.enabled = false;
        }
    }
    protected internal void AddCount()
    {
        activeCount++;
        Debug.Log(activeCount);
    }
    protected internal void SubCount()
    {
        activeCount--;
    }
}
