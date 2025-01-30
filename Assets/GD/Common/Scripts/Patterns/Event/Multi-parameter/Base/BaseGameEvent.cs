using GD.Types;
using System.Collections.Generic;
using UnityEngine;

namespace GD.Events
{
    /// <summary>
    /// Abstract base class representing a generic game event.
    /// Allows events to carry data of type T to all listeners.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseGameEvent<T> : ScriptableGameObject
    {
        // List of listeners that are registered to this event.
        private List<BaseGameEventListener<T>> listeners = new List<BaseGameEventListener<T>>();

        // Raises the event, notifying all registered listeners with the given data.
        [ContextMenu("Raise Event")]
        public virtual void Raise(T data)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised(data);
            }
        }

        // Registers a listener to this event.
        public void RegisterListener(BaseGameEventListener<T> listener)
        {
            if (!listeners.Contains(listener))
                listeners.Add(listener);
        }

        // Unregisters a listener from this event.
        public void UnregisterListener(BaseGameEventListener<T> listener)
        {
            if (listeners.Contains(listener))
                listeners.Remove(listener);
        }
    }
}