using System;
using UnityEngine;

namespace GD.FSM
{
    public abstract class State : ScriptableObject, IState
    {
        protected FSMController controller;
        protected Blackboard blackboard;

        public virtual void Initialize(FSMController controller, Blackboard blackboard)
        {
            this.controller = controller;
            this.blackboard = blackboard;
        }

        public virtual void Enter()
        {
            throw new NotImplementedException();
        }

        public virtual void Exit()
        {
            throw new NotImplementedException();
        }

        public virtual void Update()
        {
            throw new NotImplementedException();
        }
    }
}