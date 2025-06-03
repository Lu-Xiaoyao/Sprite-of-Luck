using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //�������
    private Transform player;
    private Transform m_camera;
    private GameObject spawnPoint;
    private GameObject maxPoint;
    private GameObject virtualPoint;
    //�涨����ƶ��ķ�Χ���Լ��������Z
    [SerializeField] private float XMax;
    [SerializeField] private float YMax;
    [SerializeField] private float XMin;
    [SerializeField] private float YMin;
    [SerializeField] private float Z;
    //���������أ����-��ɫ�����Լ�Ŀ��λ��
    private Vector3 P_C_Distince;
    private Vector3 TargetDistince;
    //��ʱ������������ʱ���������ʼ�����ǵ���Ч��
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        m_camera = gameObject.GetComponent<Transform>();
        spawnPoint = GameObject.Find("SpawnPointCamera");
        maxPoint = GameObject.Find("MaxPointCamera");
        virtualPoint = GameObject.Find("SpawnPointVirtual");
        if (spawnPoint != null)
        {
            m_camera.position = spawnPoint.transform.position;
            XMin = spawnPoint.transform.position.x;
            YMin = spawnPoint.transform.position.y;
            Z = spawnPoint.transform.position.z;
        }
        if (maxPoint != null)
        {
            XMax = maxPoint.transform.position.x;
            YMax = maxPoint.transform.position.y;
        }
        P_C_Distince = virtualPoint.transform.position - m_camera.position;
        timer = 1.0f;
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
        TargetDistince = player.position - P_C_Distince;
        
        TargetDistince.x = TargetDistince.x > XMax ? XMax : TargetDistince.x;
        TargetDistince.x = TargetDistince.x < XMin ? XMin : TargetDistince.x;
        TargetDistince.y = TargetDistince.y > YMax ? YMax : TargetDistince.y;
        TargetDistince.y = TargetDistince.y < YMin ? YMin : TargetDistince.y;
        m_camera.position = TargetDistince;
    }
}
