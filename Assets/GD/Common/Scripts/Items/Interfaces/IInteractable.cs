using UnityEngine;

namespace GD.Items
{
    /// <summary>
    /// Items implementing this interface can be interacted with by other objects.
    /// </summary>
    public interface IInteractable
    {
        void Interact(GameObject interactor);
    }
}