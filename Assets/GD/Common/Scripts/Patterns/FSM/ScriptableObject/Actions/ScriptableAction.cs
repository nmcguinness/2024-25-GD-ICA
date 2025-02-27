using UnityEngine;

namespace GD.FSM.SO
{
    public abstract class ScriptableAction : ScriptableObject
    {
        public abstract void OnEnter(ScriptableStateController stateController);

        public abstract void OnUpdate(ScriptableStateController stateController);

        public abstract void OnExit(ScriptableStateController stateController);
    }
}