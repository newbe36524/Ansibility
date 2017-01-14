using System;
using System.IO;
using Ansibility.Web.ApiModels;
using Ansibility.Web.Common;
using Ansibility.Web.Options;
using Microsoft.AspNetCore.Mvc;

namespace Ansibility.Web.Controllers.Apis
{
    [SmallCamelRoute(nameof(TasksController))]
    public class TasksController : Controller
    {
        private readonly AnsibilityOptions _options;

        public TasksController(IOptions<AnsibilityOptions> options)
        {
            _options = options.Options;
        }

        [HttpPost]
        public IdModel Post([FromBody] AnsibilityTask task)
        {
            var id = Guid.NewGuid().ToString();
            var basePath = Path.Combine(_options.WorkingDirectory, id);
            DirectoryExtensions.CreateIfNotExsist(basePath);
            System.IO.File.AppendAllText(Path.Combine(basePath, nameof(task.Playbook)), task.Playbook);
            System.IO.File.AppendAllText(Path.Combine(basePath, nameof(task.Inventory)), task.Inventory);
            return new IdModel
            {
                Id = id,
            };
        }
    }
}