using System;
using Ansibility.Web.Common;
using Ansibility.Web.Options;
using Ansibility.Web.Services;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.Logging;

namespace Ansibility.Web.Ansible.Impl
{
    internal class AnsibleCallerFactory : IAnsibleCallerFactory
    {
        private readonly ICmdCaller _cmdCaller;
        private readonly ILogger<DebuggerAnsibleCaller> _logger;
        private readonly AnsibilityOptions _options;

        public AnsibleCallerFactory(ICmdCaller cmdCaller, IOptions<AnsibilityOptions> options,
            ILogger<DebuggerAnsibleCaller> logger)
        {
            _cmdCaller = cmdCaller;
            _logger = logger;
            _options = options.Options;
        }

        IAnsibleCaller IAnsibleCallerFactory.GetAnsibleCaller()
        {
            switch (RuntimeEnvironment.OperatingSystemPlatform)
            {
                case Platform.Unknown:
                    throw new PlatformNotSupportedException();
                case Platform.Windows:
                    return new DebuggerAnsibleCaller(_logger);
                case Platform.Linux:
                    return new LinuxAnsibleCaller(_cmdCaller, _options);
                case Platform.Darwin:
                    throw new PlatformNotSupportedException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}