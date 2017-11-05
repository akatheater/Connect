using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 自发光器
/// </summary>
[DisallowMultipleComponent]
[RequireComponent(typeof(ColorChanger))]
public class FunctionSelfLighter : Function {
    enum BoardLightingType
    {
        Dim, Bright, Bad
    }
    private ColorChanger colorChanger;
    [Header("【板子发光器】")]
    [Header("板子种类")]
    [SerializeField]
    BoardLightingType type;
    static BoardLightingType dim = BoardLightingType.Dim;
    [SerializeField]
    [Header("亮度：")]
    [ConditionalHide("type", "dim", false)]
    //[Range(0, 1)]
    private float emissionRate;
    private bool on = false;

    private void Start()
    {
        colorChanger = GetComponent<ColorChanger>();
        Shader s = Shader.Find("Standard");
        if (!GetComponent<Renderer>().material.shader.Equals(s))
        {
            GetComponent<Renderer>().material.shader = s;
        }
        if (type == dim) emissionRate = 0;
    }
    protected override void function(PlayerController player)
    {
        if (!on)
        {
            colorChanger.ChangeToColor(targetColor());
            on = true;
            if (type != BoardLightingType.Bad) Destroy(this);
        }
        else
        {
            on = false;
            colorChanger.ResetColor();
        }
    }

    private Color targetColor()
    {
        return new Color(emissionRate, emissionRate, emissionRate);
    }
}
