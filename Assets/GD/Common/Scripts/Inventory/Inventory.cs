using GD.Events;
using GD.Types;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GD.Items
{
    /// <summary>
    /// Stores the amount of each object of type ItemData in the inventory.
    /// Think of an inventory like a pocket in a larger bag (or InventoryCollection).
    /// </summary>
    /// <see cref="ItemData"/>
    /// <see cref="InventoryCollection"/>
    [CreateAssetMenu(fileName = "Inventory",
        menuName = "GD/Inventory/Inventory")]
    public class Inventory : SerializedScriptableObject, IEnumerable<KeyValuePair<ItemData, int>>
    {
        #region Fields

        [SerializeField]
        [Tooltip("The items in the inventory and their counts.")]
        private Dictionary<ItemData, int> contents = new Dictionary<ItemData, int>();

        [FoldoutGroup("Events")]
        [SerializeField]
        [Tooltip("Event to raise when the inventory changes.")]
        private GameEvent onInventoryChange;

        [FoldoutGroup("Events")]
        [SerializeField]
        [Tooltip("Event to raise when the inventory is cleared.")]
        private GameEvent onInventoryClear;

        #endregion Fields

        #region Properties

        public int this[ItemData itemData]
        {
            get
            {
                return contents[itemData];
            }
        }

        #endregion Properties

        /// <summary>
        /// Adds the specified amount of list to the inventory.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="count"></param>
        public void Add(ItemData item, int count)
        {
            if (contents.ContainsKey(item))
                contents[item] += count;
            else
                contents.Add(item, count);

            onInventoryChange?.Raise(); //tell interested parties that the inventory has changed
        }

        /// <summary>
        /// Removes the specified amount of list from the inventory.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int Remove(ItemData item, int count)
        {
            int remaining = 0;

            if (contents.ContainsKey(item))
            {
                if (contents[item] > count)
                {
                    contents[item] -= count;
                    remaining = contents[item];
                }
                else
                {
                    contents.Remove(item);
                }
                onInventoryChange?.Raise(); //tell interested parties that the inventory has changed
            }
            return remaining;
        }

        /// <summary>
        /// Gets the count of the specified item in the inventory.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int Count(ItemData item)
        {
            if (contents.ContainsKey(item))
                return contents[item];
            return 0;
        }

        /// <summary>
        /// Returns true if the inventory contains the specified item.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(ItemData item)
        {
            return contents.ContainsKey(item);
        }

        /// <summary>
        /// Removes all list from the inventory.
        /// </summary>
        /// <returns></returns>
        public bool Clear()
        {
            contents.Clear();
            onInventoryClear?.Raise();
            onInventoryChange?.Raise();
            return contents.Count == 0;
        }

        [ContextMenu("Raise OnChange")]
        public void RaiseOnChange()
        {
            onInventoryChange?.Raise();
        }

        #region Methods - IEnumerable Implementation

        public IEnumerator<KeyValuePair<ItemData, int>> GetEnumerator()
        {
            return contents.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion Methods - IEnumerable Implementation
    }
}