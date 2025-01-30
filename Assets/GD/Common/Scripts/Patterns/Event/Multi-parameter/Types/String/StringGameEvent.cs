using UnityEngine;

namespace GD.Events
{
    /// <summary>
    /// Concrete implementation of BaseGameEvent that carries a string parameter.
    /// Used to create a string-based event that can be raised and responded to.
    /// </summary>
    [CreateAssetMenu(fileName = "StringGameEvent",
    menuName = "GD/Events/Params/String",
        order = 3)]
    public class StringGameEvent : BaseGameEvent<string>
    { }
}