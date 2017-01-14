namespace Ansibility.Web.Common
{
    public interface IOptions
    {
    }

    public interface IOptions<out T> : IOptions where T : IOptions
    {
        T Options { get; }
    }

    public class OptionsBase<T> : IOptions<T> where T : IOptions
    {
        // ReSharper disable once SuspiciousTypeConversion.Global
        public T Options => (T) (IOptions) this;
    }
}