using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace GD.FSM.SO
{
    [CreateAssetMenu(fileName = "PatrolAction", menuName = "GD/FSM/Scriptable/Action/Play Animation")]
    public class ScriptableAnimatedAction : ScriptableAction
    {
        [FoldoutGroup("Animation Data", expanded: true)]
        [SerializeField]
        [Tooltip("Motion name of the animation to play (with no whitespaces")]
        protected string animationName = "Idle";

        [FoldoutGroup("Animation Data")]
        [SerializeField]
        [Range(0, 60)]
        [Tooltip("Time in seconds to crossfade between animations")]
        protected float crossFadeTime = 0.1f;

        [FoldoutGroup("Debug Info"), ShowInInspector, ReadOnly]
        private int animationHash;

        public override void Initialize(ScriptableStateController stateController)
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