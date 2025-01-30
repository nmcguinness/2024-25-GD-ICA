using UnityEngine;

namespace GD.Items
{
    /// <summary>
    /// Items that implement this interface can be consumed by the player.
    /// </summary>
    public interface IConsumable
    {
        void Consume(GameObject consumer);
    }
}