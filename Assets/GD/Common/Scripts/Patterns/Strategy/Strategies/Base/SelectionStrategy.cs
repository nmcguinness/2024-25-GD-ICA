using GD.Types;
using System;
using System.Collections.Generic;

namespace GD.Patterns
{
    [Serializable]
    public abstract class SelectionStrategy : ScriptableGameObject
    {
        /// <summary>
        /// Returns an index based on the given selection strategy.
        /// </summary>
        /// <typeparam name="T">The type of the list elements.</typeparam>
        /// <param name="list">The list from which to select.</param>
        /// <returns>The index of the selected element, or -1 if the list is empty.</returns>
        public abstract int GetIndex<T>(List<T> list);

        public virtual T GetItem<T>(List<T> list)
        {
            return list[GetIndex(list)];
        }
    }
}