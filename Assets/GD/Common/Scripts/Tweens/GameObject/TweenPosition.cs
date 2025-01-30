using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GD.Tweens
{
    /// <summary>
    /// Uses DoTween to tween the position of the object.
    /// </summary>
    public class TweenPosition : BaseTween
    {
        #region Fields - Inspector

        [TabGroup("Transformation")]
        [SerializeField]
        [Tooltip("The amount to move the object by")]
        private Vector3 positionDelta = Vector3.up;

        #endregion Fields - Inspector

        #region Fields - Internal

        private Vector3 originalPosition;

        #endregion Fields - Internal

        // Start is called before the first frame update
        public override void Start()
        {
            //Save the original position of the object
            originalPosition = transform.position;

            //Start the tween
            base.Start();
        }

        /// <summary>
        /// Called to start the tween.
        /// </summary>
        public override void StartTween()
        {
            //Move the object by the positionDelta over the durationSecs using the easeFunction and the loopCount and loopType
            transform.DOMove(originalPosition + positionDelta, DurationSecs)
               .SetDelay(DelaySecs) //float
                .SetEase(EaseFunction)
                    .SetLoops(LoopCount, LoopType)
                        .OnComplete(TweenComplete);
        }

        public override void TweenComplete()
        {
            //my unique TweenPosition complete code

            //do the common Invoke()
            base.TweenComplete();
        }
    }
}