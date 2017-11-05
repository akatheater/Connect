using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 所有触发器父类
/// </summary>
public class FunctionTrigger : MonoBehaviour {

    public BuffDelegate function;
    public BuffDelegate function2;

    [ContextMenu("移动其他平台")]
    public void AddMover()
    {
        gameObject.AddComponent<FunctionMover>();
    }

    [ContextMenu("自发光")]
    public void AddSelfLighter()
    {
        gameObject.AddComponent<FunctionSelfLighter>();
    }

    [ContextMenu("使发光")]
    public void AddLighter()
    {
        gameObject.AddComponent<FunctionLighter>();
    }

    [ContextMenu("激活其他物体")]
    public void AddActivator()
    {
        gameObject.AddComponent<FunctionActivator>();
    }

    [ContextMenu("同步平台的移动到玩家")]
    public void AddSycMoving()
    {
        gameObject.AddComponent<FunctionSycMoving>();
    }

    [ContextMenu("能量变化")]
    public void AddEnergy()
    {
        gameObject.AddComponent<FunctionEnergy>();
    }

}
