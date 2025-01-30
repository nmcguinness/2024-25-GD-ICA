using DG.Tweening;
using UnityEngine;

namespace GD.Tweens
{
    /// <summary>
    /// Fade in/out a UI panel
    /// </summary>
    public class UIFadeTween : UIBaseTween
    {
        [SerializeField, Tooltip("Specify the CanvasGroup component of the UI panel for fading")]
        private CanvasGroup panelCanvasGroup;

        protected override void InitializePanel()
        {
            base.InitializePanel();
            panelCanvasGroup.alpha = 0;
        }

        protected override void Show()
        {
            base.Show();

            panelCanvasGroup.DOFade(1, DurationSecs)
                .SetEase(ShowEase)
                .SetDelay(DelaySecs)
                .OnComplete(TweenComplete);
        }

        protected override void Hide()
        {
            base.Hide();

            panelCanvasGroup.DOFade(0, DurationSecs)
                .SetEase(HideEase)
                 .SetDelay(DelaySecs)
                .OnComplete(TweenComplete);
        }
    }
}