using System;
using Object = UnityEngine.Object;

namespace Simplify.FluentInstantiation
{
    public interface ISetupInstantiation<T> : IPositionOrParent<T> where T : Object
    {
        public IPositionOrParent<T> WithInstantiator(IInstantiator<T> instantiator);
        public ISetupInstantiation<T> WithSetupMethod(Func<T, T> t);
        public ISetupInstantiation<T> WithSetupMethod(Action<T> t);
    }
}