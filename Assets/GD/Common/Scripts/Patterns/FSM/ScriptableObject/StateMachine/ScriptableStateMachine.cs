using GD.Utility;
using Sirenix.OdinInspector;
using System.Linq;
using UnityEngine;

namespace GD.FSM.SO
{
    [RequireComponent(typeof(ScriptableStateController))]
    public class ScriptableStateMachine : MonoBehaviour
    {
        [SerializeField]
        private ScriptableState initialState;

        [SerializeField]
        private ScriptableState[] states;

        [SerializeField]
        private ScriptableTransition[] optionalInterruptionTransitions;

        [FoldoutGroup("Debug Info", expanded: false)]
        [ShowInInspector, ReadOnly]
        private ScriptableState currentState;

        private ScriptableStateController stateController;

        private void Awake()
        {
            stateController = GetComponent<ScriptableStateController>();

            Initialize();
        }

        private void Initialize()
        {
            if (initialState == null || initialState.Actions == null || initialState.Actions.Count() == 0)
            {
                Debug.LogError("Initial state is not assigned and/or has no actions.");
                return;
            }

            // Warm up the states
            for (int i = 0; i < states.Length; i++)
            {
                states[i].Initialize(stateController);
            }

            // Set the insertion state for the FSM
            currentState = initialState;

            // Enter the initial state
            currentState.OnEnter(stateController);
        }

        private void Update()
        {
            if (currentState == null) return;

            // Check optional transitions first
            var transition = GetTransition();
            if (transition != null)
            {
                bool predicateResult = transition.Predicate.Evaluate(stateController);
                ChangeState(predicateResult ? transition.TrueState : transition.FalseState);
                return;
            }

            // Otherwise update the current state
            currentState.UpdateState(stateController);
        }

        private ScriptableTransition GetTransition()
        {
            // Check optional transitions first (e.g. player has captured the flag and so game ends and NPC surrenders)
            for (int i = 0; i < optionalInterruptionTransitions.Length; i++)
            {
                if (optionalInterruptionTransitions[i].Predicate.Evaluate(stateController))
                {
                    return optionalInterruptionTransitions[i];
                }
            }

            var transitions = currentState.Transitions;

            // Check the transitions of the current state (e.g. player has moved to a new area and so NPC follows)
            for (int i = 0; i < transitions.Length; i++)
            {
                if (transitions[i].Predicate.Evaluate(stateController))
                {
                    return transitions[i];
                }
            }

            return null;
        }

        private void ChangeState(ScriptableState newState)
        {
            // Avoid re‐entering the same state
            if (newState == null || newState == currentState) return;

            currentState.OnExit(stateController);
            currentState = newState;
            currentState.OnEnter(stateController);
        }
    }
}