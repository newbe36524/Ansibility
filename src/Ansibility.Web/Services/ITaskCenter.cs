using System.Threading.Tasks;
using Ansibility.Web.ApiModels;

namespace Ansibility.Web.Services
{
    public interface ITaskCenter
    {
        /// <summary>
        /// add task
        /// </summary>
        /// <param name="ansibilityTask"></param>
        /// <returns>taskid</returns>
        Task<string> AddTaskAsync(AnsibilityTask ansibilityTask);

        Task<PlaybookResult> GetResultAsync(string taskId);
    }
}