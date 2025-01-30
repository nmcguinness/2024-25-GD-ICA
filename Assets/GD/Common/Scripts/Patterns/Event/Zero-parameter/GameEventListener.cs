using UnityEngine;
using UnityEngine.Events;

namespace GD.Events
{
    /// <summary>
    /// Listens for a zero-parameter game event and invokes a response
    /// </summary>
    /// <see cref="GameEvent"/>
    [AddComponentMenu("GD/Events/Game Event Listener")]
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField]
        private string description;

        [SerializeField]
        [Tooltip("Specify the game event (scriptable object) which will raise the event")]
        private GameEvent Event;

        [SerializeField]
        private UnityEvent Response;

        private void Awake()
        {
            if (Event == null)
                throw new System.Exception("Game Event is not set in GameEventListener");
        }

        private void OnEnable() => Event.RegisterListener(this);

        private void OnDisable() => Event.UnregisterListener(this);

        public virtual void OnEventRaised() => Response?.Invoke();
    }
}