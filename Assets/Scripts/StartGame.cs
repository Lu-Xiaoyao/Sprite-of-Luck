using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static AllControl;

public class StartGame : MonoBehaviour
{
    [SerializeField] private AudioSource hoverSound;
    public void OnPointerEnter()
    {
        hoverSound.Play();
    }
    public void GameStart()
    {
        // 重置游戏时间
        if (GameManager.Instance != null)
        {
            GameManager.Instance.gameTime = 0f;
            GameManager.Instance.spawnTimes = 0;
            GameManager.Instance.apples = 0;
            GameManager.Instance.berries = 0;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
