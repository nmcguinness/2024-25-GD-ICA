namespace GD.FSM
{
    /// <summary>
    /// Interface for all states in the finite state machine.
    /// </summary>
    public interface IState
    {
        void OnEnter();

        void Update();

        void FixedUpdate();

        void OnExit();
    }
}