using GD.Predicates;
using System;
using System.Collections.Generic;

namespace GD.FSM.Simple
{
    /// <summary>
    /// Manages the state machine and transitions between states.
    /// </summary>
    /// <see cref="StateController"/>
    public class StateMachine
    {
        private StateNode current;
        private Dictionary<Type, StateNode> nodes = new();
        private HashSet<ITransition> anyTransitions = new();

        public StateMachine()
        {
        }

        #region Updating States

        public void Update()
        {
            var transition = GetTransition();
            if (transition != null)
                ChangeState(transition.To);

            current.State?.UpdateState();
        }

        public void FixedUpdate()
        {
            current.State?.FixedUpdateState();
        }

        //public void TickUpdate()
        //{
        //    var transition = GetTransition();
        //    if (transition != null)
        //        ChangeState(transition?.To);

        //    current.State?.UpdateState();
        //}

        //public void TickFixedUpdate()
        //{
        //    current.State?.FixedUpdateState();
        //}

        #endregion Updating States

        #region Adding, Setting, Changing States

        public void SetState(IState state)
        {
            current = nodes[state.GetType()];
            current.State?.OnEnter();
        }

        private void ChangeState(IState state)
        {
            if (state == current.State) return;

            var previousState = current.State;
            var nextState = nodes[state.GetType()].State;

            previousState?.OnExit();
            nextState?.OnEnter();
            current = nodes[state.GetType()];
        }

        private ITransition GetTransition()
        {
            foreach (var transition in anyTransitions)
                if (transition.Predicate.Evaluate())
                    return transition;

            foreach (var transition in current.Transitions)
                if (transition.Predicate.Evaluate())
                    return transition;

            return null;
        }

        public void AddTransition(IState from, IState to, IPredicate condition)
        {
            GetOrAddNode(from).AddTransition(GetOrAddNode(to).State, condition);
        }

        public void AddAnyTransition(IState to, IPredicate condition)
        {
            anyTransitions.Add(new Transition(GetOrAddNode(to).State, condition));
        }

        private StateNode GetOrAddNode(IState state)
        {
            var node = nodes.GetValueOrDefault(state.GetType());

            if (node == null)
            {
                node = new StateNode(state);
                nodes.Add(state.GetType(), node);
            }

            return node;
        }

        #endregion Adding, Setting, Changing States

        #region StateNode wrapper

        private class StateNode
        {
            public IState State { get; }
            public HashSet<ITransition> Transitions { get; }

            public StateNode(IState state)
            {
                State = state;
                Transitions = new HashSet<ITransition>();
            }

            public void AddTransition(IState to, IPredicate condition)
            {
                Transitions.Add(new Transition(to, condition));
            }
        }

        #endregion StateNode wrapper
    }
}