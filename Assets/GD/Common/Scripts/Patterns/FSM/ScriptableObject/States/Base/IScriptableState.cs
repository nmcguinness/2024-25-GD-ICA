namespace GD.FSM.SO
{
    public interface IScriptableState
    {
        void Initialize(ScriptableStateController stateController);

        void OnEnter(ScriptableStateController stateController);

        void OnExit(ScriptableStateController stateController);

        void UpdateState(ScriptableStateController stateController);

        void ResetState(ScriptableStateController stateController);
    }
}