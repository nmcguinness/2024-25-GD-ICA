using GD.Types;
using UnityEngine;

namespace GD.Items
{
    public abstract class BaseItemData : ScriptableGameObject
    {
        [SerializeField] private ItemCategoryType itemCategory;
        [SerializeField] private ItemType itemType;

        public ItemCategoryType ItemCategory => itemCategory;
        public ItemType ItemType => itemType;
    }
}