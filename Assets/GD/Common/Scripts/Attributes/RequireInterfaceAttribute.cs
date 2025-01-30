using UnityEngine;

/// <summary>
/// Attribute that require implementation of the provided interface.
/// </summary>
/// <see cref="https://www.patrykgalach.com/2020/01/27/assigning-interface-in-unity-inspector/"/>
/// <seealso cref="https://www.youtube.com/watch?v=r3nwTGLHygI"/>
public class RequireInterfaceAttribute : PropertyAttribute
{
    // Interface type.
    public System.Type requiredType { get; private set; }

    /// <summary>
    /// Requiring implementation of the <see cref="T:RequireInterfaceAttribute"/> interface.
    /// </summary>
    /// <param name="type">Interface type.</param>
    public RequireInterfaceAttribute(System.Type type)
    {
        requiredType = type;
    }
}