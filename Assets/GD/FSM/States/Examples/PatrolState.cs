using System;
using System.Collections.Generic;

using UnityEngine;

namespace GD.FSM
{
    [CreateAssetMenu(fileName = "PatrolState", menuName = "GD/FSM/States/Patrol")]
    public class PatrolState : State
    {
        [Range(0.1f, 1f)]
        public float detectionProbability = 1;

        public override void Enter()
        {
            base.Enter();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}