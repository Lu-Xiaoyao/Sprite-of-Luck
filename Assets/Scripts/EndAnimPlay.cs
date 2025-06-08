using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EndAnimPlay : MonoBehaviour
{
    [SerializeField] private AudioSource hoverSound;
    
    public void OnPointerEnter()
    {
        hoverSound.Play();
    }
    public void PlayAnim()
    {
        GameObject.Find("YaYa").GetComponent<EndAnimYaYaWalk>().enabled = true;
        transform.parent.gameObject.SetActive(false);
    }
}
