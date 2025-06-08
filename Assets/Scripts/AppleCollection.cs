using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static AllControl;
public class AppleCollection : MonoBehaviour
{
    private int apples = GameManager.Instance.apples;
    [SerializeField] private TextMeshProUGUI ApplesText;
    [SerializeField] private AudioSource collectSound;
    
    void Start()
    {
        ApplesText.text = apples.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);
            collectSound.Play();
            apples++;
            //Debug.Log(apples);
            ApplesText.text = apples.ToString(); 
            GameManager.Instance.apples = apples;
        }
    }
}
