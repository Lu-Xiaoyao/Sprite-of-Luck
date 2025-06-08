using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static AllControl;

public class ScoreCount : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        if (GameManager.Instance != null)
        {
            float finalTime = GameManager.Instance.gameTime;
            int minutes = Mathf.FloorToInt(finalTime / 60);
            int seconds = Mathf.FloorToInt(finalTime % 60);
            int spawnTimes = GameManager.Instance.spawnTimes;
            int apples = GameManager.Instance.apples;
            int berries = GameManager.Instance.berries;
            scoreText.text = string.Format("通关时间: {0:00}:{1:00}\n复活次数: {2}\n总共收集：苹果: {3}/46；草莓: {4}/46", minutes, seconds, spawnTimes, apples, berries);
        }
    }
}
