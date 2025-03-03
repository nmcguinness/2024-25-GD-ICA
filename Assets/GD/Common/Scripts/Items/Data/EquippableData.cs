using UnityEngine;

namespace GD.Items
{
    public abstract class EquippableData : BaseItemData
    {
        [SerializeField] private Sprite uiIcon;
        [SerializeField] private AudioClip audioClip;
        [SerializeField] private Vector3 audioPosition;

        public Sprite UiIcon => uiIcon;
        public AudioClip AudioClip => audioClip;
        public Vector3 AudioPosition => audioPosition;
    }
}