namespace GD.FSM
{
    /// <summary>
    /// Interface for all transitions between states based on a simple or composite predicate
    /// </summary>
    public interface ITransition
    {
        IState To { get; }
        IPredicate Condition { get; }
    }
}