using Sirenix.OdinInspector;
using UnityEngine;

namespace GD.Selection
{
    /// <summary>
    /// Provides a ray that originates from a target GameObject.
    /// </summary>
    public class GameObjectRayProvider : MonoBehaviour, IRayProvider
    {
        [SerializeField]
        private GameObject targetObject;

        [Header("Debug Gizmo Properties")]
        [SerializeField]
        private Color rayColor = Color.yellow;

        [SerializeField]
        [Range(0.1f, 100)]
        private float rayLength = 10;

        [ShowInInspector, ReadOnly]
        private Ray ray;

        public Ray CreateRay()
        {
            ray = new Ray(targetObject.transform.position, targetObject.transform.forward);
            return ray;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = rayColor;
            Gizmos.DrawLine(targetObject.transform.position,
                targetObject.transform.position + targetObject.transform.forward * rayLength);

            // Gizmos.DrawWireSphere(targetObject.transform.position, 2);
        }
    }
}