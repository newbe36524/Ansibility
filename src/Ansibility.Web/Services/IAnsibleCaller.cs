using System.Threading.Tasks;

namespace Ansibility.Web.Services
{
    public interface IAnsibleCaller
    {
        Task<PlaybookResult> ExecutePlaybookAsync(string playbook, string inventory);
    }
}