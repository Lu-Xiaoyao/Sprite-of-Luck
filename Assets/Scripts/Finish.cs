using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static AllControl;

public class Finish : MonoBehaviour
{
    //判定脚本挂在触发器上，与两个主角均发生触碰即关卡完成
    protected static internal bool LevelCompleted = false;
    private int collisionCount = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !LevelCompleted)
        {
            collisionCount++;
            if(collisionCount == 2)
            {
                LevelCompleted = true;
                Invoke("CompleteLevel", 2f);
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
        Debug.Log("Level completed, loading next scene...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        LevelCompleted = false;
        GameManager.Instance.levelIndex += 1;
    }
}

