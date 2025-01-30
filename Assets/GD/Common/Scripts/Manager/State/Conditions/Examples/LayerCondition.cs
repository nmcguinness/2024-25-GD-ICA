using UnityEngine;

namespace GD.State
{
    /// <summary>
    /// A condition that ensures no objects on a specified layer are within a radius.
    /// </summary>
    [CreateAssetMenu(fileName = "LayerCondition", menuName = "GD/Conditions/Single/Layer", order = 3)]
    public class LayerCondition : ConditionBase
    {
        [Tooltip("The layer to check for nearby objects.")]
        [SerializeField]
        private LayerMask targetLayer;

        [Tooltip("The radius within which to check for objects on the target layer.")]
        [SerializeField]
        private float radius;

        /// <summary>
        /// Evaluates the condition by checking if there are any objects on the specified layer within the given radius.
        /// </summary>
        /// <param name="conditionContext">The context in which the condition is evaluated.</param>
        /// <returns>True if no objects on the target layer are found within the radius; otherwise, false.</returns>
        protected override bool EvaluateCondition(ConditionContext conditionContext)
        {
            Collider[] nearbyObjects = Physics.OverlapSphere(conditionContext.GameObject.transform.position, radius, targetLayer);
            return nearbyObjects.Length == 0; // Return true if no objects on the target layer are found within the radius
        }
    }
}