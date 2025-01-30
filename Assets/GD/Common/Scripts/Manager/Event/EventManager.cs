using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GD
{
    /// <summary>
    /// Immutable event context that stores event parameters, the event sender, delay, and repeat count.
    /// </summary>
    public class EventContext
    {
        private readonly Dictionary<Type, object> data = new Dictionary<Type, object>();
        public object Sender { get; }
        public int DelayMs { get; }
        public int RepeatCount { get; }
        public const int MinDelayMs = 50; // Minimum delay in milliseconds to prevent event flooding

        /// <summary>
        /// Initializes a new event context with a sender and additional parameters.
        /// </summary>
        public EventContext(object sender, params (Type type, object value)[] values)
            : this(sender, 0, 1, values)
        {
        }

        /// <summary>
        /// Initializes a new event context with a sender, delay, repeat count, and additional parameters.
        /// </summary>
        public EventContext(object sender, int delayMs, int repeatCount, params (Type type, object value)[] values)
        {
            Sender = sender ?? throw new ArgumentNullException(nameof(sender));
            DelayMs = Math.Max(delayMs, MinDelayMs); // Ensure minimum delay constraint
            RepeatCount = repeatCount;

            foreach (var (type, value) in values)
            {
                if (value != null)
                    data[type] = value;
            }
        }

        /// <summary>
        /// Retrieves a value of the specified type from the event context.
        /// </summary>
        public T Get<T>()
        {
            if (data.TryGetValue(typeof(T), out object value))
                return (T)value;
            throw new Exception($"EventContext does not contain a value of type {typeof(T)}");
        }

        /// <summary>
        /// Checks if the context contains a value of the specified type.
        /// </summary>
        public bool Contains<T>() => data.ContainsKey(typeof(T));
    }

    /// <summary>
    /// Centralized event manager that supports wildcard subscriptions, event queuing, delayed execution, and automatic removal of destroyed objects.
    /// <example>
    ///   Example 1: Broadcasting and Listening for a Game State Change
    ///     void OnEnable() {
    ///         EventManager.Instance.RegisterListener("GameStateChanged", OnGameStateChanged);
    ///     }
    ///     void OnDisable() {
    ///         EventManager.Instance.UnregisterListener("GameStateChanged", OnGameStateChanged);
    ///     }
    ///     void OnGameStateChanged(EventContext context) {
    ///         GameState state = context.Get<GameState>();
    ///         Debug.Log("Game state changed to: " + state);
    ///     }
    ///     EventManager.Instance.RaiseEvent("GameStateChanged", new EventContext(
    ///         sender: this, delayMs: 0, repeatCount: 1, (typeof(GameState), GameState.Won)));
    ///
    ///  Example 2: Broadcasting and Listening for an Item Pickup Event
    ///     void OnEnable() {
    ///         EventManager.Instance.RegisterListener("ItemPickedUp", OnItemPickedUp);
    ///     }
    ///     void OnDisable() {
    ///         EventManager.Instance.UnregisterListener("ItemPickedUp", OnItemPickedUp);
    ///     }
    ///     void OnItemPickedUp(EventContext context) {
    ///         string itemName = context.Get<string>();
    ///         int quantity = context.Get<int>();
    ///         Debug.Log("Picked up: " + itemName + " x" + quantity);
    ///     }
    ///     EventManager.Instance.RaiseEvent("ItemPickedUp", new EventContext(
    ///         sender: this, delayMs: 0, repeatCount: 1, (typeof(string), "Health Potion"), (typeof(int), 1)));
    /// </example>

    public class EventManager : Singleton<EventManager>
    {
        private Dictionary<string, List<Action<EventContext>>> eventDictionary = new Dictionary<string, List<Action<EventContext>>>();
        private Queue<(string eventName, EventContext eventData)> eventQueue = new Queue<(string, EventContext)>();

        /// <summary>
        /// Registers a listener for a named event, supporting wildcard patterns.
        /// </summary>
        public void RegisterListener(string eventPattern, Action<EventContext> listener)
        {
            eventPattern = eventPattern.TrimEnd('*');
            if (!eventDictionary.ContainsKey(eventPattern))
                eventDictionary[eventPattern] = new List<Action<EventContext>>();
            if (!eventDictionary[eventPattern].Contains(listener))
                eventDictionary[eventPattern].Add(listener);
        }

        /// <summary>
        /// Unregisters a listener from a specific event.
        /// </summary>
        public void UnregisterListener(string eventName, Action<EventContext> listener)
        {
            if (eventDictionary.TryGetValue(eventName, out var listeners))
            {
                listeners.Remove(listener);
                if (listeners.Count == 0)
                    eventDictionary.Remove(eventName);
            }
        }

        /// <summary>
        /// Queues an event to be processed in the next update cycle.
        /// </summary>
        public void QueueEvent(string eventName, EventContext eventData)
        {
            eventQueue.Enqueue((eventName, eventData));
        }

        /// <summary>
        /// Schedules an event to occur after a delay and optionally repeat.
        /// </summary>
        public async void ScheduleEvent(string eventName, EventContext eventData)
        {
            await ExecuteDelayedEvent(eventName, eventData);
        }

        /// <summary>
        /// Executes a delayed event based on the context's delay and repeat count.
        /// </summary>
        private async Task<Task> ExecuteDelayedEvent(string eventName, EventContext eventData)
        {
            for (int i = 0; i < eventData.RepeatCount; i++)
            {
                await Task.Delay(eventData.DelayMs);
                RaiseEvent(eventName, eventData);
            }
            return Task.CompletedTask; // Ensures all code paths return a value
        }

        /// <summary>
        /// Processes queued events.
        /// </summary>
        private void Update()
        {
            while (eventQueue.Count > 0)
            {
                var (eventName, eventData) = eventQueue.Dequeue();
                RaiseEvent(eventName, eventData);
            }
        }

        /// <summary>
        /// Raises an event, notifying all relevant listeners.
        /// </summary>
        public void RaiseEvent(string eventName, EventContext eventData)
        {
            foreach (var key in eventDictionary.Keys)
            {
                if (eventName.StartsWith(key))
                {
                    List<Action<EventContext>> toRemove = new List<Action<EventContext>>();

                    foreach (var listener in eventDictionary[key])
                    {
                        if (listener.Target is UnityEngine.Object obj && obj == null)
                        {
                            toRemove.Add(listener);
                        }
                        else
                        {
                            listener.Invoke(eventData);
                        }
                    }

                    foreach (var deadListener in toRemove)
                        eventDictionary[key].Remove(deadListener);
                }
            }
        }
    }
}