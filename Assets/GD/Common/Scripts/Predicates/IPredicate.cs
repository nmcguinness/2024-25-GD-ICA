namespace GD.Predicates
{
    /// <summary>
    /// Interface for all predicates used in transitions between states.
    /// </summary>
    public interface IPredicate
    {
        bool Evaluate();
    }
}