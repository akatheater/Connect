using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 移动父类
/// </summary>
[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
public class Moving : MonoBehaviour {
    protected Vector3 v;
    private void Update()
    {
        Move(transform);
        VolecityFlush();
    }
    private void Awake()
    {
        GetComponent<Rigidbody>().freezeRotation = true;
        GetComponent<Rigidbody>().useGravity = false;
    }
    protected virtual void VolecityFlush()
    {

    }
    private void Move(Transform target)
    {
        GetComponent<Rigidbody>().velocity = v;
    }
}
