using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GD.FSM
{
    public class PatrolState : FSMCharacterState
    {
        private int WalkHash = Animator.StringToHash("Walk_N");
        private NavMeshAgent agent;
        private List<Transform> waypoints;
        private int currentWaypointIndex = 0;

        public PatrolState(Blackboard blackboard,
            FSMCharacterController characterController, Animator animator,
            NavMeshAgent agent)
            : base(blackboard, characterController, animator)
        {
            this.agent = agent;
        }

        public override void OnEnter()
        {
            animator.CrossFade(WalkHash, 0.1f);
            base.OnEnter();

            // Get waypoint
            GetWaypoints();

            // Set the destination
            SetWaypoint();
        }

        private void SetWaypoint()
        {
            if (waypoints == null || waypoints.Count == 0)
                throw new System.Exception("No waypoints found in blackboard - check key name");
            agent.SetDestination(waypoints[currentWaypointIndex].position);
            // Next waypoint and loop
            currentWaypointIndex++;
            currentWaypointIndex %= waypoints.Count;
        }

        private void GetWaypoints()
        {
            waypoints = blackboard.waypoints;
        }

        public override void Update()
        {
            // Am I there yet? If yes, get next
            if (!agent.hasPath && agent.remainingDistance < agent.stoppingDistance)
                SetWaypoint();
        }
    }
}