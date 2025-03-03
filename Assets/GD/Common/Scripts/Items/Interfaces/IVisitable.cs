using UnityEngine;

namespace GD.Data
{
    /// <summary>
    /// Items that implement this interface can be visited by other objects e.g. waypoints
    /// </summary>
    public interface IVisitable
    {
        void Visit(GameObject visitor);
    }
}