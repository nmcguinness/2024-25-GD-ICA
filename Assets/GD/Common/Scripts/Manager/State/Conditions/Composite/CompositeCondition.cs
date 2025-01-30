using GD.Types;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GD.State
{
    [CreateAssetMenu(menuName = "GD/Conditions/Composite Condition")]
    public class CompositeCondition : ConditionBase
    {
        /// <summary>
        /// The type of composite condition (And, Or, Xor).
        /// </summary>
        public ConditionType conditionType;

        /// <summary>
        /// The list of conditions to evaluate.
        /// </summary>
        public List<ConditionBase> conditions;

        private bool isSorted = false;

        /// <summary>
        /// Evaluates the condition logic based on the conditionType.
        /// </summary>
        /// <returns>True if the composite condition is met; otherwise, false.</returns>
        protected override bool EvaluateCondition(ConditionContext context)
        {
            // Sort conditions by priority before evaluation
            if (!isSorted)
            {
                SortConditionsByPriority();
                isSorted = true;
            }

            switch (conditionType)
            {
                case ConditionType.And:
                    return EvaluateAndCondition(context);

                case ConditionType.Or:
                    return EvaluateOrCondition(context);

                case ConditionType.Xor:
                    return EvaluateXorCondition(context);

                default:
                    Debug.LogError("CompositeCondition: Unknown condition type.");
                    return false;
            }
        }

        /// <summary>
        /// Evaluates an AND condition: returns true if all child conditions are met.
        /// </summary>
        private bool EvaluateAndCondition(ConditionContext context)
        {
            bool allMet = true;
            foreach (var condition in conditions)
            {
                if (!condition.Evaluate(context))
                    allMet = false;
            }

            if (allMet && timeMet == -1f)
            {
                timeMet = Time.timeSinceLevelLoad;
                OnConditionMet?.Raise();
            }

            return allMet;
        }

        /// <summary>
        /// Evaluates an OR condition: returns true if any child condition is met.
        /// </summary>
        private bool EvaluateOrCondition(ConditionContext context)
        {
            foreach (var condition in conditions)
            {
                if (condition.Evaluate(context))
                {
                    if (timeMet == -1f)
                    {
                        timeMet = Time.timeSinceLevelLoad;
                        OnConditionMet?.Raise();
                    }
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Evaluates an XOR condition: returns true if exactly one child condition is met.
        /// </summary>
        private bool EvaluateXorCondition(ConditionContext context)
        {
            int metCount = 0;

            foreach (var condition in conditions)
            {
                if (condition.Evaluate(context))
                {
                    metCount++;
                    // If more than one condition is met, return false
                    if (metCount > 1)
                    {
                        return false;
                    }
                }
            }

            if (metCount == 1)
            {
                if (timeMet == -1f)
                {
                    timeMet = Time.timeSinceLevelLoad;
                    OnConditionMet?.Raise();
                }
                return true;
            }

            return false;
        }

        /// <summary>
        /// Sorts the conditions array based on priority levels from highest to lowest.
        /// </summary>
        protected void SortConditionsByPriority()
        {
            //sort the conditions in descending order of priority level
            conditions = conditions.OrderByDescending(c => c.PriorityLevel).ToList();
        }

        /// <summary>
        /// Resets the composite condition and all its child conditions.
        /// </summary>
        public override void ResetCondition()
        {
            base.ResetCondition();
            foreach (var condition in conditions)
            {
                condition.ResetCondition();
            }
        }
    }
}