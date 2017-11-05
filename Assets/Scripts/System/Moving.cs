using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 移动父类
/// </summary>
[DisallowMultipleComponent]
public class Moving : MonoBehaviour {
    [HideInInspector]
    public Vector3 v;
    private void Update()
    {
        VolecityFlush();
        Move();
    }
    protected virtual void VolecityFlush()
    {

    }
    private void Move()
    {
        transform.Translate(v * Time.deltaTime);
    }
}
