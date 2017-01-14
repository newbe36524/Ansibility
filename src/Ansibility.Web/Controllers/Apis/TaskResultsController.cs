using System.Threading.Tasks;
using Ansibility.Web.Ansible;
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
        public async Task<PlaybookResult> GetResult(string id)
        {
            var result = await _taskCenter.GetResultAsync(id);
            return result;
        }
    }
}