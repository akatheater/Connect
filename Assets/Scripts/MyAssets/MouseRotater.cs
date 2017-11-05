﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 随鼠标旋转的组件
/// </summary>
[DisallowMultipleComponent]
[AddComponentMenu("MyAssets/MouseRotater")]
public class MouseRotater : MonoBehaviour
{
    [Header("【随鼠标旋转的组件】")]
    [Header("灵敏度")]
    [SerializeField]
    private float Xsensitivity = 1;
    [SerializeField]
    private float Ysensitivity = 1;
    [Header("隐藏光标")]
    [SerializeField]
    private bool hideMouseOnPlay;

    [Header("角度锁定")]
    [SerializeField]
    private float upSinAngle;
    [SerializeField]
    private float downSinAngle;

    private void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        if (!((transform.forward.y > upSinAngle && y > 0) || (transform.forward.y < -downSinAngle && y < 0)))
            transform.Rotate(-y * Ysensitivity, 0, 0, Space.Self);
            transform.Rotate(0, x * Xsensitivity, 0, Space.World);
    }

    private void Start()
    {
        Cursor.visible = !hideMouseOnPlay;
    }
}
