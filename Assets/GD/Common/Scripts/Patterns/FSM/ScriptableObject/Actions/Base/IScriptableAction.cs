namespace GD.FSM.SO
{
    public interface IScriptableAction
    {
        void Initialize(ScriptableStateController stateController);

        void OnEnter(ScriptableStateController stateController);

        void OnExit(ScriptableStateController stateController);

        void OnUpdate(ScriptableStateController stateController);

        void Reset();
    }
}