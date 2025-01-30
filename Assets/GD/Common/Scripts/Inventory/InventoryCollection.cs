using GD.Events;
using GD.Types;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GD.Items
{
    //TODO - Fix Add on new ItemCategoryType

    /// <summary>
    /// Stores a dictionary of inventories
    /// </summary>
    /// <see cref="Inventory"/>
    /// <see cref="InventoryManager"/>
    [CreateAssetMenu(fileName = "InventoryCollection",
        menuName = "GD/Inventory/Collection")]
    public class InventoryCollection : SerializedScriptableObject
    {
        #region Fields

        [SerializeField]
        [Tooltip("A dictionary of all inventores (e.g. a saddlebag")]
        private Dictionary<ItemCategoryType, Inventory> contents
    = new Dictionary<ItemCategoryType, Inventory>();

        [FoldoutGroup("Events")]
        [SerializeField]
        [Tooltip("Event to raise when the collection changes.")]
        private GameEvent onCollectionChange;

        [FoldoutGroup("Events")]
        [SerializeField]
        [Tooltip("Event to raise when the collection is emptied.")]
        private GameEvent onCollectionEmpty;

        #endregion Fields

        #region Properties

        public Inventory this[ItemCategoryType categoryType]
        {
            get
            {
                return contents[categoryType];
            }
        }

        #endregion Properties

        public Inventory Get(ItemCategoryType itemCategory)
        {
            if (!contents.ContainsKey(itemCategory))
                throw new NullReferenceException("No inventory for this item category");

            return contents[itemCategory];
        }

        //add a new inventory to the collection
        public void Add(ItemData itemData)
        {
            //if I never collected a Consumable
            if (!contents.ContainsKey(itemData.ItemCategory))
                throw new NullReferenceException("No inventory for this item category");

            //add 1 specific consumable (e.g. ItemData = Apple) to the inventory
            contents[itemData.ItemCategory].Add(itemData, 1);
            //TODO - add more than 1?

            //tell interested parties that the collection has changed
            onCollectionChange?.Raise();
        }

        /// <summary>
        /// Removes all inventories from the collection.
        /// </summary>
        /// <returns></returns>
        public bool Clear()
        {
            contents.Clear();
            onCollectionEmpty?.Raise();
            return contents.Count == 0;
        }
    }
}