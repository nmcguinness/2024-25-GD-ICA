using UnityEngine;

namespace GD.FSM
{
    public class PatrolState : CharacterState
    {
        public PatrolState(Blackboard blackboard,
            CharacterController characterController, Animator animator)
            : base(blackboard, characterController, animator)
        {
        }
    }
}