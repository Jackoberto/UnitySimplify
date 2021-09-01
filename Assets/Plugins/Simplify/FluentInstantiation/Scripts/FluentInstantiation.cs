using UnityEngine;

namespace Simplify.FluentInstantiation
{
    public static class FluentInstantiation
    {
        public static ISetupInstantiation<T> InstantiateObject<T>(T objectToInstantiate) where T : Object
        {
            return new FluentInstantiationBuilder<T>(objectToInstantiate);
        }
    }
}