using UnityEngine;

namespace GD.State
{
    /// <summary>
    /// A condition that ensures prefabs are spawned farther than a minimum distance from a target.
    /// </summary>
    [CreateAssetMenu(fileName = "DistanceCondition", menuName = "GD/Conditions/Single/Distance", order = 2)]
    public class DistanceCondition : ConditionBase
    {
        [Tooltip("The target object to measure distance from.")]
        [SerializeField]
        private Transform target;

        [Tooltip("The minimum distance required to spawn.")]
        [SerializeField]
        private float minDistance;

        protected override bool EvaluateCondition(ConditionContext conditionContext)
        {
            if (target == null) return false;
            return Vector3.Distance(conditionContext.GameObject.transform.position, target.position) > minDistance;
        }
    }
}