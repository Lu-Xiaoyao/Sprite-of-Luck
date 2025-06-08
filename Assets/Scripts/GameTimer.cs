using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AllControl;

public class GameTimer : MonoBehaviour
{
    private GameObject uiPlots;

    void Start()
    {
        // 获取场景中所有的Canvas组件
        uiPlots = GameObject.Find("Plots/TextBox");
    }

    void Update()
    {
        // 只有当没有UI显示时才计时
        if (GameManager.Instance != null)
        {            
            if(uiPlots == null)
            {
                GameManager.Instance.gameTime += Time.deltaTime;
            }
            else if(!uiPlots.activeInHierarchy)
            {
                GameManager.Instance.gameTime += Time.deltaTime;
            }
        }
    }
}
