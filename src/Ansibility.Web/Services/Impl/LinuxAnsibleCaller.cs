using System;
using System.IO;
using System.Threading.Tasks;
using Ansibility.Web.Common;
using Ansibility.Web.Exceptions;
using Ansibility.Web.Options;

namespace Ansibility.Web.Services.Impl
{
    internal class LinuxAnsibleCaller : IAnsibleCaller
    {
        private readonly ICmdCaller _cmdCaller;
        private readonly AnsibilityOptions _options;
        private CmdResult _cmdResult;
        private string _taskId;

        bool IAnsibleCaller.IsFinished => _cmdCaller.CmdState == CmdState.Stopped;

        public LinuxAnsibleCaller(ICmdCaller cmdCaller, IOptions<AnsibilityOptions> options)
        {
            _cmdCaller = cmdCaller;
            _options = options.Options;
        }

        async Task<string> IAnsibleCaller.ExecutePlaybookAsync(string playbook, string inventory)
        {
            _taskId = Guid.NewGuid().ToString();
            var basePath = Path.Combine(_options.WorkingDirectory, _taskId);
            DirectoryExtensions.CreateIfNotExsist(basePath);
            var playbookPath = Path.Combine(basePath, $"{nameof(playbook)}.yml");
            await CreateNotExecuteFile(playbookPath, playbook);
            var inventoryPath = Path.Combine(basePath, nameof(inventory));
            await CreateNotExecuteFile(inventoryPath, inventory);
            var argb = new CmdArgumentBuilder(Path.GetFullPath(playbookPath), "-i", Path.GetFullPath(inventoryPath));
            try
            {
                _cmdResult = await _cmdCaller.CallAsync("/usr/bin/ansible-playbook", argb.Build());
                return _taskId;
            }
            catch (FileNotFoundException e)
            {
                throw new AnsibleNotInstalledException("/usr/bin/ansible-playbook", e);
            }
        }

        async Task<PlaybookResult> IAnsibleCaller.GetResultAsync(string taskId)
        {
            if (taskId != _taskId)
            {
                throw new ArgumentOutOfRangeException(nameof(taskId));
            }
            var re = await _cmdResult.StandardOutput.ReadToEndAsync();
            if (string.IsNullOrEmpty(re))
            {
                re = await _cmdResult.StandardError.ReadToEndAsync();
            }
            return await Task.FromResult(new PlaybookResult
            {
                TaskId = taskId,
                Raw = re,
            });
        }

        async Task CreateNotExecuteFile(string fullFilePath, string content)
        {
            using (var fs = new FileStream(fullFilePath, FileMode.CreateNew, FileAccess.Write))
            {
                using (var sw = new StreamWriter(fs))
                {
                    await sw.WriteAsync(content);
                }
            }
            var argb = new CmdArgumentBuilder("-x", fullFilePath);
            await _cmdCaller.CallAsync("/bin/chmod", argb.Build());
        }
    }
}