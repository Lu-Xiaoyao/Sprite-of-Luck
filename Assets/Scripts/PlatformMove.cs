using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlatformMove : MonoBehaviour
{
    private Transform m_tran;
    //private Rigidbody m_rb;
    [SerializeField] private List<Transform> targetPoints;
    private int targetIndex = 0;
    private Vector2 distance;
    [SerializeField] private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        targetPoints = new List<Transform>();
        if (transform.parent != null)
        {
            targetPoints = transform.parent.Cast<Transform>().Where(t => t != transform).ToList(); // 获取父物体下所有子物体，并排除自身
        }
        m_tran = gameObject.GetComponent<Transform>();
        //m_rb = gameObject.GetComponent<Rigidbody>();
        moveSpeed = 0.008f;
    }

    // Update is called once per frame
    void Update()
    {
        AutoMove();
    }

    private void AutoMove()
    {
        distance = targetPoints[targetIndex].position - m_tran.position;
        //Debug.Log(distance);
        if (Mathf.Abs(distance.x) < 0.1f && Mathf.Abs(distance.y) < 0.1f)
        {
            targetIndex = (targetIndex + 1) % targetPoints.Count;
        }
        m_tran.position = Vector2.MoveTowards(m_tran.position, targetPoints[targetIndex].position, moveSpeed);
        //m_rb.velocity = new Vector2(Mathf.Sign(distance.x), Mathf.Sign(distance.y)) * moveSpeed;
    }
}
