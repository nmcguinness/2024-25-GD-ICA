using GD.Predicates;
using UnityEngine;
using UnityEngine.AI;

namespace GD.FSM.Simple
{
    /// <summary>
    /// Sets up thew FSM and provides access to blackboard, animator and navmesh agent.
    /// </summary>
    public class StateController : MonoBehaviour
    {
        private StateMachine stateMachine;

        [SerializeField]
        private Blackboard blackboard;

        [SerializeField]
        private Animator animator;

        [SerializeField]
        private NavMeshAgent agent;

        public Blackboard Blackboard { get => blackboard; }
        public Animator Animator { get => animator; }
        public NavMeshAgent Agent { get => agent; }

        private void Awake() => InitialiseFiniteStateMachine();

        private void InitialiseFiniteStateMachine()
        {
            // 1. Create the FSM
            stateMachine = new StateMachine();

            //  var name = selectionStrategy.GetItem(animations);

            // 2. Create the states
            var idleState = new IdleState(blackboard, this, animator);
            var patrolState = new PatrolState(blackboard, this, animator, agent,
                "Walk_N");

            // 3. Connect the states
            stateMachine.AddTransition(idleState, patrolState,
                new FuncPredicate(() => idleState.timer.ElapsedTime > 2));

            stateMachine.AddTransition(patrolState, idleState,
          new FuncPredicate(() => patrolState.timer.ElapsedTime > 5));

            // 3a. Add the ANY transition states
            //var levelUpState = new LevelUpState(blackboard, this, animator);

            //stateMachine.AddAnyTransition(levelUpState,
            //    new FuncPredicate(() => blackboard.XP > 100));

            // 3b. Add composite predicate example

            // 4. Set the initial state
            stateMachine.SetState(idleState);
        }

        private void FixedUpdate()
        {
            stateMachine.FixedUpdate();
        }

        private void Update()
        {
            stateMachine.Update();
        }
    }
}