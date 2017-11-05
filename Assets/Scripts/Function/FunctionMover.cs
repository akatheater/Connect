using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 可以控制其他平台移动的组件
/// </summary>
public class FunctionMover : Function
{
    [Header("【可以控制其他平台移动的组件】")]
    [SerializeField]
    [Header("板子们")]
    private BoardMover.Parameter[] parameter;

    [SerializeField]
    private bool qiLai = false;

    private Vector3[] origPos;

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
    private void Start()
    {
        origPos = new Vector3[parameter.Length];
        for (int i = 0; i < parameter.Length; i++)
        {
            origPos[i] = parameter[i].target.position;
            parameter[i].delta += parameter[i].target.position;
            if (parameter[i].target.GetComponent<EmptyCom>() == null)
            {
                parameter[i].target.gameObject.AddComponent<EmptyCom>();
            }
        }
    }
    protected override void function(PlayerController player)
    {
        if (parameter != null)
        {
            foreach (BoardMover.Parameter p in parameter)
                BoardMover.Move(p.target, p.delta - p.target.position, 1 - p.smoothness, p.delaySeconds + 0.1f, p.target.GetComponent<EmptyCom>());
            if (!qiLai) Boom();
        }
        else
        {
            print("没有选定上升的板子！");
        }
    }
    protected override void function2(PlayerController player)
    {
        if (!qiLai) return;

        if (parameter != null)
        {
            for (int i = 0; i < parameter.Length; i++)
            {
                BoardMover.Move(parameter[i].target, origPos[i] - parameter[i].target.position, 1 - parameter[i].smoothness, parameter[i].delaySeconds + 0.3f, parameter[i].target.GetComponent<EmptyCom>());
            }
        }
    }
}
