using UnityEngine;

namespace GD.Events
{
    /// <summary>
    /// A group of events that are triggered when a change occurs in a collection e.g. List, Dictionary
    /// </summary>
    /// <see cref="FSM.Blackboard"/>
    [System.Serializable]
    public class GameEventCollectionGroup
    {
        [Tooltip("Event triggered when an item is added")]
        public GameEvent onAdded;

        [Tooltip("Event triggered when an item is updated")]
        public GameEvent onUpdated;

        [Tooltip("Event triggered when an item is removed")]
        public GameEvent onRemoved;
    }
}