using UnityEngine;

public static class Vector3Extensions
{
    /// <summary>
    ///Sets y-axis to height on Vector3
    /// </summary>
    /// <param name="target"></param>
    /// <param name="height"></param>
    /// <example>
    ///         Vector3 pos = new Vector3(1, -4, 5);
    ///         pos.SetAboveGround(5);
    /// </example>
    public static void SetAboveGround(this ref Vector3 target, float height)
    {
        if (target.y < 0)
            target.y = height;
    }

    /// <summary>
    /// Adds the specified values to the vector
    /// </summary>
    /// <param name="vector"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    /// <returns></returns>
    /// <see cref="https://github.com/adammyhre/3D-Platformer/blob/master/Assets/_Project/Scripts/Utils/Extensions/Vector3Extensions.cs"/>
    public static Vector3 Add(this Vector3 vector, float? x = null, float? y = null, float? z = null)
    {
        return new Vector3(vector.x + (x ?? 0), vector.y + (y ?? 0), vector.z + (z ?? 0));
    }

    /// <summary>
    /// Sets the specified values to the vector
    /// </summary>
    /// <param name="vector"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    /// <returns></returns>
    /// <see cref="https://github.com/adammyhre/3D-Platformer/blob/master/Assets/_Project/Scripts/Utils/Extensions/Vector3Extensions.cs"/>
    public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null)
    {
        return new Vector3(x ?? vector.x, y ?? vector.y, z ?? vector.z);
    }
}