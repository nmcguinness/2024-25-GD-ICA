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
        [SerializeField]
        private Blackboard blackboard;

        [SerializeField]
        private Animator animator;

        [SerializeField]
        private NavMeshAgent agent;

        private StateMachine stateMachine;

        private void Awake() => InitialiseFiniteStateMachine();

        private void InitialiseFiniteStateMachine()
        {
            // 1. Create the FSM
            stateMachine = new StateMachine();

            // 2. Create the states
            var idleState = new IdleState(blackboard, this, animator);
            var patrolState = new PatrolState(blackboard, this, animator, agent);

            // 3. Connect the states
            stateMachine.AddTransition(idleState, patrolState,
                new FuncPredicate(() => idleState.timer.ElapsedUpdateTime > 2));

            // 3a. Add the ANY transition states
            var levelUpState = new LevelUpState(blackboard, this, animator);

            stateMachine.AddAnyTransition(levelUpState,
                new FuncPredicate(() => blackboard.XP > 100));

            // 3b. Add composite predicate example

            // 4. Set the initial state
            stateMachine.SetState(idleState);
        }

        //public void Anonymous(Blackboard b)
        //{
        //    return blackboard.XP > 100;
        //}

        private void FixedUpdate()
        {
            stateMachine.Update();
        }

        private void Update()
        {
            stateMachine.FixedUpdate();
        }
    }
}