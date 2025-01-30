using GD.Events;
using GD.Types;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GD.State
{
    /// <summary>
    /// Abstract base class for conditions.
    /// </summary>
    public abstract class ConditionBase : ScriptableGameObject
    {
        #region Fields

        /// <summary>
        /// The evaluation strategy for the condition.
        /// </summary>
        [SerializeField]
        [Tooltip("The evaluation strategy for the condition.")]
        [TabGroup("Strategy & Priority")]
        protected EvaluateStrategy evaluateStrategy = EvaluateStrategy.EvaluateUntilMet;

        /// <summary>
        /// The priority level of the condition.
        /// </summary>
        [SerializeField]
        [Tooltip("The priority level of the condition (Highest = 1, Lowest = 5).")]
        [TabGroup("Strategy & Priority")]
        private PriorityLevel priorityLevel = PriorityLevel.Lowest; // Default to lowest priority

        /// <summary>
        /// UnityEvent invoked when the condition becomes met.
        /// </summary>
        [SerializeField]
        [Tooltip("GameEvent invoked when the condition is met.")]
        [TabGroup("Events")]
        protected GameEvent OnConditionMet;

        /// <summary>
        /// Indicates whether the condition has been met.
        /// </summary>
        [SerializeField]
        [Tooltip("Indicates whether the condition has been met.")]
        [TabGroup("Runtime Info")]
        protected bool isMet = false;

        /// <summary>
        /// The time in seconds since the level load when the condition was met.
        /// </summary>
        [SerializeField]
        [Tooltip("The time in seconds since the level load when the condition was met.")]
        [TabGroup("Runtime Info")]
        protected float timeMet = -1f; // -1 indicates the condition hasn't been met yet

        #endregion Fields

        #region Properties

        public bool IsMet { get => isMet; protected set => isMet = value; }
        public float TimeMet { get => timeMet; protected set => timeMet = value; }
        public PriorityLevel PriorityLevel { get => priorityLevel; protected set => priorityLevel = value; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Evaluates the condition based on the selected strategy.
        /// </summary>
        /// <returns>True if the condition is met; otherwise, false.</returns>
        public bool Evaluate(ConditionContext conditionContext)
        {
            switch (evaluateStrategy)
            {
                // Evaluate the condition even if it is already met
                case EvaluateStrategy.EvaluateAlways:
                    return EvaluateAlways(conditionContext);

                // Evaluate the condition until it is met, then stop evaluating
                case EvaluateStrategy.EvaluateUntilMet:
                    return EvaluateUntilMet(conditionContext);

                default:
                    return false;
            }
        }

        /// <summary>
        /// Always evaluates the condition logic, regardless of whether it is already met.
        /// </summary>
        /// <returns>True if the condition is met; otherwise, false.</returns>
        private bool EvaluateAlways(ConditionContext conditionContext)
        {
            // Always evaluate the condition logic
            bool previousMet = IsMet;
            bool result = EvaluateCondition(conditionContext);

            // If the condition is met, invoke the event
            if (result)
            {
                // Only invoke the event if the condition wasn't met before
                if (!previousMet)
                {
                    IsMet = true;
                    TimeMet = Time.timeSinceLevelLoad;
                    OnConditionMet?.Raise();
                }
            }
            // If the condition is not met, reset the state
            else
            {
                IsMet = false;
                TimeMet = -1f;
            }

            return result;
        }

        /// <summary>
        /// Evaluates the condition logic until it becomes met, then stops evaluating.
        /// </summary>
        /// <returns>True if the condition is met; otherwise, false.</returns>
        private bool EvaluateUntilMet(ConditionContext conditionContext)
        {
            // Evaluate until the condition is met, then return true without re-evaluating
            if (IsMet)
                return true;

            bool result = EvaluateCondition(conditionContext);
            if (result)
            {
                IsMet = true;
                TimeMet = Time.timeSinceLevelLoad;
                OnConditionMet?.Raise();
            }
            return result;
        }

        /// <summary>
        /// The actual condition logic to be implemented by derived classes.
        /// </summary>
        /// <returns>True if the condition is met; otherwise, false.</returns>
        protected abstract bool EvaluateCondition(ConditionContext conditionContext);

        /// <summary>
        /// Resets the condition state.
        /// </summary>
        [ContextMenu("Reset Condition")]
        public virtual void ResetCondition()
        {
            IsMet = false;
            TimeMet = -1f;
        }

        #endregion Methods
    }
}