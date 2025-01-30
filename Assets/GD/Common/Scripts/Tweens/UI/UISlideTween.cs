using DG.Tweening;
using UnityEngine;

namespace GD.Tweens
{
    /// <summary>
    /// Slides a UI panel in/out of the screen
    /// </summary>
    public class UISlideTween : UIBaseTween
    {
        [SerializeField, Tooltip("Specify the RectTransform of the UI panel that will slide in/out")]
        private RectTransform panel;

        [SerializeField, Tooltip("Specify the off-screen position of the panel")]
        private Vector2 offScreenPosition = new Vector2(-500, 500);

        [SerializeField, Tooltip("Specify the on-screen position of the panel")]
        private Vector2 onScreenPosition = Vector2.zero;

        protected override void InitializePanel()
        {
            base.InitializePanel();

            panel.anchoredPosition = offScreenPosition;
        }

        protected override void Show()
        {
            base.Show();

            panel.DOAnchorPos(onScreenPosition, DurationSecs)
                .SetEase(ShowEase)
                .SetDelay(DelaySecs)
                .OnComplete(TweenComplete);
        }

        protected override void Hide()
        {
            base.Hide();

            panel.DOAnchorPos(offScreenPosition, DurationSecs)
                .SetEase(HideEase)
                 .SetDelay(DelaySecs)
                .OnComplete(TweenComplete);
        }
    }
}