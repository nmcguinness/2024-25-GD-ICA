using UnityEngine;

namespace GD.FSM
{
    public class FSMCharacterState : State
    {
        protected FSMCharacterController playerController;
        protected Animator animator;

        public FSMCharacterState(Blackboard blackboard,
            FSMCharacterController playerController, Animator animator)
            : base(blackboard)
        {
            this.playerController = playerController;
            this.animator = animator;
        }
    }
}