using UnityEngine;

namespace GD.FSM
{
    public class LevelUpState : CharacterState
    {
        public LevelUpState(Blackboard blackboard,
            CharacterController characterController, Animator animator)
            : base(blackboard, characterController, animator)
        {
        }
    }
}