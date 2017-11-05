using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 在板子上交互
/// </summary>
[RequireComponent(typeof(Collider))]
[AddComponentMenu("Function Trigger/Interact On Board")]
public class InteractOnBoard : FunctionTrigger
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().Buff += OnInteract;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().Buff -= OnInteract;
        }
    }
    private void OnInteract(PlayerController player)
    {
        if (GameSystem.InputKeys.Interact())
        {
            if (function != null) function(player);
        }
    }
}
