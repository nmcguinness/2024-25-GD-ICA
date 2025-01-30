using UnityEngine;

namespace GD.Selection
{
    /// <summary>
    /// Casts a ray from the camera or game object (based on provider type) and checks for selectable objects.
    /// </summary>
    public class RayCastSelector : BaseCastSelector
    {
        [Header("Debug Gizmo Properties")]
        [SerializeField]
        [ColorUsage(false)]
        protected Color rayColor = Color.yellow;

        public override void Check(Ray ray)
        {
            selection = null;
            this.ray = ray;
            if (Physics.Raycast(ray, out hitInfo, maxDistance, layerMask.value))
            {
                var currentSelection = hitInfo.transform;
                if (currentSelection.CompareTag(selectableTag))
                    selection = currentSelection;
            }
        }

        // Implement this OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn
        private void OnDrawGizmos()
        {
            Gizmos.color = rayColor;
            Gizmos.DrawLine(ray.origin,
                ray.origin + ray.direction * maxDistance);
        }
    }
}