using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformStick : MonoBehaviour
{
    private void Start()
    {
        if (transform.parent != null && transform.parent.name == "Tracks")
        {
            this.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject != null && collision.gameObject.CompareTag("Player"))
        {
            try
            {
                collision.gameObject.transform.SetParent(null);
            }
            catch (System.Exception)
            {
                // 忽略设置父物体时的错误
            }
        }
    }
}
