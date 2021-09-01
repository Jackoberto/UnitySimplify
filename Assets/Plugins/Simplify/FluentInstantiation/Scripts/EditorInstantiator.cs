using UnityEngine;

namespace Simplify.FluentInstantiation
{
    public class EditorInstantiator<T> : IInstantiator<T> where T : Object
    {
        public T Instantiate(T objectToInstantiate, Transform parent)
        {
            return UnityEditor.PrefabUtility.InstantiatePrefab(objectToInstantiate, parent) as T;
        }

        public T Instantiate(T objectToInstantiate, Vector3 position, Quaternion rotation)
        {
            var instance = UnityEditor.PrefabUtility.InstantiatePrefab(objectToInstantiate) as T;
            if (instance is Component component)
            {
                var transform = component.transform.transform;
                transform.position = position;
                transform.rotation = rotation;
            }

            return instance;
        }

        public T Instantiate(T objectToInstantiate, Vector3 position, Quaternion rotation, Transform parent)
        {
            var instance = UnityEditor.PrefabUtility.InstantiatePrefab(objectToInstantiate, parent) as T;
            if (instance is Component component)
            {
                var transform = component.transform.transform;
                transform.position = position;
                transform.rotation = rotation;
            }

            return instance;
        }
    }
}