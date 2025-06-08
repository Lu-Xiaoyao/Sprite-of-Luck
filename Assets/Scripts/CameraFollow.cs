using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static AllControl;

public class CameraFollow : MonoBehaviour
{
    //�������
    private Transform m_camera;
    private Transform minPoint;
    private Transform maxPoint;
    private Transform targetPoint;
    private Transform targetPoint2;
    //�涨����ƶ��ķ�Χ���Լ��������Z
    [SerializeField] private float XMax;
    [SerializeField] private float YMax;
    [SerializeField] private float XMin;
    [SerializeField] private float YMin;
    [SerializeField] private float Z;
    //���������أ�Ŀ��λ�ã��������ѡ���ƶ��ٶ�
    private Vector3 TargetPosition;
    bool followPlayer = true; //false��ʱ���������
    [SerializeField] private float cameraSpeed;
    //��ʱ������������ʱ���������ʼ�����ǵ���Ч��
    private float timer;
    private InputActions inputActions;
    [SerializeField] private AudioSource cameraSound;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player").transform;
        m_camera = gameObject.GetComponent<Transform>();
        minPoint = GameObject.Find("SpawnPoints").transform.Find("MinPointCamera");
        maxPoint = GameObject.Find("SpawnPoints").transform.Find("MaxPointCamera");
        targetPoint = GameObject.Find("Player").transform.Find("CameraPointPlayer");
        Debug.Log(targetPoint);
        targetPoint2 = GameObject.Find("YaYa").transform.Find("CameraPointYaYa"); 
        Debug.Log(targetPoint2);
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
        inputActions = new InputActions();
        if(SceneManager.GetActiveScene().name == "Level3")
        {
            inputActions.IndivControl.Enable();
        }
        if(SceneManager.GetActiveScene().name == "End")
        {
            followPlayer = false;
            Debug.Log(followPlayer);
        }
    }
    private void Update()
    {
        if (inputActions != null && inputActions.IndivControl.CameraShift.triggered)
        {
            cameraSound.Play();
            followPlayer = !followPlayer;
            //Debug.Log(followPlayer);
        }
    }
    
    public void CameraShift()
    {
        cameraSound.Play();
        followPlayer = !followPlayer;
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
        if(followPlayer && targetPoint != null) 
            TargetPosition = targetPoint.position;
        else if(!followPlayer && targetPoint2 != null) 
            TargetPosition = targetPoint2.position;
        TargetPosition.x = TargetPosition.x > XMax ? XMax : TargetPosition.x;
        TargetPosition.x = TargetPosition.x < XMin ? XMin : TargetPosition.x;
        TargetPosition.y = TargetPosition.y > YMax ? YMax : TargetPosition.y;
        TargetPosition.y = TargetPosition.y < YMin ? YMin : TargetPosition.y;
        //if ((m_camera.position - TargetPosition).x > 0.1f) 
        m_camera.position = Vector3.Lerp(m_camera.position,TargetPosition,cameraSpeed);
    }
}
