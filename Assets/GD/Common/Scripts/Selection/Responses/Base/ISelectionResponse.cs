using UnityEngine;

namespace GD.Selection
{
    /// <summary>
    /// Any class that implements this interface can respond to selection and deselection events.
    /// </summary>
    /// <see cref="SelectionResponse"/>
    /// <see cref="AudioSelectionResponse"/>
    /// <see cref="HighlightSelectionResponse"/>
    public interface ISelectionResponse
    {
        void OnSelect(Transform currentTransform);

        void OnDeselect(Transform currentTransform);
    }
}