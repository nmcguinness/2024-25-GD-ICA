using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

namespace GD.FSM.SO
{
    [CreateAssetMenu(fileName = "PatrolAction", menuName = "GD/FSM/Scriptable/Action/Patrol")]
    public class PatrolAction : ScriptableAnimatedAction
    {
        [SerializeField]
        private string waypointsKey = "Patrol";

        private int currentWaypointIndex = 0;
        private List<Transform> waypoints;

        public override void OnEnter(ScriptableStateController stateController)
        {
            base.OnEnter(stateController);

            if (waypoints == null)
            {
                if (!stateController.Blackboard.HasValue(waypointsKey))
                {
                    Debug.LogWarning($"No waypoints found in blackboard under key: {waypointsKey}");
                    return;
                }

                waypoints = stateController.Blackboard.GetValue<List<Transform>>(waypointsKey);
                if (waypoints == null || waypoints.Count == 0)
                {
                    Debug.LogWarning("Waypoint list is empty.");
                    return;
                }
            }

            MoveToNextWaypoint(stateController);
            PlayAnimation(stateController);
        }

        public override void OnUpdate(ScriptableStateController stateController)
        {
            base.OnUpdate(stateController);

            if (waypoints == null || waypoints.Count == 0)
                return;

            NavMeshAgent agent = stateController.Agent;
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
                MoveToNextWaypoint(stateController);
            }
        }

        private void MoveToNextWaypoint(ScriptableStateController stateController)
        {
            if (waypoints == null || waypoints.Count == 0)
                return;

            NavMeshAgent agent = stateController.Agent;
            if (agent == null)
            {
                Debug.LogError("NavMeshAgent not found on state controller.");
                return;
            }

            agent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }
}