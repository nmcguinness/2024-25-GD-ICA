using System;
using UnityEngine;

namespace GD.FSM
{
    [CreateAssetMenu(fileName = "IdleState", menuName = "GD/FSM/States/Idle")]
    public class IdleState : State
    {
        public override void Enter()
        {
            //"on station"
        }

        public override void Update()
        {
        }

        public override void Exit()
        {
            //"starting patrol"
        }
    }
}