namespace GD.FSM.Simple
{
    /// <summary>
    /// Interface for all states in the finite state machine.
    /// </summary>
    public interface IState
    {
        void OnEnter();

        void UpdateState();

        void FixedUpdateState();

        void OnExit();
    }
}