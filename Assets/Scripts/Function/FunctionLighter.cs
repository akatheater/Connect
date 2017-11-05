using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 自发光器
/// </summary>
[DisallowMultipleComponent]
public class FunctionLighter : Function
{
    [Header("【使发光器】")]
    [Header("板子种类")]
    [SerializeField]
    FunctionSelfLighter.BoardLightingType type;
    //static BoardLightingType dim = BoardLightingType.Dim;
    [SerializeField]
    [Header("亮度：")]
    //[ConditionalHide("type", "dim", false)]
    [Range(0, 1)]
    private float emissionRate;

    public Renderer[] target;

    private bool on = false;
    private void Start()
    {
        Shader s = Shader.Find("Standard");
        for (int i = 0; i < target.Length; i++)
        {
            if (!target[i].sharedMaterial.shader.Equals(s))
            {
                target[i].sharedMaterial.shader = s;
            }
            if (target[i].GetComponent<ColorChanger>() == null)
            {
                  target[i].gameObject.AddComponent<ColorChanger>();
            }
            if (type == FunctionSelfLighter.BoardLightingType.Dim)
            {
                target[i].GetComponent<ColorChanger>().ChangeToColor(targetColor());
                on = true;
            }
        }
    }
    protected override void function(PlayerController player)
    {
        for (int i = 0; i < target.Length; i++)
        {
            if (!on)
            {
                target[i].GetComponent<ColorChanger>().ChangeToColor(targetColor());
            }
            else
            {
                target[i].GetComponent<ColorChanger>().ResetColor();
            }
            if (type != FunctionSelfLighter.BoardLightingType.Bad)
            {
                Boom();
                Destroy(this);
            }
        }
        on = !on;
    }

    private Color targetColor()
    {
        return new Color(emissionRate, emissionRate, emissionRate);
    }
}
