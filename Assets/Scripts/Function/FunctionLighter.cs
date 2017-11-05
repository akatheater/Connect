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

    [Header("贴图")]
    public Texture tex;

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
            target[i].sharedMaterial.SetTexture("_EmissionMap", tex);
            if (target[i].GetComponent<ColorChanger>() == null)
                target[i].gameObject.AddComponent<ColorChanger>();
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
                on = true;
            }
            else
            {
                on = false;
                target[i].GetComponent<ColorChanger>().ResetColor();
            }
            if (type != FunctionSelfLighter.BoardLightingType.Bad)
            {
                Boom();
                Destroy(this);
            }
        }
    }

    private Color targetColor()
    {
        return new Color(emissionRate, emissionRate, emissionRate);
    }
}
