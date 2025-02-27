using UnityEngine;

namespace GD.FSM.SO
{
    [CreateAssetMenu(menuName = "GD/FSM/Scriptable/Debug/Predicate/Always True")]
    public class AlwaysTruePredicate : ScriptablePredicate
    {
        public override bool Evaluate(ScriptableStateController controller)
        {
            return true;
        }
    }
}