using System;
using UnityEngine;

namespace GD.Toast
{
    public abstract class ToastAnimator : ScriptableObject, IAnimateToast
    {
        public abstract void AnimateToast(GameObject toastUI, float duration, Action onComplete);
    }
}