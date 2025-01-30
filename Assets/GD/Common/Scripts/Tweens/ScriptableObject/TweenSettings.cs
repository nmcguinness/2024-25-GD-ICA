using DG.Tweening;
using GD.Types;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GD.Tweens
{
    [CreateAssetMenu(fileName = "TweenSettings", menuName = "GD/Tweens/Settings")]
    public class TweenSettings : ScriptableGameObject
    {
        [FoldoutGroup("Timing", expanded: true)]
        [SerializeField]
        [Range(0.1f, 10f)]
        [Tooltip("The duration of the tween in seconds")]
        private float durationSecs = 1;

        [FoldoutGroup("Timing")]
        [SerializeField]
        [Range(0f, 240f)]
        [Tooltip("The delay before the tween starts in seconds")]
        private float delaySecs = 0;

        [FoldoutGroup("Easing", expanded: true)]
        [SerializeField]
        [Tooltip("Ease type for the show animation")]
        private Ease showEase = Ease.OutQuad;

        [FoldoutGroup("Easing")]
        [SerializeField]
        [Tooltip("Ease type for the hide animation")]
        private Ease hideEase = Ease.InQuad;

        public float DurationSecs { get => durationSecs; set => durationSecs = value; }
        public float DelaySecs { get => delaySecs; set => delaySecs = value; }
        public Ease ShowEase { get => showEase; set => showEase = value; }
        public Ease HideEase { get => hideEase; set => hideEase = value; }
    }
}