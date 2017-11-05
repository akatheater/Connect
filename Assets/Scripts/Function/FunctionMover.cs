using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 可以控制其他平台移动的组件
/// </summary>
public class FunctionMover : Function {
    [Header("【可以控制其他平台移动的组件】")]
    [SerializeField]
    [Header("板子们")]
    private BoardMover.Parameter[] parameter;

    private void Reset()
    {
        parameter = new BoardMover.Parameter[1];
        for (int i = 0; i < parameter.Length; i++)
        {
            parameter[i].smoothness = 0.9915f;
            parameter[i].delaySeconds = 0;
            parameter[i].delta = Vector3.up;
        }
    }
    protected override void function(PlayerController player)
    {
        if (parameter != null)
        {
            foreach (BoardMover.Parameter p in parameter)
                BoardMover.Move(p.target, p.delta, 1 - p.smoothness, p.delaySeconds);
            Destroy(this);
        }
        else
        {
            print("没有选定上升的板子！");
        }
    }
}
