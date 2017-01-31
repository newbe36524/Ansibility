using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Ansibility.Web.Services
{
    public interface ITaskResultStore
    {
        Task<PlaybookResult> GetResultAsync([NotNull] string taskId);

        Task<string> SaveResultAsync([NotNull] PlaybookResult result);
    }
}