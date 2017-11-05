using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property |
    AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
public class ConditionalHideAttribute : PropertyAttribute
{
    //The name of the bool field that will be in control
    public string ConditionalSourceField = "";
    public string ConditionalSourceField2 = "";
    //TRUE = Hide in inspector / FALSE = Disable in inspector 
    public bool HideInInspector = true;

    public bool State = true;

    public bool con2exist = false;

    public ConditionalHideAttribute(string conditionalSourceField)
    {
        this.ConditionalSourceField = conditionalSourceField;
        this.HideInInspector = true;
    }

    public ConditionalHideAttribute(string conditionalSourceField, bool hideInInspector)
    {
        this.ConditionalSourceField = conditionalSourceField;
        this.HideInInspector = hideInInspector;
    }

    public ConditionalHideAttribute(string conditionalSourceField, bool hideInInspector, bool state)
    {
        this.ConditionalSourceField = conditionalSourceField;
        this.HideInInspector = hideInInspector;
        this.State = state;
    }
    public ConditionalHideAttribute(string conditionalSourceField, string conditionalSourceField2, bool hideInInspector)
    {
        this.ConditionalSourceField = conditionalSourceField;
        this.ConditionalSourceField2 = conditionalSourceField2; con2exist = true;
        this.HideInInspector = hideInInspector;
    }
}