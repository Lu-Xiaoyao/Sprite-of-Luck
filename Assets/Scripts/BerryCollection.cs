using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static AllControl;
public class BerryCollection : MonoBehaviour
{
    private int berries = GameManager.Instance.berries;
    [SerializeField] private TextMeshProUGUI BerriesText;
    [SerializeField] private AudioSource collectSound;
    void Start()
    {
        BerriesText.text = berries.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Strawberry"))
        {
            Destroy(collision.gameObject);
            collectSound.Play();
            berries++;
            BerriesText.text = berries.ToString();
            //Debug.Log("berries:"+berries);
            GameManager.Instance.berries = berries;
        }
    }
}
