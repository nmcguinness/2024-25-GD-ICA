using UnityEngine;

namespace GD.FSM.SO
{
    public abstract class ScriptableAction : ScriptableObject
    {
        public virtual void OnEnter(ScriptableStateController stateController)
        {
            //noop
        }

        public abstract void OnUpdate(ScriptableStateController stateController);

        public virtual void OnExit(ScriptableStateController stateController)
        {
            //noop
        }
    }
}