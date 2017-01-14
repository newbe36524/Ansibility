using Ansibility.Web.Common;

namespace Ansibility.Web.Options
{
    public class AnsibilityOptions:OptionsBase<AnsibilityOptions>
    {
        public string WorkingDirectory { get; set; } = "WorkingDir";
    }
}