using UnityEngine;

namespace GD
{
    /// <summary>
    /// Provides extension methods for Mathf
    /// </summary>
    public static class GDMathf
    {
        /// <summary>
        /// Clamps an angle in degrees to the range [-360, 360]
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360f) angle += 360f;
            if (angle > 360f) angle -= 360f;
            return Mathf.Clamp(angle, min, max);
        }

        /// <summary>
        /// Converts degrees to radians
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns></returns>
        public static float ToRadians(float degrees)
        {
            //return degrees * Mathf.Deg2Rad;
            //180 degs = Mathf.PI
            return Mathf.PI * degrees / 180f;
        }
    }
}