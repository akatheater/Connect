using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDown : PlayerController
{
    [Header("上升速度")]
    [SerializeField]
    private float upSpeed;
    [Header("下潜速度")]
    [SerializeField]
    private float downSpeed;

    protected override void KeyBoardInput()
    {
        base.KeyBoardInput();
        if (GameSystem.InputKeys.Crouch())
        {
            ySpeed = -downSpeed;
        }
        else if (GameSystem.InputKeys.Fly())
        {
            ySpeed = upSpeed;
        }
        else
        {
            ySpeed = 0;
        }
    }
}
