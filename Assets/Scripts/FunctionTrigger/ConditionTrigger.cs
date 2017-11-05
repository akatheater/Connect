using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Function Trigger/Conditional trigger")]
public class ConditionTrigger : FunctionTrigger
{
    [HideInInspector]
    public List<bool> conditions;
    [HideInInspector]
    public int conditionNum = 0;
    private bool on = false;
    private void Awake()
    {
        conditions = new List<bool>();
    }

    public void Judge()
    {
        if (on || conditions.Count == 0) return;
        bool result = true;
        foreach (bool b in conditions)
        {
            result = result && b;
        }
        if (result)
        {
            function(GameSystem.playerUp); on = true;
        }
    }
}
