using System;

namespace GD.FSM.SO
{
    [Serializable]
    public abstract class ScriptableTransition
    {
        public ScriptablePredicate Condition { get; }
        public ScriptableState TrueState { get; set; }
        public ScriptableState FalseState { get; set; }
    }
}