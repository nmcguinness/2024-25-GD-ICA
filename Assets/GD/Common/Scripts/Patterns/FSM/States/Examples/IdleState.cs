using UnityEngine;

namespace GD.FSM
{
    public class IdleState : CharacterState
    {
        private int IdleHash = Animator.StringToHash("Idle");

        public IdleState(Blackboard blackboard,
            CharacterController characterController, Animator animator)
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