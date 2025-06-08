using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapControl : MonoBehaviour
{
    private int activeCount = 0;
    [SerializeField] int requiredCount = 1;

    // Update is called once per frame
    void Update()
    {
        if(activeCount == requiredCount)
        {
            activeCount++;
            Invoke("ChangeTrag",0.5f);
        }
    }
    private void ChangeTrag()
    {
            GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
            GetComponent<BoxCollider2D>().enabled = !GetComponent<BoxCollider2D>().enabled;
    }
    protected internal void AddCount()
    {
        activeCount++;
        //Debug.Log(activeCount);
    }
    protected internal void SubCount()
    {
        activeCount--;
    }
}
