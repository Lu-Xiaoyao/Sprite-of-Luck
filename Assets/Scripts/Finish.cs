using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static AllControl;

public class Finish : MonoBehaviour
{
    //�ж��ű����ڴ������ϣ����������Ǿ������������ؿ����
    protected static internal bool LevelCompleted = false;
    private int collisionCount = 0;
    [SerializeField] private AudioSource finishSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !LevelCompleted)
        {
            collisionCount++;
            if(collisionCount == 2)
            {
                LevelCompleted = true;
                finishSound.Play();
                Invoke("CompleteLevel", 1f);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !LevelCompleted)
        {
            collisionCount--;
        }
    }
    private void CompleteLevel()
    {
        //Debug.Log("Level completed, loading next scene...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        LevelCompleted = false;
        GameManager.Instance.levelIndex += 1;
    }
}

