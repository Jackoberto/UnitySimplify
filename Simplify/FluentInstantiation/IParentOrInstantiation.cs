using UnityEngine;

namespace Simplify.FluentInstantiation
{
    public interface IParentOrInstantiation<out T>
    {
        T Instantiate();
        IInstantiation<T> ParentedTo(Transform parent);
    }
}