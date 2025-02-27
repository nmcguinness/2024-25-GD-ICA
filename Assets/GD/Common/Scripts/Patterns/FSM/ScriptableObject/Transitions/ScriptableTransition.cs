using System;
using UnityEngine;

namespace GD.FSM.SO
{
    [Serializable]
    public class ScriptableTransition
    {
        [SerializeField]
        private ScriptablePredicate predicate;

        [SerializeField]
        private ScriptableState trueState;

        [SerializeField]
        private ScriptableState falseState;

        public ScriptablePredicate Predicate { get => predicate; set => predicate = value; }
        public ScriptableState TrueState { get => trueState; set => trueState = value; }
        public ScriptableState FalseState { get => falseState; set => falseState = value; }
    }
}