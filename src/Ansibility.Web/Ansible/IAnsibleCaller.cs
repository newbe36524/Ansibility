using System.Threading.Tasks;

namespace Ansibility.Web.Ansible
{
    public interface IAnsibleCaller
    {
        Task<PlaybookResult> ExecutePlaybookAsync(string playbook, string inventory);
    }
}