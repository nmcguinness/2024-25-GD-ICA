using System.Collections.Generic;
using UnityEngine;

namespace GD.Patterns
{
    [CreateAssetMenu(fileName = "SequentialSelectionStrategy", menuName = "GD/Selection Strategies/Sequential")]
    public class SequentialSelectionStrategy : SelectionStrategy
    {
        [SerializeField, Min(0)]
        private int currentIndex = 0;

        public override int GetIndex<T>(List<T> list)
        {
            if (list == null || list.Count == 0)
                return -1;

            int index = currentIndex;
            currentIndex = (currentIndex + 1) % list.Count;
            return index;
        }
    }
}