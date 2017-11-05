using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionSycMoving : Function {
    protected override void function(PlayerController player)
    {
        player.Buff += MovePlayer;
    }
    protected override void function2(PlayerController player)
    {
        player.Buff -= MovePlayer;
    }
    private void MovePlayer(PlayerController player)
    {
        player.dir += GetComponent<Rigidbody>().velocity;
    }
}
