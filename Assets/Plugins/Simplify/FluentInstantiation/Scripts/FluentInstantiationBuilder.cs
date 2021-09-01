using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Simplify.FluentInstantiation
{
    internal class FluentInstantiationBuilder<T> : ISetupInstantiation<T>, IParentInstantiation<T>,
        IRotationOrInstantiation<T>, IInstantiation<T>, IParentOrInstantiation<T> where T : Object
    {
        private IInstantiator<T> instantiator;
        private Transform parent;
        private Vector3 position;
        private Quaternion rotation;
        private readonly T objectToInstantiate;
        private readonly Queue<object> setupMethods = new Queue<object>();

        internal FluentInstantiationBuilder(T objectToInstantiate)
        {
            this.objectToInstantiate = objectToInstantiate;
            instantiator = new DefaultInstantiator<T>();
        }

        public ISetupInstantiation<T> WithSetupMethod(Func<T, T> t)
        {
            setupMethods.Enqueue(t);
            return this;
        }

        public ISetupInstantiation<T> WithSetupMethod(Action<T> t)
        {
            setupMethods.Enqueue(t);
            return this;
        }

        public IPositionOrParent<T> WithInstantiator(IInstantiator<T> instantiator)
        {
            this.instantiator = instantiator;
            return this;
        }

        public IRotationOrInstantiation<T> AtPosition(Vector3 position)
        {
            this.position = position;
            return this;
        }

        public IParentInstantiation<T> ParentedTo(Transform parent)
        {
            this.parent = parent;
            return this;
        }

        public IParentOrInstantiation<T> WithRotation(Quaternion rotation)
        {
            this.rotation = rotation;
            return this;
        }

        T IRotationOrInstantiation<T>.Instantiate()
        {
            var instance = instantiator.Instantiate(objectToInstantiate, position, Quaternion.identity);
            instance = RunSetupMethods(instance);
            return instance;
        }

        IInstantiation<T> IParentOrInstantiation<T>.ParentedTo(Transform parent)
        {
            this.parent = parent;
            return this;
        }

        T IInstantiation<T>.Instantiate()
        {
            var instance = instantiator.Instantiate(objectToInstantiate, position, Quaternion.identity, parent);
            instance = RunSetupMethods(instance);
            return instance;
        }

        T IParentInstantiation<T>.Instantiate()
        {
            var instance = instantiator.Instantiate(objectToInstantiate, parent);
            instance = RunSetupMethods(instance);
            return instance;
        }

        T IParentOrInstantiation<T>.Instantiate()
        {
            var instance = instantiator.Instantiate(objectToInstantiate, position, rotation);
            instance = RunSetupMethods(instance);
            return instance;
        }

        private T RunSetupMethods(T instance)
        {
            while (setupMethods.Count > 0)
            {
                var method = setupMethods.Dequeue();
                switch (method)
                {
                    case Func<T, T> func:
                        instance = func.Invoke(instance);
                        break;
                    case Action<T> action:
                        action.Invoke(instance);
                        break;
                }
            }

            return instance;
        }
    }
}