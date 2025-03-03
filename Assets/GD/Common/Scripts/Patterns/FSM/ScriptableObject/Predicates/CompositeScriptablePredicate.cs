using GD.FSM.SO;
using System;
using UnityEngine;

namespace Assets.GD.Common.Scripts.Patterns.FSM.ScriptableObject.Predicates
{
    [CreateAssetMenu(menuName = "GD/FSM/Scriptable/Predicate/Composite")]
    public class CompositeScriptablePredicate : ScriptablePredicate
    {
        public override bool Evaluate(ScriptableStateController controller)
        {
            throw new NotImplementedException();
        }
    }
}