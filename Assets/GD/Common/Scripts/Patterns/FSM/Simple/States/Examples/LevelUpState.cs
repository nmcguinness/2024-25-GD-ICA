using UnityEngine;

namespace GD.FSM.Simple
{
    public class LevelUpState : FSMCharacterState
    {
        public LevelUpState(Blackboard blackboard,
            FSMCharacterController characterController, Animator animator)
            : base(blackboard, characterController, animator)
        {
        }
    }
}