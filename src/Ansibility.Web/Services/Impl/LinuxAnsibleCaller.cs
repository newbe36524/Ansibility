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

        public LinuxAnsibleCaller(ICmdCaller cmdCaller, IOptions<AnsibilityOptions> options)
        {
            _cmdCaller = cmdCaller;
            _options = options.Options;
        }

        async Task<PlaybookResult> IAnsibleCaller.ExecutePlaybookAsync(string playbook, string inventory)
        {
            var id = Guid.NewGuid().ToString();
            var basePath = Path.Combine(_options.WorkingDirectory, id);
            DirectoryExtensions.CreateIfNotExsist(basePath);
            var playbookPath = Path.Combine(basePath, $"{nameof(playbook)}.yml");
            await CreateNotExecuteFile(playbookPath, playbook);
            var inventoryPath = Path.Combine(basePath, nameof(inventory));
            await CreateNotExecuteFile(inventoryPath, inventory);
            var argb = new CmdArgumentBuilder(Path.GetFullPath(playbookPath), "-i", Path.GetFullPath(inventoryPath));
            try
            {
                var cmdResult = await _cmdCaller.CallAsync("/usr/bin/ansible-playbook", argb.Build());
                return new PlaybookResult
                {
                    TaskId = id,
                    Raw = cmdResult,
                };
            }
            catch (FileNotFoundException e)
            {
                throw new AnsibleNotInstalledException("/usr/bin/ansible-playbook", e);
            }
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