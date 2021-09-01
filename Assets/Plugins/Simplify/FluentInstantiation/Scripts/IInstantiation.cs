namespace Simplify.FluentInstantiation
{
    public interface IInstantiation<out T>
    {
        T Instantiate();
    }
}