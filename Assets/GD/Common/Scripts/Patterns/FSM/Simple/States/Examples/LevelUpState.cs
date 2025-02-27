using UnityEngine;

namespace GD.FSM.Simple
{
    public class LevelUpState : State
    {
        public LevelUpState(Blackboard blackboard,
            StateController characterController, Animator animator)
            : base(blackboard, characterController, animator)
        {
        }
    }
}