using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionActivator : Function
{
    [Header("【触发激活或隐藏目标游戏物体组件】")]
    [SerializeField]
    private GameObject target;
    [Header("激活或隐藏：")]
    [SerializeField]
    private bool ifActivate = true;
    private void Awake()
    {
        GetComponent<Collider>().isTrigger = true;
    }
    protected override void function(PlayerController player)
    {
        target.SetActive(ifActivate);
    }
}
