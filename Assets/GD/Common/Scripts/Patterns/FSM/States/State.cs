using GD.Utility;

namespace GD.FSM
{
    public abstract class State : IState
    {
        // Stores the reference to the blackboard used by the state
        protected Blackboard blackboard;

        public State(Blackboard blackboard)
        {
            this.blackboard = blackboard;
        }

        /// <summary>
        /// Called when the state is entered.
        /// </summary>
        public virtual void OnEnter()
        {
            //TODO: Implement this method
        }

        /// <summary>
        /// Used for states that relate to game logic or other variable time updates.
        /// </summary>
        public virtual void Update()
        {
            //TODO: Implement this method
        }

        /// <summary>
        /// Used for states that relate to physics or other fixed time updates.
        /// </summary>
        public virtual void FixedUpdate()
        {
            //TODO: Implement this method
        }

        /// <summary>
        /// Called when the state is exited.
        /// </summary>
        public virtual void OnExit()
        {
            //TODO: Implement this method
        }
    }
}