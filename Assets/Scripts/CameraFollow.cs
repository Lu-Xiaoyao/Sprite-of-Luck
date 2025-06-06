using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static AllControl;

public class CameraFollow : MonoBehaviour
{
    //持有组件
    private Transform m_camera;
    private Transform minPoint;
    private Transform maxPoint;
    private Transform targetPoint;
    private Transform targetPoint2;
    //规定相机移动的范围，以及相机距离Z
    [SerializeField] private float XMax;
    [SerializeField] private float YMax;
    [SerializeField] private float XMin;
    [SerializeField] private float YMin;
    [SerializeField] private float Z;
    //相机跟随相关：目标位置，跟随对象选择，移动速度
    private Vector3 TargetPosition;
    bool followPlayer = true; //false的时候跟随雅雅
    [SerializeField] private float cameraSpeed;
    //延时启动相机跟随计时器，保留最开始的主角掉落效果
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player").transform;
        m_camera = gameObject.GetComponent<Transform>();
        minPoint = GameObject.Find("SpawnPoints/MinPointCamera").transform;
        maxPoint = GameObject.Find("SpawnPoints/MaxPointCamera").transform;
        targetPoint = GameObject.Find("Player/CameraPointPlayer").transform;
        targetPoint2 = GameObject.Find("YaYa/CameraPointYaYa").transform; 
        if (minPoint != null)
        {
            m_camera.position = minPoint.transform.position;
            XMin = minPoint.transform.position.x;
            YMin = minPoint.transform.position.y;
            Z = minPoint.transform.position.z;
        }
        if (maxPoint != null)
        {
            XMax = maxPoint.transform.position.x;
            YMax = maxPoint.transform.position.y;
        }
        //P_C_Distince = targetPoint.position - m_camera.position;
        cameraSpeed = GameManager.Instance.cameraSpeed;
        timer = 1.0f;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            followPlayer = !followPlayer;
            Debug.Log(followPlayer);
        }
    }
    private void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.fixedDeltaTime;
        }
        else
        {
            CameraMove();
        }
    }

    private void CameraMove()
    {
        if(followPlayer) 
            TargetPosition = targetPoint.position;
        else 
            TargetPosition = targetPoint2.position;
        TargetPosition.x = TargetPosition.x > XMax ? XMax : TargetPosition.x;
        TargetPosition.x = TargetPosition.x < XMin ? XMin : TargetPosition.x;
        TargetPosition.y = TargetPosition.y > YMax ? YMax : TargetPosition.y;
        TargetPosition.y = TargetPosition.y < YMin ? YMin : TargetPosition.y;
        //if ((m_camera.position - TargetPosition).x > 0.1f) 
        m_camera.position = Vector3.Lerp(m_camera.position,TargetPosition,cameraSpeed);
    }
}
