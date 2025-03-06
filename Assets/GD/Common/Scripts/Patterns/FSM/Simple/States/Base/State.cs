using GD.Utility;
using UnityEngine;

namespace GD.FSM.Simple
{
    public abstract class State : IState
    {
        // Stores the reference to the blackboard used by the state
        protected Blackboard blackboard;

        // Stores the reference to the FSMController used by the state
        protected StateController fsmController;

        // Stores the reference to the animator used by the state
        protected Animator animator;

        public Timer timer;

        public State(Blackboard blackboard,
            StateController fsmController, Animator animator)
        {
            this.blackboard = blackboard;
            this.fsmController = fsmController;
            this.animator = animator;
        }

        /// <summary>
        /// Called when the state is entered.
        /// </summary>
        public virtual void OnEnter()
        {
            Debug.Log(message: $"OnEnter: {GetType().Name} at {Time.time}");

            if (timer == null)
                timer = new Timer();

            timer.Start(0);
        }

        /// <summary>
        /// Used for states that relate to game logic or other variable time updates.
        /// </summary>
        public virtual void UpdateState()
        {
            timer.Tick(Time.deltaTime);
        }

        public virtual void FixedUpdateState()
        {
            //noop
        }

        /// <summary>
        /// Called when the state is exited.
        /// </summary>
        public virtual void OnExit()
        {
            Debug.Log(message: $"OnExit: {GetType().Name} at {Time.time}");
            timer.Stop();
        }
    }
}