using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static AllControl;
public class BerryCollection : MonoBehaviour
{
    private int berries = GameManager.Instance.berries;
    [SerializeField] private Text BerriesText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Strawberry"))
        {
            Destroy(collision.gameObject);
            berries++;
            BerriesText.text = "Strawberries:" + berries;
            //Debug.Log("berries:"+berries);
            GameManager.Instance.berries = berries;
        }
    }
}
