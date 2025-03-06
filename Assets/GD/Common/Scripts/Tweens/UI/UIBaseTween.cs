using DG.Tweening;
using GD.Types;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace GD.Tweens
{
    /// <summary>
    /// Base class for UI panel tweens that can fade, slide, etc.
    /// </summary>
    public abstract class UIBaseTween : MonoBehaviour
    {
        #region Fields

        [SerializeField]
        [Tooltip("Specify the KeyCode to toggle the panel's visibility")]
        protected KeyCode keyCode = KeyCode.M;

        [SerializeField]
        [Tooltip("Common settings for the tween")]
        protected TweenSettings tweenSettings;

        [SerializeField, Tooltip("Event to call when the tween has completed")]
        [PropertyOrder(20)]
        protected UnityEvent onComplete;

        [ShowInInspector, ReadOnly]
        [PropertyOrder(-1)]
        protected VisibilityState visibilityState = VisibilityState.Start;

        #endregion Fields

        #region Properties

        protected float DurationSecs => tweenSettings.DurationSecs;
        protected float DelaySecs => tweenSettings.DelaySecs;
        protected Ease ShowEase => tweenSettings.ShowEase;
        protected Ease HideEase => tweenSettings.HideEase;

        #endregion Properties

        #region Methods

        protected virtual void Start()
        {
            InitializePanel();
        }

        private void Update()
        {
            if (Input.GetKeyDown(keyCode))
                TogglePanel();
        }

        public void TogglePanel()
        {
            if (visibilityState == VisibilityState.End)
                Hide();
            else if (visibilityState == VisibilityState.Start)
                Show();
        }

        protected virtual void InitializePanel()
        {
            visibilityState = VisibilityState.Start;
        }

        protected virtual void Show()
        {
            visibilityState = VisibilityState.Showing;
        }

        protected virtual void Hide()
        {
            visibilityState = VisibilityState.Hiding;
        }

        protected virtual void TweenComplete()
        {
            if (visibilityState == VisibilityState.Showing)
                visibilityState = VisibilityState.End;
            else if (visibilityState == VisibilityState.Hiding)
                visibilityState = VisibilityState.Start;

            onComplete?.Invoke();
        }

        #endregion Methods
    }
}