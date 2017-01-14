using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ansibility.Web.Ansible;
using Ansibility.Web.ApiModels;

namespace Ansibility.Web.Services.Impl
{
    internal class TaskCenter : ITaskCenter
    {
        private readonly IAnsibleCallerFactory _ansibleCallerFactory;

        private readonly IDictionary<string, PlaybookResult> _results =
            new ConcurrentDictionary<string, PlaybookResult>();

        public TaskCenter(IAnsibleCallerFactory ansibleCallerFactory)
        {
            _ansibleCallerFactory = ansibleCallerFactory;
        }

        async Task<string> ITaskCenter.AddTaskAsync(AnsibilityTask ansibilityTask)
        {
            var re = await _ansibleCallerFactory.GetAnsibleCaller()
                .ExecutePlaybookAsync(ansibilityTask.Playbook, ansibilityTask.Inventory);
            _results.Add(re.TaskId, re);
            return re.TaskId;
        }

        async Task<PlaybookResult> ITaskCenter.GetResultAsync(string taskId)
        {
            if (_results.ContainsKey(taskId))
            {
                return await Task.FromResult(_results[taskId]);
            }
            return await Task.FromResult((PlaybookResult) null);
        }
    }
}