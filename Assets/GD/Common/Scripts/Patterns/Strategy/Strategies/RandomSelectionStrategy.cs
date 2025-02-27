using System.Collections.Generic;
using UnityEngine;

namespace GD.Patterns
{
    [CreateAssetMenu(fileName = "RandomSelectionStrategy", menuName = "GD/Selection Strategies/Random")]
    public class RandomSelectionStrategy : SelectionStrategy
    {
        [SerializeField, ReadOnly]
        private int randomIndex;

        public override int GetIndex<T>(List<T> list)
        {
            if (list == null || list.Count == 0)
                return -1;
            randomIndex = Random.Range(0, list.Count);
            return randomIndex;
        }
    }
}