using UnityEngine;

namespace GD.FSM.SO
{
    [CreateAssetMenu(fileName = "PatrolAction", menuName = "GD/FSM/Scriptable/Action/Patrol")]
    public class PatrolAction : ScriptableAction
    {
        public override void OnUpdate(ScriptableStateController stateController)
        {
            Patrol(stateController);
        }

        private void Patrol(ScriptableStateController stateController)
        {
            //TODO: Implement patrol logic
        }
    }
}