using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AllControl;

public class CameraHints : MonoBehaviour
{
    private Transform camera_tran; 
    private Transform hint_tran;
    private bool hint = false;
    private float cameraSpeed = GameManager.Instance.cameraSpeed;
    void Start()
    {
        camera_tran = GameObject.Find("Main Camera").GetComponent<Transform>();
        hint_tran = transform.Find("HintPoint");
    }
   private void OnCollisionEnter2D(Collision2D collision)
   {
        if(!hint)
        {
            camera_tran.gameObject.GetComponent<CameraFollow>().enabled = false;
            camera_tran.position = hint_tran.position;
            Invoke("FollowRegain",1f);
            hint = true;
        }
   }

   private void FollowRegain()
   {
        camera_tran.gameObject.GetComponent<CameraFollow>().enabled = true;
   }
}
