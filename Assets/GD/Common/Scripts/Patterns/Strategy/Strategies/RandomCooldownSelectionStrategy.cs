using System.Collections.Generic;
using UnityEngine;

namespace GD.Patterns
{
    [CreateAssetMenu(fileName = "RandomCooldownSelectionStrategy", menuName = "GD/Selection Strategies/Random with Cooldown")]
    public class RandomCooldownSelectionStrategy : SelectionStrategy
    {
        [SerializeField, Min(1)]
        [Tooltip("The number of recent indices to remember (N). Memory size must be less than the list size and ideally 25%-50% list size.")]
        private int memorySize = 1;

        [SerializeField, Min(0)]
        [Tooltip("The cooldown period in seconds (M). Oldest item must be on recent selection list >= cooldownPeriod to be reselected.")]
        private float cooldownPeriod = 1f;

        /// <summary>
        /// Queue to hold the most recent selections along with their selection time.
        /// </summary>
        private Queue<SelectionRecord> recentSelections = new Queue<SelectionRecord>();

        private struct SelectionRecord
        {
            public int index;
            public float time;
        }

        public override int GetIndex<T>(List<T> list)
        {
            if (memorySize < 1)
                throw new System.Exception("Memory size must be at least 1.");

            if (memorySize > list.Count)
                throw new System.Exception("Memory size must be less than the list size and ideally 25%-50% list size.");

            if (list == null || list.Count == 0)
                return -1;

            float now = Time.time;

            // Remove expired records (those older than the cooldown period).
            while (recentSelections.Count > 0 && now - recentSelections.Peek().time >= cooldownPeriod)
            {
                recentSelections.Dequeue();
            }

            // Build a set of indices that are still in cooldown.
            HashSet<int> cooldownIndices = new HashSet<int>();
            foreach (var rec in recentSelections)
            {
                cooldownIndices.Add(rec.index);
            }

            // Gather candidates: indices not currently on cooldown.
            List<int> candidates = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (!cooldownIndices.Contains(i))
                    candidates.Add(i);
            }

            int selectedIndex;
            if (candidates.Count > 0)
            {
                // Choose randomly among indices not on cooldown.
                selectedIndex = candidates[Random.Range(0, candidates.Count)];
            }
            else
            {
                // All indices are on cooldown.
                // Check the oldest selection – if its cooldown hasn’t expired, we cannot re-select.
                if (recentSelections.Count > 0)
                {
                    var oldest = recentSelections.Peek();
                    if (now - oldest.time < cooldownPeriod)
                    {
                        // No index is eligible; return -1 to signal failure.
                        return -1;
                    }
                    else
                    {
                        // Should not occur because expired records were already removed.
                        selectedIndex = oldest.index;
                    }
                }
                else
                {
                    // Fallback (should not occur if recentSelections is maintained correctly).
                    selectedIndex = Random.Range(0, list.Count);
                }
            }

            // Record the new selection.
            recentSelections.Enqueue(new SelectionRecord { index = selectedIndex, time = now });
            // Limit the memory to the last N selections.
            if (recentSelections.Count > memorySize)
                recentSelections.Dequeue();

            return selectedIndex;
        }
    }
}