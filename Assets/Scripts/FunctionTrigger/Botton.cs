using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作为所有按钮的基础组件
/// </summary>
[RequireComponent(typeof(Collider))]
[AddComponentMenu("Function Trigger/Botton")]
public class Botton : FunctionTrigger {
    [Header("【按钮！】")]
    [Header("按钮朝向")]
    public BasicDirection direction;
    private Vector3 dirVector;
    [Header("按钮厚度")]
    public float size;
    private void Awake()
    {
        switch (direction)
        {
            case BasicDirection.up:
                dirVector = Vector3.up;
                break;
            case BasicDirection.down:
                dirVector = Vector3.down;
                break;
            case BasicDirection.forward:
                dirVector = Vector3.forward;
                break;
            case BasicDirection.back:
                dirVector = Vector3.back;
                break;
            case BasicDirection.left:
                dirVector = Vector3.left;
                break;
            case BasicDirection.right:
                dirVector = Vector3.right;
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            GameSystem.settings.StartCoroutine(GameSystem.Moving(transform, dirVector * (-size)));
            function(collision.gameObject.GetComponent<PlayerController>());
        }
    }
}
