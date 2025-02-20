using UnityEngine;

namespace GD.FSM
{
    public class IdleState : CharacterState
    {
        public IdleState(Blackboard blackboard,
            CharacterController characterController, Animator animator)
            : base(blackboard, characterController, animator)
        {
        }
    }
}