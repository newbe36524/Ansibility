using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Ansibility.Web.Services.Impl

{
    internal class CmdCaller : ICmdCaller
    {
        private readonly ILogger<CmdCaller> _logger;

        public CmdCaller(ILogger<CmdCaller> logger)
        {
            _logger = logger;
        }

        async Task<string> ICmdCaller.CallAsync(string process, string arguments)
        {
            _logger.LogInformation($"call cmd {process}{arguments}");
            var p = new Process
            {
                StartInfo = new ProcessStartInfo(process)
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    Arguments = arguments
                }
            };
            p.Start();
            var readToEnd = await p.StandardOutput.ReadToEndAsync();
            var allLines = !string.IsNullOrEmpty(readToEnd) ? readToEnd : await p.StandardError.ReadToEndAsync();
            p.WaitForExit();
            return allLines;
        }
    }
}