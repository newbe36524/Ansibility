using System.Threading.Tasks;
using Ansibility.Web.ApiModels;
using Ansibility.Web.ApiModels.Enums;
using Ansibility.Web.Common.Mvc.Attributes;
using Ansibility.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ansibility.Web.Controllers.Apis
{
    [SmallCamelRoute(nameof(TaskResultsController))]
    public class TaskResultsController : Controller
    {
        private readonly ITaskCenter _taskCenter;

        public TaskResultsController(ITaskCenter taskCenter)
        {
            _taskCenter = taskCenter;
        }

        [HttpGet]
        [IdRoute]
        public async Task<TaskResult> GetResult(string id)
        {
            var state = await _taskCenter.GetStateAsync(id);
            if (state == TaskState.Finished)
            {
                return new TaskResult
                {
                    PlaybookResult = await _taskCenter.GetResultAsync(id),
                    TaskState = TaskState.Finished
                };
            }
            return new TaskResult
            {
                TaskState = state
            };
        }
    }
}