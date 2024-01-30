using System;

/// <summary>
/// Add an item to the cpmponent in the inspector window
/// <para>Methods that use this Attribute must have [Rect] parameter</para>
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class ComponentHeaderItemAttribute : Attribute
{
    public ComponentHeaderItemAttribute() { }
}
