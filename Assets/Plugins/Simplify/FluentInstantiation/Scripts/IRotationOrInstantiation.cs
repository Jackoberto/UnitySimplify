using UnityEngine;

namespace Simplify.FluentInstantiation
{
    public interface IRotationOrInstantiation<out T>
    {
        IParentOrInstantiation<T> WithRotation(Quaternion rotation);
        T Instantiate();
    }
}