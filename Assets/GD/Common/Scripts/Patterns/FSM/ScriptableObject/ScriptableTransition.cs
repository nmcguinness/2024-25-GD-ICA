using System;

namespace GD.FSM.ScriptableObject
{
    [Serializable]
    public abstract class ScriptableTransition
    {
        private ScriptablePredicate Condition { get; }
        private ScriptableState TrueState { get; set; }
        private ScriptableState FalseState { get; set; }
    }
}