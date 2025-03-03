using GD.Types;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GD.Items
{
    [System.Serializable]
    public struct Buff
    {
        public BuffType type;

        [Range(-100, 100)]
        public int amount;
    }

    [CreateAssetMenu(fileName = "WaypointData", menuName = "GD/Data/Waypoint")]
    public class WaypointData : ScriptableGameObject
    {
        [FoldoutGroup("Type & Priority", expanded: true)]
        [SerializeField] private WaypointType waypointType = WaypointType.Patrol;

        [FoldoutGroup("Type & Priority")]
        [SerializeField] private PriorityLevel priorityLevel = PriorityLevel.Highest;

        public WaypointType WaypointType => waypointType;
        public PriorityLevel PriorityLevel => priorityLevel;
    }
}