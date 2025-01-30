using System;
using UnityEngine;

/// <summary>
/// Specified a description as an attribute for a field, method, or class
/// </summary>
/// <see cref="EnumExtensions"/>
///<seealso cref="GD.Types.PriorityLevel"/>"/>
[AttributeUsage(AttributeTargets.All)]
public class DescriptionAttribute : PropertyAttribute
{
    #region Fields

    private string description;

    public static readonly DescriptionAttribute Default = new DescriptionAttribute();

    #endregion Fields

    #region Properties

    public string Description
    {
        get
        {
            return description;
        }
        set
        {
            description = value;
        }
    }

    #endregion Properties

    #region Constructors

    public DescriptionAttribute() : this(string.Empty)
    {
    }

    public DescriptionAttribute(string description)
    {
        this.description = description;
    }

    #endregion Constructors
}