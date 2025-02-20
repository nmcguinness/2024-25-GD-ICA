using UnityEngine;

namespace GD.FSM
{
    public class CharacterState : State
    {
        protected CharacterController playerController;
        protected Animator animator;

        public CharacterState(Blackboard blackboard,
            CharacterController playerController, Animator animator)
            : base(blackboard)
        {
            this.playerController = playerController;
            this.animator = animator;
        }
    }
}