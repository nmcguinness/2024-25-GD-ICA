using UnityEngine;

namespace GD.Selection
{
    /// <summary>
    /// Any class that implements this interface can provide a Ray.
    /// </summary>
    /// <see cref="MouseScreenRayProvider"/>
    /// <see cref="GameObjectRayProvider"/>
    public interface IRayProvider
    {
        Ray CreateRay();
    }
}