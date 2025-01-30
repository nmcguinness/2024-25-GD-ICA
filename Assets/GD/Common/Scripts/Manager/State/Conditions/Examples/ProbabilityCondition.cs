using UnityEngine;

namespace GD.State
{
    /// <summary>
    /// A condition that spawns prefabs based on a random probability.
    /// </summary>
    [CreateAssetMenu(fileName = "ProbabilityCondition", menuName = "GD/Conditions/Single/Probability", order = 4)]
    public class ProbabilityCondition : ConditionBase
    {
        [Tooltip("The probability threshold (0 to 1).")]
        [SerializeField]
        private float probability;

        protected override bool EvaluateCondition(ConditionContext conditionContext)
        {
            return Random.value <= Mathf.Clamp01(probability);
        }
    }
}