using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    [SerializeField] private string username; //��ť���ĸ���ɫ��Ч����������tag�Զ����
    [SerializeField] private List<GameObject> targets = new List<GameObject>(); //���а�ť�������Ķ���
    private Animator m_anim;
    private void Start()
    {
        if (CompareTag("ButtonPink")) username = "YaYa";
        else if (CompareTag("ButtonBlue")) username = "Player";
        m_anim = GetComponent<Animator>();
        foreach (Transform child in transform.parent.parent.Find("Tracks"))
        {
            targets.Add(child.gameObject);
            Debug.Log(child.name);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == username && !m_anim.GetBool("Press"))
        {
            m_anim.SetBool("Press",true);
            foreach(GameObject target in targets)
            {
                if(target.CompareTag("Barrier"))
                {
                    target.GetComponent<BarrierVanish>().AddCount();
                    Debug.Log("BarrierVanish Count + 1");
                }
                else if(target.CompareTag("Platform"))
                {
                    target.GetComponent<PlatformMove>().enabled = true;
                }
            }
        }
    }
}
