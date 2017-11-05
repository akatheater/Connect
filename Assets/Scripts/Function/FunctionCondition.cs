using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionCondition : Function {
    [Header("【判断组件】")]
    [Header("影响目标")]
    public ConditionTrigger target;
    public bool condition = true;
    private int num;
    private bool on = false;
	void Start () {
        num = target.conditionNum;
        target.conditions.Add(!condition);
        target.conditionNum++;
    }

    protected override void function(PlayerController player)
    {
        if (!on)
        {
            target.conditions[num] = condition;
            on = true;
        }
        else
        {
            target.conditions[num] = !condition;
            on = false;
        }
            target.Judge();
    }
}
