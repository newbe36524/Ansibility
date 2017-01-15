using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Ansibility.Web.Services.Impl

{
    internal class CmdCaller : ICmdCaller
    {
        private readonly ILogger<CmdCaller> _logger;
        private Process _process;

        public CmdCaller(ILogger<CmdCaller> logger)
        {
            _logger = logger;
        }

        CmdState ICmdCaller.CmdState
            => _process == null ? CmdState.NotStarted : _process.HasExited ? CmdState.Stopped : CmdState.Running;

        async Task<CmdResult> ICmdCaller.CallAsync(string process, string arguments)
        {
            _logger.LogInformation($"call cmd {process}{arguments}");
            _process = new Process
            {
                StartInfo = new ProcessStartInfo(process)
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    Arguments = arguments
                }
            };
            _process.Start();
            return await Task.FromResult(new CmdResult
            {
                StandardError = _process.StandardError,
                StandardOutput = _process.StandardOutput,
            });
        }
    }
}