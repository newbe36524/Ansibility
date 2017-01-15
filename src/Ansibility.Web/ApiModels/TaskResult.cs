using Ansibility.Web.ApiModels.Enums;
using Ansibility.Web.Services;

namespace Ansibility.Web.ApiModels
{
    public class TaskResult
    {
        public TaskState TaskState { get; set; }
        public PlaybookResult PlaybookResult { get; set; }
    }
}