using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace GD.Tweens
{
    /// <summary>
    /// Base class for all tween movement
    /// </summary>
    public abstract class BaseTween : MonoBehaviour
    {
        #region Fields - Inspector

        [SerializeField]
        [Tooltip("Should the tween start on Start()")]
        private bool isEnabledOnStart = true;

        [TabGroup("Timing")]
        [SerializeField]
        [Range(0.1f, 10f)]
        [Tooltip("The duration of the tween in seconds")]
        private float durationSecs = 1;

        [TabGroup("Timing")]
        [SerializeField]
        [Range(0f, 240f)]
        [Tooltip("The delay before the tween starts in seconds")]
        private float delaySecs = 0;

        [TabGroup("Timing")]
        [SerializeField]
        [Tooltip("The ease function to use for the tween")]
        private Ease easeFunction = Ease.Linear;

        [TabGroup("Loop")]
        [SerializeField]
        [Range(-1, 100)]
        private int loopCount = 1;

        [TabGroup("Loop")]
        [SerializeField]
        [Tooltip("The type of loop to use for the tween")]
        [HideIf("HideIfLoopCount")]
        private LoopType loopType = LoopType.Yoyo;

        [TabGroup("Events")]
        [SerializeField]
        [Tooltip("Event to call when the tween has completed")]
        private UnityEvent onComplete;

        #endregion Fields - Inspector

        #region Properties

        public bool IsEnabledOnStart { get => isEnabledOnStart; set => isEnabledOnStart = value; }
        public float DurationSecs { get => durationSecs; set => durationSecs = value; }
        public Ease EaseFunction { get => easeFunction; set => easeFunction = value; }
        public int LoopCount { get => loopCount; set => loopCount = value; }
        public LoopType LoopType { get => loopType; set => loopType = value; }
        public UnityEvent OnComplete { get => onComplete; set => onComplete = value; }
        public float DelaySecs { get => delaySecs; set => delaySecs = value; }

        #endregion Properties

        public virtual void Start()
        {
            //Start the tween
            if (IsEnabledOnStart)
                StartTween();
        }

        /// <summary>
        /// Called to start the tween.
        /// </summary>
        public virtual void StartTween()
        {
        }

        /// <summary>
        /// Called when the tween is complete, invokes the onComplete event.
        /// </summary>
        public virtual void TweenComplete()
        {
            OnComplete?.Invoke();
        }

        /// <summary>
        /// Hides the loop type if the loop count is 0 or 1.
        /// </summary>
        /// <returns></returns>
        public virtual bool HideIfLoopCount()
        {
            return LoopCount == 0 || LoopCount == 1;
        }
    }
}