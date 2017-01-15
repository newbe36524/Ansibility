using System;

namespace Ansibility.Web.Exceptions
{
    public class TaskNotFoundException : Exception
    {
        public string TaskId { get; }

        public TaskNotFoundException(string taskId)
        {
            TaskId = taskId;
        }
    }
}