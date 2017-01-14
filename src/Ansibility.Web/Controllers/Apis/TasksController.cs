using System.Threading.Tasks;
using Ansibility.Web.ApiModels;
using Ansibility.Web.Common.Mvc.Attributes;
using Ansibility.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ansibility.Web.Controllers.Apis
{
    [SmallCamelRoute(nameof(TasksController))]
    public class TasksController : Controller
    {
        private readonly ITaskCenter _taskCenter;

        public TasksController(ITaskCenter taskCenter)
        {
            _taskCenter = taskCenter;
        }

        [HttpPost]
        public async Task<IdModel> Post([FromBody] AnsibilityTask task)
        {
            var taskid = await _taskCenter.AddTaskAsync(task);
            return new IdModel
            {
                Id = taskid,
            };
        }
    }
}