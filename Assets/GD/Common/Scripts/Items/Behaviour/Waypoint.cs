using GD.Data;
using GD.Events;
using GD.FSM;
using GD.Items;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace GD.Behaviour
{
    [DefaultExecutionOrder(-100)]
    public class Waypoint : MonoBehaviour, IVisitable
    {
        [SerializeField]
        [FoldoutGroup("Data", expanded: true)]
        [Tooltip("The waypoint data")]
        private WaypointData waypointData;

        [FoldoutGroup("Data")]
        [SerializeField] private Blackboard blackboard;

        [SerializeField]
        [FoldoutGroup("Event & Layer", expanded: true)]
        [Tooltip("The event that is raised when this waypoint is visited")]
        private WaypointGameEvent onVisit;

        [SerializeField]
        [FoldoutGroup("Event & Layer")]
        [Tooltip("The layer that can interact with this waypoint")]
        private LayerMask targetLayer;

        private void Awake()
        {
            RegisterWaypoint();
        }

        private void OnEnable()
        {
            RegisterWaypoint();
        }

        private void OnDisable()
        {
            UnregisterWaypoint();
        }

        private void OnDestroy()
        {
            UnregisterWaypoint();
        }

        /// <summary>
        /// Registers this waypoint's transform in the Blackboard under each applicable WaypointType.
        /// </summary>
        private void RegisterWaypoint()
        {
            if (blackboard == null)
            {
                Debug.LogWarning($"Waypoint {gameObject.name} has no assigned blackboard!");
                return;
            }

            string key = waypointData.WaypointType.ToString();
            List<Transform> waypointsList;

            // Get or create the list for this waypoint type
            if (blackboard.HasValue(key))
            {
                waypointsList = blackboard.GetValue<List<Transform>>(key);
            }
            else
            {
                waypointsList = new List<Transform>();
                blackboard.SetValue(key, waypointsList);
            }

            // Check if the transform already exists before adding
            if (!waypointsList.Contains(transform))
            {
                waypointsList.Add(transform);
                blackboard.SetValue(key, waypointsList);
            }
        }

        /// <summary>
        /// Unregisters this waypoint's transform from the Blackboard when destroyed or disabled.
        /// </summary>
        private void UnregisterWaypoint()
        {
            if (blackboard == null)
            {
                Debug.LogWarning($"Waypoint {gameObject.name} has no assigned blackboard!");
                return;
            }

            string key = waypointData.WaypointType.ToString();

            if (blackboard.HasValue(key))
            {
                List<Transform> waypointsList = blackboard.GetValue<List<Transform>>(key);

                if (waypointsList != null)
                {
                    waypointsList.Remove(transform);

                    // Clean up empty lists
                    if (waypointsList.Count != 0)
                        blackboard.SetValue(key, waypointsList);
                    else
                        blackboard.RemoveValue(key);
                }
            }
        }

        public void Visit(GameObject visitor)
        {
            if (targetLayer.OnLayer(visitor))
            {
                onVisit?.Raise(waypointData);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Visit(other.gameObject);
        }
    }
}