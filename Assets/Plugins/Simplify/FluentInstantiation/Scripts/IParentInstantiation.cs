namespace Simplify.FluentInstantiation
{
    public interface IParentInstantiation<out T>
    {
        T Instantiate();
    }
}