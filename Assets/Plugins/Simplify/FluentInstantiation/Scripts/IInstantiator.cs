using UnityEngine;

namespace Simplify.FluentInstantiation
{
    public interface IInstantiator<T> where T : Object
    {
        T Instantiate(T objectToInstantiate, Transform parent);
        T Instantiate(T objectToInstantiate, Vector3 position, Quaternion rotation);
        T Instantiate(T objectToInstantiate, Vector3 position, Quaternion rotation, Transform parent);
    }
}