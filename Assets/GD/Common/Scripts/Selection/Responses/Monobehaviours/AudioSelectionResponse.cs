using UnityEngine;

namespace GD.Selection
{
    /// <summary>
    /// Plays a user-defined audioclip once on new selection from position of selected object
    /// </summary>
    /// <see cref="AdvancedSelectionManager"/>
    public class AudioSelectionResponse : SelectionResponse
    {
        #region Fields

        //Audio clip to play on selection
        [SerializeField]
        private AudioClip clip;

        #endregion Fields

        public override void OnSelect(Transform currentTransform)
        {
            //if i was pointing at something and im now pointing at something else
            if ((PreviousTransform != null && currentTransform != PreviousTransform)
                //or is this my first selection
                || (PreviousTransform == null))
                AudioSource.PlayClipAtPoint(clip, currentTransform.position);

            //store the current as previous for the next call to OnSelect
            base.OnSelect(currentTransform);
        }

        public override void OnDeselect(Transform currentTransform)
        {
            base.OnDeselect(currentTransform);
        }
    }
}