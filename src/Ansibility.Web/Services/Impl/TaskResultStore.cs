using System;
using System.Threading.Tasks;

namespace Ansibility.Web.Services.Impl
{
    public class TaskResultStore : ITaskResultStore
    {
        Task<PlaybookResult> ITaskResultStore.GetResultAsync(string taskId)
        {
            throw new NotImplementedException();
        }

        Task<string> ITaskResultStore.SaveResultAsync(PlaybookResult result)
        {
            throw new NotImplementedException();
        }
    }
}