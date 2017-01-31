using Ansibility.Web.Services;
using Ansibility.Web.Services.Impl;
using Autofac.Extras.Moq;
using FluentAssertions;

namespace Ansibility.Web.Tests.Services
{
    public class TaskResultStoreTests
    {
        public async void GetNullResult()
        {
            using (var mock = AutoMock.GetStrict())
            {
                ITaskResultStore service = mock.Create<TaskResultStore>();
                var result = await service.GetResultAsync("notExists");
                result.Should().BeNull();
            }
        }
    }
}