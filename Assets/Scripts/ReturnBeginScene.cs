using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnBeginScene : MonoBehaviour
{
    [SerializeField] private AudioSource hoverSound;
    public void OnPointerEnter()
    {
        hoverSound.Play();
    }
    public void Restart()
    {
        SceneManager.LoadScene("Start");
    }
}
