using UnityEngine;

namespace GD.FSM.SO
{
    [CreateAssetMenu(fileName = "PatrolAction", menuName = "GD/FSM/Scriptable/Action/Play Animation")]
    public class ScriptableAnimatedAction : ScriptableAction
    {
        [SerializeField]
        protected string animationName = "Idle";

        [SerializeField]
        protected float crossFadeTime = 0.1f;

        private int animationHash;

        protected virtual void Awake()
        {
            animationHash = Animator.StringToHash(animationName.Trim());
        }

        protected virtual void PlayAnimation(ScriptableStateController stateController)
        {
            if (stateController.Animator != null)
            {
                stateController.Animator.CrossFade(animationHash, crossFadeTime);
            }
            else
            {
                Debug.LogWarning($"{GetType().Name}: No Animator found on state controller.");
            }
        }
    }
}