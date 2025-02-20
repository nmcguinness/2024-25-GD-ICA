using GD.Items;
using UnityEngine;

namespace GD.GameState
{
    /// <summary>
    /// Store reference to entities/objects that the conditions need to check against.
    /// </summary>
    public class ConditionContext
    {
        // Used by the conditions to get the current state of the inventory
        private InventoryCollection inventoryCollection;

        // Used by the conditions to get the current state of the game object
        private GameObject gameObject;

        public InventoryCollection InventoryCollection { get => inventoryCollection; set => inventoryCollection = value; }
        public GameObject GameObject { get => gameObject; set => gameObject = value; }

        // Add other context dependencies here

        public ConditionContext(InventoryCollection inventoryCollection, GameObject gameObject)
        {
            InventoryCollection = inventoryCollection;
            GameObject = gameObject;
        }

        public ConditionContext(InventoryCollection inventoryCollection)
            : this(inventoryCollection, null)
        {
        }

        public ConditionContext(GameObject gameObject)
            : this(null, gameObject)
        {
        }
    }
}