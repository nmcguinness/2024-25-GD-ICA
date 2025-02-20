using UnityEngine;
using UnityEngine.AI;

namespace GD.FSM
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField]
        private Blackboard blackboard;

        [SerializeField]
        private Animator animator;

        [SerializeField]
        private NavMeshAgent agent;

        private FiniteStateMachine stateMachine;

        private void Awake() => InitialiseFiniteStateMachine();

        private void InitialiseFiniteStateMachine()
        {
            // 1. Create the FSM
            stateMachine = new FiniteStateMachine();

            // 2. Create the states
            var idleState = new IdleState(blackboard, this, animator);
            var patrolState = new PatrolState(blackboard, this, animator, agent);

            // 3. Connect the states
            stateMachine.AddTransition(idleState, patrolState,
                new FuncPredicate(() => idleState.timer.ElapsedUpdateTime > 2));
            //stateMachine.AddTransition(patrolState, idleState,
            //   new FuncPredicate(() => patrolState.timer.ElapsedUpdateTime > 5));

            // 3a. Add the ANY transition states
            //var levelUpState = new LevelUpState(blackboard, this, animator);

            //stateMachine.AddAnyTransition(levelUpState,
            //    new FuncPredicate(() => blackboard.XP > 100));

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
            stateMachine.FixedUpdate();
        }

        private void Update()
        {
            stateMachine.Update();
        }
    }
}