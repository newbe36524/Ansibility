using System;

namespace Ansibility.Web.Exceptions
{
    public class AnsibleNotInstalledException : Exception
    {
        public AnsibleNotInstalledException(string exePath, Exception innerException)
            : base($"ansible not installed. {exePath} not found", innerException)
        {
        }
    }
}