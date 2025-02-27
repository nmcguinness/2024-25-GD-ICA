using UnityEngine;

namespace GD.FSM.SO
{
    [CreateAssetMenu(fileName = "PatrolAction", menuName = "GD/FSM/Scriptable/Action/Patrol")]
    public class PatrolAction : ScriptableAction
    {
        //TODO: Finish this!

        public override void OnEnter(ScriptableStateController stateController)
        {
            //TODO: Implement animation logic
        }

        public override void OnUpdate(ScriptableStateController stateController)
        {
            //TODO: Implement patrol logic
        }

        public override void OnExit(ScriptableStateController stateController)
        {
            //noop
        }
    }
}