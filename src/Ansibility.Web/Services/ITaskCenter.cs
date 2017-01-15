using System.Threading.Tasks;
using Ansibility.Web.ApiModels;
using Ansibility.Web.ApiModels.Enums;
using Ansibility.Web.Exceptions;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        /// <exception cref="TaskNotFoundException"></exception>
        Task<PlaybookResult> GetResultAsync(string taskId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        /// <exception cref="TaskNotFoundException"></exception>
        Task<TaskState> GetStateAsync(string taskId);
    }
}