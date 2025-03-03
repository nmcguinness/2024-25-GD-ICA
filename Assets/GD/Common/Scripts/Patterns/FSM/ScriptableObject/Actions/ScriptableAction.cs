using UnityEngine;

namespace GD.FSM.SO
{
    public abstract class ScriptableAction : ScriptableObject
    {
        public abstract void Initialize();

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
    }
}