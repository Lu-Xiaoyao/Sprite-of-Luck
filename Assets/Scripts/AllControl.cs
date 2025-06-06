using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllControl : MonoBehaviour
{
    public class GameManager
    {
        //����ģʽ
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
        //ˮ����������
        public int apples = 0;
        public int berries = 0;
        //��ɫ�ƶ���׹���ж�����
        public float moveSpeed = 12f;
        public float jumpSpeed = 100f;
        public float MinHeight = -6f;
        public float cameraSpeed = 0.5f;
        //��ǰ�ؿ����
        public int levelIndex = 1;
    }
}
