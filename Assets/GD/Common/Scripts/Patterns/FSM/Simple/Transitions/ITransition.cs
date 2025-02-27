using GD.Predicates;

namespace GD.FSM.Simple
{
    /// <summary>
    /// Interface for all transitions between states based on a simple or composite predicate
    /// </summary>
    public interface ITransition
    {
        IState To { get; }
        IPredicate Predicate { get; }
    }
}