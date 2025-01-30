using UnityEngine;

namespace GD.State
{
    /// <summary>
    /// A condition that ensures prefabs are spawned within a specified area.
    /// </summary>
    [CreateAssetMenu(fileName = "AreaCondition", menuName = "GD/Conditions/Single/Area", order = 1)]
    public class AreaCondition : ConditionBase
    {
        [Tooltip("The bounds within which spawning is allowed.")]
        [SerializeField]
        private Bounds spawnArea;

        protected override bool EvaluateCondition(ConditionContext conditionContext)
        {
            return spawnArea.Contains(conditionContext.GameObject.transform.position);
        }
    }
}