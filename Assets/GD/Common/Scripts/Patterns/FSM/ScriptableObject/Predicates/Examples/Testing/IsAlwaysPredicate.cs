using UnityEngine;

namespace GD.FSM.SO
{
    [CreateAssetMenu(menuName = "GD/FSM/Scriptable/Predicate/IsAlways")]
    public class IsAlwaysPredicate : ScriptablePredicate
    {
        [SerializeField]
        private bool isAlways = true;

        public override bool Evaluate(ScriptableStateController controller)
        {
            return isAlways;
        }
    }
}