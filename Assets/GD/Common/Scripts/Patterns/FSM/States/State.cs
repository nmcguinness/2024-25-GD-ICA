using GD.Utility;
using UnityEngine;

namespace GD.FSM
{
    public abstract class State : IState
    {
        // Stores the reference to the blackboard used by the state
        protected Blackboard blackboard;

        public Timer timer;

        public State(Blackboard blackboard)
        {
            this.blackboard = blackboard;
        }

        /// <summary>
        /// Called when the state is entered.
        /// </summary>
        public virtual void OnEnter()
        {
            Debug.Log(message: $"OnEnter: {GetType().Name} at {Time.time}");

            if (timer == null)
                timer = new Timer(GetType().Name);

            timer.Start(0);
        }

        /// <summary>
        /// Used for states that relate to game logic or other variable time updates.
        /// </summary>
        public virtual void Update()
        {
            timer.Update();
        }

        /// <summary>
        /// Used for states that relate to physics or other fixed time updates.
        /// </summary>
        public virtual void FixedUpdate()
        {
            timer.FixedUpdate();
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