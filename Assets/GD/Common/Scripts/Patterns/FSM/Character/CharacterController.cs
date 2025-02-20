using System;
using UnityEngine;

namespace GD.FSM
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField]
        private Blackboard blackboard;

        [SerializeField]
        private Animator animator;

        private FiniteStateMachine stateMachine;

        private void Awake() => InitialiseFiniteStateMachine();

        private void InitialiseFiniteStateMachine()
        {
            // 1. Create the FSM
            stateMachine = new FiniteStateMachine();

            // 2. Create the states
            var idleState = new IdleState(blackboard, this, animator);
            var patrolState = new PatrolState(blackboard, this, animator);

            // 3. Connect the states
            stateMachine.AddTransition(idleState, patrolState,
                new FuncPredicate(() => idleState.timer.ElapsedUpdateTime > 5));

            // 4. Set the initial state
            stateMachine.SetState(idleState);
        }
    }
}