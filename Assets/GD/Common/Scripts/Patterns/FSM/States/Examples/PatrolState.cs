using UnityEngine;
using UnityEngine.AI;

namespace GD.FSM
{
    public class PatrolState : FSMCharacterState
    {
        private int WalkHash = Animator.StringToHash("Walk_N");
        private NavMeshAgent agent;

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
            //TODO
        }

        private void GetWaypoints()
        {
            //TODO
        }

        public override void Update()
        {
            //TODO
        }
    }
}