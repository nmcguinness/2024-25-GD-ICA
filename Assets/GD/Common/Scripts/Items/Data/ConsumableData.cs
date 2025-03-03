using Sirenix.OdinInspector;
using UnityEngine;

namespace GD.Items
{
    [CreateAssetMenu(fileName = "ConsumableData", menuName = "GD/Data/Consumable")]
    public class ConsumableData : ItemData
    {
        [FoldoutGroup("Effects", expanded: true)]
        [SerializeField] private Buff[] buffs;

        [FoldoutGroup("Expiration", expanded: true)]
        [SerializeField] private bool hasExpiration;

        [FoldoutGroup("Expiration")]
        [SerializeField] private float expirationTime;

        public Buff[] Buffs => buffs;
        public bool HasExpiration => hasExpiration;
        public float ExpirationTime => expirationTime;
    }
}