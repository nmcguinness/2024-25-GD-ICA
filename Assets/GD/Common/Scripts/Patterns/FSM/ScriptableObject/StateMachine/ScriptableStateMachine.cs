using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GD.FSM.SO
{
    /// <summary>
    /// Manages the state machine and transitions between SO-based states.
    /// </summary>
    /// <see cref="ScriptableStateController"/>
    [RequireComponent(typeof(ScriptableStateController))]
    public class ScriptableStateMachine : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Initial state to start the state machine.")]
        private ScriptableState initialState;

        [SerializeField]
        [Tooltip("List of states to manage.")]
        private List<ScriptableState> states;

        [SerializeField]
        [Tooltip("[Optional] List of transitions that can interrupt the current state.")]
        private List<ScriptableTransition> optionalInterruptionTransitions;

        private ScriptableStateController stateController;
        private ScriptableState currentState;

        private void Start()
        {
            stateController = GetComponent<ScriptableStateController>();

            if (stateController == null)
            {
                Debug.LogError("State controller is not assigned.");
                return;
            }

            Initialize();
        }

        public void Initialize()
        {
            if (initialState == null)
            {
                Debug.LogError("Initial state is not assigned.");
                return;
            }

            if (initialState.Actions == null || initialState.Actions.Count() == 0)
            {
                Debug.LogError("Initial state has no actions.");
                return;
            }

            currentState = initialState;
            currentState.OnEnter(stateController);
        }

        private void Update()
        {
            if (currentState == null) return;

            var transition = GetTransition();
            if (transition != null)
            {
                ChangeState(transition.Predicate.Evaluate(stateController) ? transition.TrueState : transition.FalseState);
                return;
            }

            currentState.UpdateState(stateController);
        }

        private ScriptableTransition GetTransition()
        {
            foreach (var transition in optionalInterruptionTransitions)
            {
                if (transition.Predicate.Evaluate(stateController))
                {
                    return transition;
                }
            }

            foreach (var transition in currentState.Transitions)
            {
                if (transition.Predicate.Evaluate(stateController))
                {
                    return transition;
                }
            }

            return null;
        }

        private void ChangeState(ScriptableState newState)
        {
            // Do not change to the same state
            if (newState == null || newState == currentState) return;

            currentState.OnExit(stateController);
            currentState = newState;
            currentState.OnEnter(stateController);
        }
    }
}