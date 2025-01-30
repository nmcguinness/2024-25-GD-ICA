using UnityEngine;

namespace GD.Selection
{
    /// <summary>
    /// Base class for all selection responses that stores the previously selected object.
    /// </summary>
    public abstract class SelectionResponse : MonoBehaviour, ISelectionResponse
    {
        #region Fields

        //Reference to the previously selected object
        private Transform previousTransform;

        #endregion Fields

        #region Properties

        public Transform PreviousTransform { get => previousTransform; set => previousTransform = value; }

        #endregion Properties

        public virtual void OnSelect(Transform currentTransform)
        {
            PreviousTransform = currentTransform;
        }

        public virtual void OnDeselect(Transform currentTransform)
        {
            //NOOP - called in child classes
        }
    }
}