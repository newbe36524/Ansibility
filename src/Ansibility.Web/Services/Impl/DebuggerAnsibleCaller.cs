using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Ansibility.Web.Services.Impl
{
    internal class DebuggerAnsibleCaller : IAnsibleCaller
    {
        private readonly ILogger<DebuggerAnsibleCaller> _logger;

        public DebuggerAnsibleCaller(ILogger<DebuggerAnsibleCaller> logger)
        {
            _logger = logger;
        }

        async Task<string> IAnsibleCaller.ExecutePlaybookAsync(string playbook, string inventory)
        {
            _logger.LogInformation($"debug call {Environment.NewLine}playbook:{playbook}{Environment.NewLine}inventory:{inventory}");
            return await Task.FromResult(Guid.NewGuid().ToString());
        }

        async Task<PlaybookResult> IAnsibleCaller.GetResultAsync(string taskId)
        {
            return await Task.FromResult(new PlaybookResult
            {
                TaskId = taskId,
                Raw = "debugger ansible caller",
            });
        }

        bool IAnsibleCaller.IsFinished => true;
    }
}