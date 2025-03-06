using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GD.Toast
{
    /// <summary>
    /// ToastManager is a Singleton class that manages the display of toast messages in a queue.
    /// </summary>
    public class ToastManager : Singleton<ToastManager>
    {
        [FoldoutGroup("UI Elements", expanded: true)]
        [SerializeField]
        [Tooltip("GameObject containing canvas and textmeshpro object")]
        private GameObject toastUI;

        [FoldoutGroup("UI Elements")]
        [SerializeField]
        [Tooltip("TextMeshPro object used to set toast text")]
        private TextMeshProUGUI toastTextMeshPro;

        [FoldoutGroup("UI Elements")]
        [SerializeField]
        [Tooltip("Animator used to animate the toast")]
        [RequireInterface(typeof(IAnimateToast))]
        private ScriptableObject toastAnimator;

        [FoldoutGroup("Runtime Info")]
        [ShowInInspector, ReadOnly]
        private bool isProcessing = false;

        private Queue<Toast> toastQueue = new Queue<Toast>();
        private IAnimateToast animator;

        protected override void Awake()
        {
            // Call base class Awake method
            base.Awake();

            // Hide the toast UI on start
            toastUI?.SetActive(false);

            // If we have an animator, animate the toast
            animator = toastAnimator as IAnimateToast;
        }

        public void AddToast(string message, float duration, float delay)
        {
            toastQueue.Enqueue(new Toast(message, duration, delay));

            if (!isProcessing)
            {
                StartCoroutine(ProcessQueue());
            }
        }

        private IEnumerator ProcessQueue()
        {
            isProcessing = true;

            while (toastQueue.Count > 0)
            {
                Toast toast = toastQueue.Dequeue();

                // Delay before showing
                yield return new WaitForSeconds(toast.Delay);

                // Show toast
                toastTextMeshPro.text = toast.Message;
                toastUI.SetActive(true);

                // We have an animator
                if (animator != null)
                {
                    // Animate using the animator
                    bool animationComplete = false;
                    animator.AnimateToast(toastUI, toast.Duration, () => animationComplete = true);

                    // Wait for the animation to complete
                    yield return new WaitUntil(() => animationComplete);
                }
                // No animator
                else
                {
                    // Wait for the duration
                    yield return new WaitForSeconds(toast.Duration);
                }

                // Reset and hide the toast
                toastTextMeshPro.text = string.Empty;
                toastUI.SetActive(false);
            }

            isProcessing = false;
        }
    }
}

/*
 namespace GD.Toast
{
    /// <summary>
    /// Manages the display of toast messages in a queue.
    /// </summary>
    public class ToastManager : Singleton<ToastManager>
    {
        [FoldoutGroup("UI Elements", expanded: true)]
        [SerializeField]
        [Tooltip("GameObject containing canvas and textmeshpro object")]
        private GameObject toastUI;

        [FoldoutGroup("UI Elements")]
        [SerializeField]
        [Tooltip("TextMeshPro object used to set toast text")]
        private TextMeshProUGUI toastTextMeshPro;

        [FoldoutGroup("Runtime Info")]
        [ReadOnly, SerializeField]
        private bool isProcessing = false;

        private Queue<Toast> toastQueue = new Queue<Toast>();

        protected override void Awake()
        {
            base.Awake();

            // Hide the toast UI on start
            toastUI?.SetActive(false);
        }

        [ContextMenu("Test Toast")]
        public void TestToast()
        {
            AddToast("Lose", 5, 1);
        }

        /// <summary>
        /// Adds a new toast to the queue.
        /// </summary>
        public void AddToast(string message, float duration, float delay)
        {
            toastQueue.Enqueue(new Toast(message, duration, delay));

            if (!isProcessing)
            {
                StartCoroutine(ProcessQueue());
            }
        }

        private IEnumerator ProcessQueue()
        {
            isProcessing = true;

            while (toastQueue.Count > 0)
            {
                Toast toast = toastQueue.Dequeue();

                // Delay before showing
                yield return new WaitForSeconds(toast.Delay);

                // Show toast
                toastTextMeshPro.text = toast.Message;
                toastUI.SetActive(true);

                // Wait for the duration
                yield return new WaitForSeconds(toast.Duration);

                // Reset and hide the toast
                toastTextMeshPro.text = string.Empty;
                toastUI.SetActive(false);
            }

            isProcessing = false;
        }
    }
}
 */