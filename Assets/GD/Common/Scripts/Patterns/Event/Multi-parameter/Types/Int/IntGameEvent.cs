using UnityEngine;

namespace GD.Events
{
    /// <summary>
    /// Concrete implementation of BaseGameEvent that carries an int parameter.
    /// Used to create an integer-based event that can be raised and responded to.
    /// </summary>
    [CreateAssetMenu(fileName = "IntGameEvent",
        menuName = "GD/Events/Params/Int",
        order = 2)]
    public class IntGameEvent : BaseGameEvent<int>
    { }
}