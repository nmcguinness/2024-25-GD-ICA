using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using GD.Items;

namespace GD.UI
{
    public class UIInventoryManager : MonoBehaviour
    {
        #region Fields

        [SerializeField]
        [Tooltip("Title of the inventory panel")]
        [TextArea(2, 4)]
        private string description;

        [SerializeField]
        [Tooltip("Inventory to display for this ui panel")]
        private Inventory inventory;

        [SerializeField]
        [Tooltip("Panel to display inventory items in")]
        private Transform itemUIPanel;

        [SerializeField]
        [Tooltip("Prefab for inventory item UI")]
        private GameObject itemUIPrefab;

        #endregion Fields

        #region Fields - Internal

        private Dictionary<ItemData, GameObject> itemUIDictionary = new Dictionary<ItemData, GameObject>();

        #endregion Fields - Internal

        #region Methods

        private void Start()
        {
            if (inventory == null)
                throw new System.Exception("Inventory is not set in UIInventoryManager");
            if (itemUIPanel == null)
                throw new System.Exception("ItemUIPanel is not set in UIInventoryManager");
            if (itemUIPrefab == null)
                throw new System.Exception("ItemUIPrefab is not set in UIInventoryManager");

            InitializeUI();
        }

        private void InitializeUI()
        {
            foreach (var itemEntry in inventory)
            {
                CreateOrUpdate(itemEntry.Key, itemEntry.Value);
            }
        }

        private void CreateOrUpdate(ItemData itemData, int count)
        {
            if (!itemUIDictionary.TryGetValue(itemData, out var itemUI))
            {
                itemUI = Instantiate(itemUIPrefab, itemUIPanel);
                itemUI.SetActive(true);
                itemUI.GetComponentInChildren<Image>().sprite = itemData.UiIcon;
                itemUIDictionary[itemData] = itemUI;
            }

            var countText = itemUI.GetComponentInChildren<TextMeshProUGUI>();
            countText.text = count.ToString();
        }

        /// <summary>
        /// Called when the inventory changes
        /// </summary>
        /// We could solve the update problem with
        /// 1. UpdateState
        /// 2. HandleTicks (i.e, 0.1, 0.2, 0.4, 0.8)
        /// 3. Persistent polling ("have you changed?")
        /// 4. Event-driven ("I'll tell you when I change")
        public void OnInventoryChange()
        {
            foreach (var itemEntry in inventory)
            {
                CreateOrUpdate(itemEntry.Key, itemEntry.Value);
            }
        }

        #endregion Methods
    }
}