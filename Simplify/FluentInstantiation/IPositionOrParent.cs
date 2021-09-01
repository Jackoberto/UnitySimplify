using UnityEngine;

namespace Simplify.FluentInstantiation
{
    public interface IPositionOrParent<out T>
    {
        IRotationOrInstantiation<T> AtPosition(Vector3 position);
    
        IParentInstantiation<T> ParentedTo(Transform parent);
    }
}