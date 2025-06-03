using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl2 : PlayerControl
{
    private YaYaFollow2 YaYa;
    protected override void Start()
    {
        base.Start();
        YaYa = GameObject.Find("YaYa").GetComponent<YaYaFollow2>();
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (m_transform.position.y < MinHeight)
        {
            YaYa.Die();
        }
    }
}
