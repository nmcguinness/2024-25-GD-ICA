using UnityEngine;

namespace GD.State
{
    /// <summary>
    /// A condition that ensures no objects with a specific tag or layer are nearby.
    /// </summary>
    [CreateAssetMenu(fileName = "TagCondition", menuName = "GD/Conditions/Single/Tag", order = 5)]
    public class TagCondition : ConditionBase
    {
        [Tooltip("The required tag to check for nearby objects.")]
        [SerializeField]
        private string requiredTag;

        [Tooltip("The radius within which to check for nearby objects.")]
        [SerializeField]
        private float radius;

        protected override bool EvaluateCondition(ConditionContext conditionContext)
        {
            Collider[] nearbyObjects = Physics.OverlapSphere(conditionContext.GameObject.transform.position, radius);
            foreach (var obj in nearbyObjects)
            {
                if (obj.CompareTag(requiredTag)) return false;
            }
            return true;
        }
    }
}