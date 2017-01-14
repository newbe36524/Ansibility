using System;
using System.IO;
using System.Threading.Tasks;
using Ansibility.Web.Common;
using Ansibility.Web.Options;
using Ansibility.Web.Services;

namespace Ansibility.Web.Ansible.Impl
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
            File.AppendAllText(playbookPath, playbook);
            File.AppendAllText(Path.Combine(basePath, nameof(inventory)), inventory);
            var argb = new CmdArgumentBuilder(Path.GetFullPath(playbookPath), "-i", Path.GetFullPath(inventory));
            var cmdResult = await _cmdCaller.CallAsync("/usr/bin/ansible-playbook", argb.Build());
            return new PlaybookResult
            {
                TaskId = id,
                Raw = cmdResult,
            };
        }
    }
}