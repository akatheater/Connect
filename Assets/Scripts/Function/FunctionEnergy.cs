using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 能量变化组件
/// </summary>
public class FunctionEnergy : Function {
    [Header("【能量变化组件】")]
    [Header("是否增加能量")]
    public bool add;
    [Header("能量变化数目")]
    [Range(0,13)]
    public int EnergyNum;

    protected override void function(PlayerController player)
    {
        if (player.gameObject.GetComponent<PlayerUp>() != null)
        {
            for(int i = 0; i < EnergyNum; i++)
            {
                if (add) GameSystem.EnergyUp();
                else GameSystem.EnergyDown();
            }
            Boom();
            Destroy(this);
        }
    }
}
