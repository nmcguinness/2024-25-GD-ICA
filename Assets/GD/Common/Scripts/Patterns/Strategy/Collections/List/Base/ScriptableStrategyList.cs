using GD.Patterns;
using System;
using UnityEngine;

namespace GD.Collections
{
    //Note - We cannot directly instantiate a GENERIC ScriptableObject from the Context Menu - see RuntimeStringList
    [Serializable]
    public abstract class ScriptableStrategyList<T> : ScriptableList<T>
    {
        /// <summary>
        /// Returns an item from the list using the given selection strategy.
        /// </summary>
        public T GetItem(SelectionStrategy strategy)
        {
            if (strategy == null)
            {
                Debug.LogWarning($"{nameof(GetItem)}: Selection strategy is null.");
                return default;
            }
            if (list == null || list.Count == 0)
            {
                Debug.LogWarning($"{nameof(GetItem)}: The list is empty.");
                return default;
            }

            int index = strategy.GetIndex(list);
            if (index >= 0 && index < list.Count)
            {
                return list[index];
            }
            else
            {
                Debug.LogWarning($"{nameof(GetItem)}: Strategy returned an invalid index {index}.");
                return default;
            }
        }

        /// <summary>
        /// Tries to get an item from the list using the given selection strategy.
        /// Returns true if successful, false otherwise.
        /// </summary>
        public bool TryGetItem(SelectionStrategy strategy, out T result)
        {
            result = default;
            if (strategy == null || list == null || list.Count == 0)
            {
                return false;
            }

            int index = strategy.GetIndex(list);
            if (index >= 0 && index < list.Count)
            {
                result = list[index];
                return true;
            }
            return false;
        }
    }
}