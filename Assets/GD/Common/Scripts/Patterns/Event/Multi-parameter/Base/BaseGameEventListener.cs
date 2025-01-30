using UnityEngine;
using UnityEngine.Events;

namespace GD.Events
{
    /// <summary>
    /// Generic listener class that listens for events of type T.
    /// Listens for events raised by BaseGameEvent<T> and responds using UnityEvent<T>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <see cref="BaseGameEvent{T}"/>
    public class BaseGameEventListener<T> : MonoBehaviour
    {
        // Description of the listener for easy identification in the Unity Editor.
        [SerializeField]
        private string description;

        // The game event that this listener subscribes to.
        [SerializeField]
        [Tooltip("Specify the game event (scriptable object) which will raise the event")]
        private BaseGameEvent<T> Event;

        // The UnityEvent response that will be invoked when the event is raised.
        [SerializeField]
        private UnityEvent<T> Response;

        private void Awake()
        {
            if (Event == null)
                throw new System.Exception("Game Event is not set in BaseGameEventListener");
        }

        // Register the listener with the event when enabled.
        private void OnEnable() => Event.RegisterListener(this);

        // Unregister the listener from the event when disabled.
        private void OnDisable() => Event.UnregisterListener(this);

        // Called when the event is raised, invoking the response.
        public virtual void OnEventRaised(T data) => Response?.Invoke(data);
    }
}