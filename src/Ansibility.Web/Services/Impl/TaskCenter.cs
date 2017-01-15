using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ansibility.Web.ApiModels;
using Ansibility.Web.ApiModels.Enums;
using Ansibility.Web.Common;
using Ansibility.Web.Exceptions;

namespace Ansibility.Web.Services.Impl
{
    internal class TaskCenter : ITaskCenter
    {
        private readonly IAnsibleCallerFactory _ansibleCallerFactory;

        private readonly IDictionary<string, IAnsibleCaller> _callers =
            new ConcurrentDictionary<string, IAnsibleCaller>();

        public TaskCenter(IAnsibleCallerFactory ansibleCallerFactory)
        {
            _ansibleCallerFactory = ansibleCallerFactory;
        }

        async Task<string> ITaskCenter.AddTaskAsync(AnsibilityTask ansibilityTask)
        {
            var ansibleCaller = _ansibleCallerFactory.GetAnsibleCaller();
            var taskId = await ansibleCaller.ExecutePlaybookAsync(ansibilityTask.Playbook, ansibilityTask.Inventory);
            _callers.Add(taskId, ansibleCaller);
            return taskId;
        }

        async Task<PlaybookResult> ITaskCenter.GetResultAsync(string taskId)
        {
            ThrowIfTaskNotExsist(taskId);
            var caller = _callers[taskId];
            if (!caller.IsFinished)
            {
                return null;
            }
            var playbookResult = await caller.GetResultAsync(taskId);
            return playbookResult;
        }

        Task<TaskState> ITaskCenter.GetStateAsync(string taskId)
        {
            ThrowIfTaskNotExsist(taskId);
            var caller = _callers[taskId];
            return caller.IsFinished
                ? Task.FromResult(TaskState.Finished)
                : Task.FromResult(TaskState.Running);
        }

        private void ThrowIfTaskNotExsist(string taskId)
        {
            if (!_callers.ContainsKey(taskId))
            {
                throw new TaskNotFoundException(taskId);
            }
        }
    }
}