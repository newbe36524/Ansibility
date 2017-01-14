using System.Threading.Tasks;

namespace Ansibility.Web.Services
{
    public interface ICmdCaller
    {
        Task<string> CallAsync(string process, string arguments);
    }
}