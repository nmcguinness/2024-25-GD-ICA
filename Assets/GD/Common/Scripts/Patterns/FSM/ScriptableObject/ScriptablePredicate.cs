using System;

namespace GD.FSM.ScriptableObject
{
    [Serializable]
    public abstract class ScriptablePredicate
    {
        public abstract bool Evaluate(ScriptableStateController controller);
    }
}