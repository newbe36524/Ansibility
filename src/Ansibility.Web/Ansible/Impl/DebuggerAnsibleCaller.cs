using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Ansibility.Web.Ansible.Impl
{
    internal class DebuggerAnsibleCaller : IAnsibleCaller
    {
        private readonly ILogger<DebuggerAnsibleCaller> _logger;

        public DebuggerAnsibleCaller(ILogger<DebuggerAnsibleCaller> logger)
        {
            _logger = logger;
        }

        async Task<PlaybookResult> IAnsibleCaller.ExecutePlaybookAsync(string playbook, string inventory)
        {
            _logger.LogInformation($"debug call \r\nplaybook:{playbook}\r\ninventory:{inventory}");
            return await Task.FromResult(new PlaybookResult
            {
                TaskId = Guid.NewGuid().ToString(),
                Raw = "debugger ansible caller",
            });
        }
    }
}