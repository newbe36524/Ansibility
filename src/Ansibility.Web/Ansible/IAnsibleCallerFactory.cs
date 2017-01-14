namespace Ansibility.Web.Ansible
{
    public interface IAnsibleCallerFactory
    {
        IAnsibleCaller GetAnsibleCaller();
    }
}