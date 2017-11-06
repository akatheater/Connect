using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour {
    public static GameSystem settings;
    private void Awake()
    {
        settings = this;
        energy = origEner;
    }
    public static class InputKeys
    {
        public static bool Jump()
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
        public static bool Fly()
        {
            return Input.GetKey(KeyCode.Space);
        }
        public static bool Crouch()
        {
            return Input.GetKey(KeyCode.LeftControl);
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
        public static bool Switch()
        {
            return Input.GetKeyDown(KeyCode.Q);
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
    public static PlayerUp playerUp;
    public static int energy = 0;
    [Header("最大能量")]
    public int maxEnergy;
    public int origEner;
    public static void flushEnergy()
    {
        playerUp.energyRenderer.material.SetTexture("_EmissionMap", playerUp.energyTexture[energy]);
        playerUp.energy = energy;
    }
    public static void EnergyDown()
    {
        energy--;
        if (energy < 0) energy = 0;
        flushEnergy();
    }
    public static void EnergyUp()
    {
        energy++;
        if (energy > settings.maxEnergy) energy = settings.maxEnergy;
        flushEnergy();
    }
}
public delegate void BuffDelegate(PlayerController player);
//基本方向
public enum BasicDirection
{
    up, down, forward, back, left, right
}

