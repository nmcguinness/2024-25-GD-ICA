using GD.Types;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GD.FSM.Simple
{
    public class PatrolState : State
    {
        private int WalkHash;
        private NavMeshAgent agent;
        private List<Transform> waypoints;
        private int currentWaypointIndex = 0;

        public PatrolState(Blackboard blackboard,
            StateController characterController, Animator animator,
            NavMeshAgent agent, string animationName)
            : base(blackboard, characterController, animator)
        {
            this.agent = agent;
            waypoints = blackboard.GetValue<List<Transform>>(WaypointType.Patrol.ToString());

            WalkHash = Animator.StringToHash(animationName);

            if (waypoints == null || waypoints.Count == 0)
                throw new System.Exception("No waypoints found");
        }

        public override void OnEnter()
        {
            animator.CrossFade(WalkHash, 0.1f);
            base.OnEnter();

            agent.SetDestination(waypoints[currentWaypointIndex].position);
        }

        public override void UpdateState()
        {
            // Am I there yet? If yes, get next
            if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
                agent.SetDestination(waypoints[currentWaypointIndex].position);
            }
        }
    }
}