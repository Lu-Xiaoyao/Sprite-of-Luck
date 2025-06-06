using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllControl : MonoBehaviour
{
    public class GameManager
    {
        //单例模式
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameManager();
                return _instance;
            }
        }
        //水果数量数据
        public int apples = 0;
        public int berries = 0;
        //角色移动和坠落判定数据
        public float moveSpeed = 12f;
        public float jumpSpeed = 100f;
        public float MinHeight = -6f;
        public float cameraSpeed = 0.5f;
        //当前关卡编号
        public int levelIndex = 1;
    }
}
