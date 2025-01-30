using DG.Tweening;
using UnityEngine;

namespace GD.Toast
{
    [CreateAssetMenu(fileName = "TweenScaleToastAnimator",
        menuName = "GD/Toast/Scale")]
    public class TweenScaleToastAnimator : ToastAnimator
    {
        [SerializeField, Tooltip("Scale target (relative to the original size)")]
        private Vector3 targetScale = new Vector3(1.2f, 1.2f, 1.2f);

        private Sequence toastSequence;

        public override void AnimateToast(GameObject toastUI, float duration, System.Action onComplete)
        {
            if (toastUI == null)
            {
                Debug.LogWarning("ToastUI is null. Cannot animate.");
                return;
            }

            // Ensure the object starts with the original scale
            toastUI.transform.localScale = Vector3.one;

            // Create a sequence animation with DoTween
            toastSequence = DOTween.Sequence()
                .Append(toastUI.transform.DOScale(targetScale, duration))
                .OnComplete(() => onComplete?.Invoke());
        }

        private void OnDestroy()
        {
            // Kill any running tween to avoid memory leaks
            toastSequence.Kill();
        }
    }
}