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

    /*Some badly named quick demo methods*/
    /*
    public static void GetInfo(this ref Vector3 target, out float someCalc)
    {
        someCalc = target.y * target.x * target.z;
    }

    public static float GetInfo(this ref Vector3 target)
    {
        return target.y * target.x * target.z;
    }
    */
}