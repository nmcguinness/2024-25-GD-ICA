namespace GD.FSM
{
    /// <summary>
    /// Represents a state in a FSM e.g. Idle, Chase, etc.
    /// </summary>
    public interface IState
    {
        void Initialize(FSMController controller, Blackboard blackboard);

        void Enter();

        void Update();

        void Exit();
    }
}