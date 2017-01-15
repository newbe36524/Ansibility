namespace Ansibility.Web.Services
{
    public interface IAnsibleCallerFactory
    {
        IAnsibleCaller GetAnsibleCaller();
    }
}