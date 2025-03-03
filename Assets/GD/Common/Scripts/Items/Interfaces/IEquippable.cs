using UnityEngine;

namespace GD.Items
{
    /// <summary>
    /// Items that implement this interface can be equipped by the player.
    /// </summary>
    public interface IEquippable
    {
        void Equip(GameObject equippee);
    }
}