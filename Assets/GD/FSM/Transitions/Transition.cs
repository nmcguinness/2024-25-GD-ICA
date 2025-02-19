using System.Data;
using UnityEngine;

namespace GD.FSM
{
    [CreateAssetMenu(fileName = "Transition", menuName = "GD/FSM/Transition")]
    public class Transition : ScriptableObject
    {
        public State fromState;
        public State toState;
        public Rule transitionRule;
        //priority (1-5)

        public bool CheckTransition(FSMController controller, Blackboard blackboard)
        {
            return transitionRule.Evaluate(controller, blackboard);
        }
    }
}