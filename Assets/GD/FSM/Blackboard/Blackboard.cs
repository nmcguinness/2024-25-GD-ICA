using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace GD.FSM
{
    [CreateAssetMenu(fileName = "Blackboard", menuName = "Scriptable Objects/Blackboard")]
    public class Blackboard : ScriptableObject
    {
        private Dictionary<string, object> data = new();

        public void SetValue<T>(string key, T value) => data[key] = value;

        public T GetValue<T>(string key) => data.TryGetValue(key, out var value)
            && value is T typedValue ? typedValue : default;

        public bool HasValue(string key) => data.ContainsKey(key);

        public void Clear() => data.Clear();

        /*
        public T GetValue<T>(string key)
        {
            return (T)data[key];
        }
        */
    }
}