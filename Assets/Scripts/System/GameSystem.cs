﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour {
    public static GameSystem settings;
    private void Awake()
    {
        settings = this;
    }
    public static class InputKeys
    {
        public static bool Jump()
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
        public static float Horizontal()
        {
            return Input.GetAxis("Horizontal");
        }
        public static float Vertical()
        {
            return Input.GetAxis("Vertical");
        }
        public static bool Interact()
        {
            return Input.GetKeyDown(KeyCode.F);
        }
    }
    //移动物体的协程
    public static IEnumerator Moving(Transform target, Vector3 delta, float param = 0.9915f)
    {
        if (delta.sqrMagnitude < 0.001f)
        {
            target.Translate(delta);
            yield return 0;
        }
        else
        {
            Vector3 addition = delta * param;
            delta -= addition;
            target.Translate(addition);
            yield return 0;
            yield return Moving(target, delta, param);
        }
    }
}
public delegate void BuffDelegate(PlayerController player);
//基本方向
public enum BasicDirection
{
    up, down, forward, back, left, right
}
