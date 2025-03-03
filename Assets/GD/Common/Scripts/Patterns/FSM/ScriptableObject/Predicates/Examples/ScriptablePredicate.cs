using UnityEngine;

namespace GD.FSM.SO
{
    public abstract class ScriptablePredicate : ScriptableObject
    {
        public abstract bool Evaluate(ScriptableStateController controller);
    }
}