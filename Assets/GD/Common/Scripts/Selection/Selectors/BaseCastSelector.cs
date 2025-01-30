using UnityEngine;

namespace GD.Selection
{
    /// <summary>
    /// Base class for all selection casters that contains the common properties and methods.
    /// </summary>
    public class BaseCastSelector : MonoBehaviour, ISelector
    {
        [SerializeField]
        [Tooltip("Define the tag used by selectable objects")]
        protected string selectableTag = "Selectable";

        [SerializeField]
        [Tooltip("Define the layer to which selectable objects belong")]
        protected LayerMask layerMask;

        [SerializeField]
        [Range(0.01f, 500)]
        [Tooltip("Define the max distance(metres) over which to allow selection")]
        protected float maxDistance = 50;

        protected Transform selection;
        protected RaycastHit hitInfo;
        protected Ray ray;

        public Transform GetSelection()
        {
            return selection;
        }

        public RaycastHit GetHitInfo()
        {
            return hitInfo;
        }

        public virtual void Check(Ray ray)
        {
            //see children for concrete implementation
        }
    }
}