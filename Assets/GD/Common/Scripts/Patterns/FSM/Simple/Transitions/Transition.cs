using GD.Predicates;

namespace GD.FSM.Simple
{
    public class Transition : ITransition
    {
        public IState To { get; }
        public IPredicate Predicate { get; }

        public Transition(IState to, IPredicate predicate)
        {
            To = to;
            Predicate = predicate;
        }
    }
}