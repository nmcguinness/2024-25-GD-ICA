using UnityEngine;

namespace GD.FSM.SO
{
    [CreateAssetMenu(fileName = "IdleAction", menuName = "GD/FSM/Scriptable/Action/Idle")]
    public class IdleAction : ScriptableAnimatedAction
    {
        public override void OnEnter(ScriptableStateController stateController)
        {
            base.OnEnter(stateController);
            PlayAnimation(stateController);
        }
    }
}