using GD.Types;
using System.Linq;
using UnityEngine;

namespace GD.FSM.SO
{
    //EXERCISE
    [CreateAssetMenu(fileName = "CompositeScriptablePredicate",
        menuName = "GD/FSM/Scriptable/Predicate/Composite")]
    public class CompositeScriptablePredicate : ScriptablePredicate
    {
        [SerializeField]
        private LogicType logicType;

        [SerializeField]
        private ScriptablePredicate[] predicates;

        public override bool Evaluate(ScriptableStateController controller)
        {
            var results = predicates.Select(p => p.Evaluate(controller));

            return logicType switch
            {
                LogicType.AND => results.All(r => r),
                LogicType.OR => results.Any(r => r),
                LogicType.XOR => results.Count(r => r) % 2 == 1,
                _ => false
            };
        }
    }
}