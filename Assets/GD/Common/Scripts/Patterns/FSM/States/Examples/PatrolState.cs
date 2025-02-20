using UnityEngine;
using UnityEngine.AI;

namespace GD.FSM
{
    public class PatrolState : CharacterState
    {
        private int WalkHash = Animator.StringToHash("Walk_N");
        private NavMeshAgent agent;

        public PatrolState(Blackboard blackboard,
            CharacterController characterController, Animator animator,
            NavMeshAgent agent)
            : base(blackboard, characterController, animator)
        {
            this.agent = agent;
        }

        public override void OnEnter()
        {
            animator.CrossFade(WalkHash, 0.1f);
            base.OnEnter();

            //get waypoint from bb
            //agent.SetDestination(waypoint);
        }
    }
}