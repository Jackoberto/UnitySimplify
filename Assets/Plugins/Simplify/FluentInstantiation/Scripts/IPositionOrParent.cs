using UnityEngine;

namespace Simplify.FluentInstantiation
{
    public interface IPositionOrParent<out T>
    {
        public IRotationOrInstantiation<T> AtPosition(Vector3 position);
    
        public IParentInstantiation<T> ParentedTo(Transform parent);
    }
}