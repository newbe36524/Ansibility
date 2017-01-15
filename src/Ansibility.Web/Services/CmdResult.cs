using System.IO;

namespace Ansibility.Web.Services
{
    public class CmdResult
    {
        public StreamReader StandardOutput { get; set; }
        public StreamReader StandardError { get; set; }
    }
}