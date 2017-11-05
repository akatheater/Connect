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
    //static BoardLightingType dim = BoardLightingType.Dim;
    [SerializeField]
    [Header("亮度：")]
    //[ConditionalHide("type", "dim", false)]
    [Range(0, 1)]
    private float emissionRate;

    [Header("贴图")]
    public Texture tex;

    private bool on = false;

    private void Reset()
    {
        Shader s = Shader.Find("Standard");
        if (!GetComponent<Renderer>().sharedMaterial.shader.Equals(s))
        {
            GetComponent<Renderer>().sharedMaterial.shader = s;
        }
        GetComponent<Renderer>().sharedMaterial.SetTexture("_EmissionMap", tex);
    }
    private void Start()
    {
        colorChanger = GetComponent<ColorChanger>();
        if (type == BoardLightingType.Dim)
        {
            colorChanger.ChangeToColor(targetColor());
            on = true;
        }
    }
    protected override void function(PlayerController player)
    {
        if (!on)
        {
            colorChanger.ChangeToColor(targetColor());
            on = true;
        }
        else
        {
            on = false;
            colorChanger.ResetColor();
        }
        if (type != BoardLightingType.Bad)
        {
            Boom();
            Destroy(this);
        }
    }

    private Color targetColor()
    {
        return new Color(emissionRate, emissionRate, emissionRate);
    }
}
