using System.Threading.Tasks;

namespace Ansibility.Web.Services
{
    public interface ICmdCaller
    {
        Task<CmdResult> CallAsync(string process, string arguments);
        CmdState CmdState { get; }
    }
}