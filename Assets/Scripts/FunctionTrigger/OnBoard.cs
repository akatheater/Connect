using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 板子
/// </summary>
[RequireComponent(typeof(Collider))]
[AddComponentMenu("Function Trigger/On Board")]
public class OnBoard : FunctionTrigger
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (function != null) function(collision.gameObject.GetComponent<PlayerController>());
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (function2 != null) function2(collision.gameObject.GetComponent<PlayerController>());
        }
    }
}
