using UnityEngine;

namespace GD.FSM
{
    public abstract class Rule : ScriptableObject
    {
        public abstract bool Evaluate(FSMController controller, Blackboard blackboard);
    }
}