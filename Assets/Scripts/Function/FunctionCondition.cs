using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionCondition : Function {
    [Header("【判断组件】")]
    [Header("影响目标")]
    public ConditionTrigger target;
    public bool condition = true;
    private int num;
	void Start () {
        num = target.conditionNum;
        target.conditions.Add(!condition);
	}

    protected override void function(PlayerController player)
    {
        target.conditions[num] = condition;
        target.Judge();
    }
    protected override void function2(PlayerController player)
    {
        target.conditions[num] = !condition;
        target.Judge();
    }
}
