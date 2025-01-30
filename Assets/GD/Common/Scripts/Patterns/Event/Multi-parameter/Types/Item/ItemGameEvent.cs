using GD.Items;
using UnityEngine;

namespace GD.Events
{
    /// <summary>
    /// Concrete implementation of BaseGameEvent that carries an int parameter.
    /// Used to create an integer-based event that can be raised and responded to.
    /// </summary>
    [CreateAssetMenu(fileName = "ItemGameEvent",
        menuName = "GD/Events/Params/Item",
        order = 4)]
    public class ItemGameEvent : BaseGameEvent<ItemData>
    { }
}