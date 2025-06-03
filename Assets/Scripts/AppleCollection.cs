using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static AllControl;
public class AppleCollection : MonoBehaviour
{
    private int apples = GameManager.Instance.apples;
    [SerializeField] private Text ApplesText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);
            apples++;
            //Debug.Log(apples);
            ApplesText.text = "Apples:" + apples; 
            GameManager.Instance.apples = apples;
        }
    }
}
