using GD.Items;

namespace GD.Events
{
    /// <summary>
    /// Concrete implementation of BaseGameEventListener that listens for an integer-based event.
    /// Used to create a listener that can listen for ItemGameEvent events and respond to them.
    /// </summary>
    /// <see cref="ItemGameEvent"/>
    public class ItemGameEventListener : BaseGameEventListener<ItemData>
    { }
}