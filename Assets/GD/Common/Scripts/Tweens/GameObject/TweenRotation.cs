using DG.Tweening;
using UnityEngine;

namespace GD.Tweens
{
    public class TweenRotation : BaseTween
    {
        [SerializeField]
        private Vector3 rotationTargetAngleDegrees = new Vector3(0, 180, 0);

        private Quaternion originalRotation;

        public override void Start()
        {
            originalRotation = transform.rotation;
            base.Start();
        }

        public override void StartTween()
        {
            transform.DORotate(originalRotation.eulerAngles
                + rotationTargetAngleDegrees, DurationSecs)
                .SetDelay(DelaySecs) //float
                 .SetEase(EaseFunction)
                   .SetLoops(LoopCount, LoopType)
                    .OnComplete(TweenComplete);
        }
    }
}