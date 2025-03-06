using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GD.FSM.SO
{
    [CreateAssetMenu(fileName = "PatrolAction", menuName = "GD/FSM/Scriptable/Action/Patrol")]
    public class PatrolAction : ScriptableAnimatedAction
    {
        [SerializeField]
        private string waypointsKey = "Patrol";

        [FoldoutGroup("Debug Info", expanded: false)]
        [ShowInInspector, ReadOnly]
        private List<Transform> waypoints;

        [FoldoutGroup("Debug Info")]
        [ShowInInspector, ReadOnly]
        private int currentIndex = 0;

        public override void Initialize(ScriptableStateController stateController)
        {
            base.Initialize(stateController);

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

        public override void OnEnter(ScriptableStateController stateController)
        {
            base.OnEnter(stateController);
            PlayAnimation(stateController);
            MoveToNextWaypoint(stateController);
        }

        public override void OnUpdate(ScriptableStateController stateController)
        {
            base.OnUpdate(stateController);

            NavMeshAgent agent = stateController.Agent;
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                MoveToNextWaypoint(stateController);
            }
        }

        private void MoveToNextWaypoint(ScriptableStateController stateController)
        {
            if (currentIndex >= 0 && currentIndex < waypoints.Count)
            {
                stateController.Agent.SetDestination(waypoints[currentIndex].position);

                currentIndex = (currentIndex + 1) % waypoints.Count;
            }
        }
    }
}