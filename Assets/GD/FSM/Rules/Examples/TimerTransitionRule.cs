using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GD.FSM
{
    [CreateAssetMenu(fileName = "TimerTransitionRule", menuName = "GD/FSM/Rules/Timer")]
    public class TimerTransitionRule : Rule
    {
        public float delayInSeconds = 5;
        private float elapsedTime;

        private void Awake()
        {
            elapsedTime = 0;
        }

        public override bool Evaluate(FSMController controller, Blackboard blackboard)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime > delayInSeconds)
            {
                elapsedTime = 0;
                return true;
            }

            return false;
        }
    }
}