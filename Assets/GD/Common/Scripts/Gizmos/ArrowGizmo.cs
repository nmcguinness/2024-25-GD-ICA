using UnityEngine;

namespace GD.Tools
{
    public class ArrowGizmo : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The color of the arrow")]
        [ColorUsage(false)]
        private Color arrowColor = Color.red;

        [SerializeField]
        [Tooltip("The length of the arrow")]
        [Range(0.1f, 10f)]
        private float arrowLength = 1;

        [SerializeField]
        [Tooltip("The width of the arrow head")]
        [Range(0.1f, 5f)]
        private float arrowHeadWidth = 0.25f;

        [SerializeField]
        [Tooltip("The width of the sphere at the end of the arrow")]
        [Range(0.01f, 0.5f)]
        private float endSphereWidth = 0.025f;

        [SerializeField]
        [Tooltip("The angle of the arrow head")]
        [Range(0, 180)]
        private float arrowHeadAngle = 160;

        private void OnDrawGizmos()
        {
            // Starting point of the arrow
            Vector3 startPoint = transform.position;

            // Endpoint of the arrow in the direction of transform.forward
            Vector3 endPoint = startPoint + transform.forward * arrowLength;

            // Calculate arrowhead points
            Vector3 right = Quaternion.LookRotation(transform.forward) * Quaternion.Euler(0, arrowHeadAngle, 0) * Vector3.forward;
            Vector3 left = Quaternion.LookRotation(transform.forward) * Quaternion.Euler(0, -arrowHeadAngle, 0) * Vector3.forward;

            Vector3 rightHead = endPoint + right * arrowHeadWidth;
            Vector3 leftHead = endPoint + left * arrowHeadWidth;

            Gizmos.color = arrowColor;

            // Draw the main line of the arrow
            Gizmos.DrawLine(startPoint, endPoint);

            // Draw the arrowhead lines
            Gizmos.DrawLine(endPoint, rightHead);
            Gizmos.DrawLine(endPoint, leftHead);

            //Draw the base of the arrowhead as a sphere
            Gizmos.DrawSphere(transform.position, endSphereWidth);
        }
    }
}