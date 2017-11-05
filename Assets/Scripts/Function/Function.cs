using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 功能父类
/// </summary>
public class Function : MonoBehaviour {
    [Header("重载触发器")]
    public FunctionTrigger overrideTrigger;

    private void Awake()
    {
        if(overrideTrigger == null)
        {
            overrideTrigger = GetComponent<FunctionTrigger>();
        }
        overrideTrigger.function += function;
        overrideTrigger.function2 += function2;
    }

    protected void Boom()
    {
        overrideTrigger.function -= function;
        overrideTrigger.function2 -= function2;
    }

    protected virtual void function(PlayerController player)
    {

    }
    protected virtual void function2(PlayerController player)
    {

    }
}
