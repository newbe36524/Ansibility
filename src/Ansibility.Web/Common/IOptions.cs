namespace Ansibility.Web.Common
{
    public interface IOptions
    {
    }

    public interface IOptions<out T> : IOptions where T : IOptions
    {
        T Options { get; }
    }
}