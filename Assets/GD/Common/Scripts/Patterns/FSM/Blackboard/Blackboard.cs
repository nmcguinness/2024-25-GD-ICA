using GD.Types;
using System.Collections.Generic;
using UnityEngine;

namespace GD.FSM
{
    [CreateAssetMenu(fileName = "Blackboard", menuName = "GD/FSM/Blackboard", order = 1)]
    public class Blackboard : ScriptableGameObject
    {
        public int XP = 1;
        public int Health = 100;
        public List<Transform> waypoints = new();

        private Dictionary<string, object> data = new();

        public void SetValue<T>(string key, T value) => data[key] = value;

        public T GetValue<T>(string key) => data.TryGetValue(key, out var value)
            && value is T typedValue ? typedValue : default;

        /*
        public T GetValue<T>(string key)
        {
            return (T)data[key];
        }
        */

        public bool HasValue(string key) => data.ContainsKey(key);

        public void Clear() => data.Clear();
    }
}