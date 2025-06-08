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
        //水果收集数量
        public int apples = 0;
        public int berries = 0;
        //角色移动和跳跃判断参数
        public float moveSpeed = 12f;
        public float jumpSpeed = 100f;
        public float MinHeight = -6f;
        public float cameraSpeed = 0.1f;
        //当前关卡索引
        public int levelIndex = 1;
        public float airControlMultiplier = 1.0f;
        public float gravityScale = 15f;
        public int spawnTimes = 0;
        //游戏时间
        public float gameTime = 0f;
    }
}
