using UnityEngine;

namespace GD.Selection
{
    /// <summary>
    /// Casts a ray with a sphere that moves along the ray to select objects.
    /// This approach is less sensitive than the RayCastSelector as the sphere
    /// effectively broadens cross sectional area across which the ray operates.
    /// </summary>
    public class SphereCastSelector : BaseCastSelector
    {
        [Header("Debug Gizmo Properties")]
        [SerializeField]
        [ColorUsage(false)]
        protected Color sphereColor = Color.yellow;

        [SerializeField]
        [Range(0.1f, 4)]
        [Tooltip("Define the sensitivity radius of the sphere to allow selection")]
        private float sphereRadius = 0.5f;

        [SerializeField]
        [Range(0, 1)]
        [Tooltip("Allows the designer to move the sphere along the length of the ray defined by maxDistance")]
        private float sphereCastPositionAsProportion;

        public override void Check(Ray ray)
        {
            selection = null;
            this.ray = ray; //cache the ref to the ray for use in the gizmo

            if (Physics.SphereCast(ray, sphereRadius, out hitInfo, maxDistance, layerMask.value))
            {
                var currentSelection = hitInfo.transform;
                if (currentSelection.CompareTag(selectableTag))
                    selection = currentSelection;
            }
        }

        // Implement this OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn
        private void OnDrawGizmos()
        {
            Gizmos.color = sphereColor;
            Vector3 pointOnRay = ray.origin + ray.direction * maxDistance * sphereCastPositionAsProportion;
            Gizmos.DrawWireSphere(pointOnRay, sphereRadius);
        }
    }
}