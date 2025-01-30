using DG.Tweening;
using UnityEngine;

namespace GD.Toast
{
    [CreateAssetMenu(fileName = "TweenFadeToastAnimator",
        menuName = "GD/Toast/Fade In and Out")]
    public class TweenFadeToastAnimator : ToastAnimator
    {
        [SerializeField, Tooltip("Fade-in duration in seconds")]
        [Range(0.1f, 5)]
        private float fadeInDuration = 0.25f;

        [SerializeField, Tooltip("Fade-out duration in seconds")]
        [Range(0.1f, 5)]
        private float fadeOutDuration = 0.25f;

        private Sequence toastSequence;

        public override void AnimateToast(GameObject toastUI, float duration, System.Action onComplete)
        {
            if (toastUI == null)
            {
                Debug.LogWarning("ToastUI is null. Cannot animate.");
                return;
            }

            var canvasGroup = toastUI.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = toastUI.AddComponent<CanvasGroup>();
            }

            // Create a sequence animation with DoTween
            toastSequence = DOTween.Sequence()
                .Append(canvasGroup.DOFade(1, fadeInDuration))
                .AppendInterval(duration)
                .Append(canvasGroup.DOFade(0, fadeOutDuration))
                .OnComplete(() => onComplete?.Invoke());
        }

        private void OnDestroy()
        {
            toastSequence.Kill();
        }
    }
}