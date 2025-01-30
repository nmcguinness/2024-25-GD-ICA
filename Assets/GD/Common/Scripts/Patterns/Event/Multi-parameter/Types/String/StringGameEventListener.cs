using UnityEngine;

namespace GD.Events
{
    /// <summary>
    /// Concrete implementation of BaseGameEventListener that listens for StringGameEvent.
    /// Listens for events that carry a string parameter and responds accordingly.
    /// </summary>
    /// <see cref="StringGameEvent"/>
    [AddComponentMenu("GD/Events/String Event Listener")]
    public class StringGameEventListener
        : BaseGameEventListener<string>
    { }
}