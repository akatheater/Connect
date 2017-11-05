using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Items/Chip Moving")]
public class ChipMoving : Moving
{

    [Header("【平台移动组件】")]
    [Header("速度")]
    [SerializeField]
    private float speed;
    [Header("高度")]
    [SerializeField]
    private float height;
    private float theta;
    [SerializeField]
    private Vector3 rot;
    [SerializeField]
    private Vector3 offset;

    private void Start()
    {
        theta = 0;
        transform.Translate(offset);
    }
    protected override void VolecityFlush()
    {
        base.VolecityFlush();
        theta += speed * Time.deltaTime * 360;
        v = Vector3.up * height * speed * Mathf.Cos(theta / 360);//乘speed是在试着凭感觉消除误差
        transform.Rotate(rot * Time.deltaTime);
    }
}
