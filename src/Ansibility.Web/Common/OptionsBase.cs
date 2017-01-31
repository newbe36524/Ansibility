namespace Ansibility.Web.Common
{
    public class OptionsBase<T> : IOptions<T> where T : IOptions
    {
        // ReSharper disable once SuspiciousTypeConversion.Global
        public T Options => (T) (IOptions) this;
    }
}