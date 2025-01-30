using UnityEngine;

namespace GD.Toast
{
    /// <summary>
    /// Base interface for animating toasts
    /// </summary>
    public interface IAnimateToast
    {
        void AnimateToast(GameObject toastUI, float duration, System.Action onComplete);
    }
}