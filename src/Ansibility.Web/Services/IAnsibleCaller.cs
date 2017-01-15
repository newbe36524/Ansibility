using System.Threading.Tasks;

namespace Ansibility.Web.Services
{
    public interface IAnsibleCaller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="playbook"></param>
        /// <param name="inventory"></param>
        /// <returns>taskId</returns>
        Task<string> ExecutePlaybookAsync(string playbook, string inventory);

        Task<PlaybookResult> GetResultAsync(string taskId);

        bool IsFinished { get; }
    }
}