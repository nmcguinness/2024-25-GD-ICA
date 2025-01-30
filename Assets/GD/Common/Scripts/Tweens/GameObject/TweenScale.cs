using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GD.Tweens
{
    /// <summary>
    /// Uses DoTween to tween the scale of the object.
    /// </summary>
    public class TweenScale : BaseTween
    {
        #region Fields - Inspector

        [TabGroup("Transformation")]
        [SerializeField]
        [Tooltip("The amount to add to the original scale of the object")]
        private Vector3 scaleDelta = Vector3.one;

        #endregion Fields - Inspector

        #region Fields - Internal

        private Vector3 originalScale;

        #endregion Fields - Internal

        // Start is called before the first frame update
        public override void Start()
        {
            // Save the original scale of the object
            originalScale = transform.localScale;

            // Start the tween
            base.Start();
        }

        /// <summary>
        /// Called to start the tween.
        /// </summary>
        public override void StartTween()
        {
            // Scale the object by the scaleDelta over the durationSecs using the easeFunction and loop settings
            transform.DOScale(originalScale + scaleDelta, DurationSecs)
                .SetDelay(DelaySecs)
                .SetEase(EaseFunction)
                .SetLoops(LoopCount, LoopType)
                .OnComplete(TweenComplete);
        }

        public override void TweenComplete()
        {
            // Custom completion logic for TweenScale if needed

            // Invoke common completion logic
            base.TweenComplete();
        }
    }
}