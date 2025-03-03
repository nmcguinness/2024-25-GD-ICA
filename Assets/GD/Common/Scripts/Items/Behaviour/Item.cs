using GD.Events;
using UnityEngine;

namespace GD.Items
{
    /// <summary>
    /// Represents an item that can be picked up and used.
    /// </summary>
    public class Item : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The base item data that represents this item")]
        private BaseItemData itemData;

        [SerializeField]
        [Tooltip("The event that is raised when this item is used or consumed")]
        private ItemGameEvent onItemEvent;

        [SerializeField]
        [Tooltip("The layer that can interact with this item")]
        private LayerMask targetLayer;

        private void OnTriggerEnter(Collider other)
        {
            if (targetLayer.OnLayer(other.gameObject))
            {
                if (itemData is IConsumable consumable)
                {
                    consumable.Consume(other.gameObject);
                }
                else if (itemData is IEquippable equippable)
                {
                    equippable.Equip(other.gameObject);
                }

                // Raise event
                onItemEvent?.Raise(itemData);

                // Remove item from the scene
                Destroy(gameObject);
            }
        }
    }
}