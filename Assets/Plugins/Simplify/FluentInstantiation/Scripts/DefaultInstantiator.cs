using UnityEngine;

namespace Simplify.FluentInstantiation
{
    public class DefaultInstantiator<T> : IInstantiator<T> where T : Object
    {
        public T Instantiate(T objectToInstantiate, Transform parent)
        {
            return Object.Instantiate(objectToInstantiate, parent);
        }

        public T Instantiate(T objectToInstantiate, Vector3 position, Quaternion rotation)
        {
            return Object.Instantiate(objectToInstantiate, position, rotation);
        }

        public T Instantiate(T objectToInstantiate, Vector3 position, Quaternion rotation, Transform parent)
        {
            return Object.Instantiate(objectToInstantiate, position, rotation, parent);
        }
    }
}