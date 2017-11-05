using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 不能被实例化，提供平滑移动物体方法
/// </summary>
public class BoardMover : MonoBehaviour
{
    /// <summary>
    /// 移动所需属性
    /// </summary>
    [System.Serializable]
    public struct Parameter
    {
        [Header("移动目标")]
        public Transform target;
        [Header("移动距离")]
        public Vector3 delta;
        [Header("平滑度, 建议默认为0.9915")]
        [Range(0.9f, 0.999f)]
        public float smoothness;
        [Header("延迟")]
        public float delaySeconds;
    }

    public static void Move(Transform board, Vector3 delta, float param, float delaySeconds)
    {
        GameSystem.settings.StartCoroutine(StartMove(board, delta, param, delaySeconds));
    }

    private static IEnumerator StartMove(Transform board, Vector3 delta, float param, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        yield return GameSystem.Moving(board, delta, param);
    }
}

