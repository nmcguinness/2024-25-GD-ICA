using GD.Events;
using GD.Types;
using UnityEngine;

namespace GD.FSM
{
    [CreateAssetMenu(fileName = "Blackboard", menuName = "GD/FSM/Blackboard", order = 1)]
    public class Blackboard : ScriptableGameObject
    {
        [SerializeField]
        private SerializableDictionary data = new();

        //public int XP = 1;
        //public int Health = 100;
        //public List<Transform> waypoints = new();

        [SerializeField]
        [Tooltip("Events to trigger when a value is added, updated, or changed")]
        private GameEventCollectionGroup onChange;

        #region Get, Set, Remove, Has, Clear

        public void SetValue<T>(string key, T value)
        {
            bool exists = data.ContainsKey(key);
            data[key] = value;

            if (exists)
                onChange?.onUpdated?.Raise();
            else
                onChange?.onAdded?.Raise();
        }

        public T GetValue<T>(string key) => data.TryGetValue(key, out var value)
            && value is T typedValue ? typedValue : default;

        public void RemoveValue(string key)
        {
            if (data.Remove(key))
            {
                onChange?.onRemoved?.Raise();
            }
        }

        public bool HasValue(string key) => data.ContainsKey(key);

        public void Clear() => data.Clear();

        #endregion Get, Set, Remove, Has, Clear
    }
}