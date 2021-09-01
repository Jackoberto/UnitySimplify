using System;
using Object = UnityEngine.Object;

namespace Simplify.FluentInstantiation
{
    public interface ISetupInstantiation<T> : IPositionOrParent<T> where T : Object
    {
        IPositionOrParent<T> WithInstantiator(IInstantiator<T> instantiator);
        ISetupInstantiation<T> WithSetupMethod(Func<T, T> t);
        ISetupInstantiation<T> WithSetupMethod(Action<T> t);
    }
}