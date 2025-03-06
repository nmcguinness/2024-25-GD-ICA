using UnityEngine;

namespace GD.FSM.SO
{
    //EXERCISE
    [CreateAssetMenu(fileName = "RandomProbabilityPredicate",
        menuName = "GD/FSM/Scriptable/Predicate/Probabilistic/Above Threshold")]
    public class RandomProbabilityPredicate : ScriptablePredicate
    {
        [SerializeField, Range(0f, 1f)]
        [Tooltip("Lower probability equals less likelihood to return true")]
        private float probability = 0.5f;

        public override bool Evaluate(ScriptableStateController controller)
        {
            return Random.value < probability;
        }
    }
}