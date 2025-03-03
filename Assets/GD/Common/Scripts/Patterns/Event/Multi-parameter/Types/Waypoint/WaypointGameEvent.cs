using GD.Items;
using UnityEngine;

namespace GD.Events
{
    /// <summary>
    /// Concrete implementation of BaseGameEvent that carries a WaypointData parameter.
    /// Used to create an WaypointData-based event that can be raised and responded to.
    /// </summary>
    [CreateAssetMenu(fileName = "WaypointGameEvent",
        menuName = "GD/Events/Params/Waypoint",
        order = 5)]
    public class WaypointGameEvent : BaseGameEvent<WaypointData>
    { }
}