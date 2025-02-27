using UnityEngine;

namespace GD.FSM.Simple
{
    public class IdleState : State
    {
        private int IdleHash = Animator.StringToHash("Idle");

        public IdleState(Blackboard blackboard,
            StateController characterController, Animator animator)
            : base(blackboard, characterController, animator)
        {
        }

        public override void OnEnter()
        {
            animator.CrossFade(IdleHash, 0.3f);
            base.OnEnter();
        }
    }
}