using UnityEngine;

namespace GD.FSM.SO
{
    public abstract class ScriptableAction : ScriptableObject, IScriptableAction
    {
        public abstract void Initialize(ScriptableStateController stateController);

        public virtual void OnEnter(ScriptableStateController stateController)
        {
            Debug.Log($"{GetType().Name}.OnEnter at {Time.time} with stateController [{stateController}]");
        }

        public virtual void OnUpdate(ScriptableStateController stateController)
        {
            Debug.Log($"{GetType().Name}.OnUpdate at {Time.time} with stateController [{stateController}]");
        }

        public virtual void OnExit(ScriptableStateController stateController)
        {
            Debug.Log($"{GetType().Name}.OnExit at {Time.time} with stateController [{stateController}]");
        }

        public virtual void Reset()
        {
            Debug.Log($"{GetType().Name}.Reset at {Time.time}");
        }
    }
}