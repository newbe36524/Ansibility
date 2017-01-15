using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ansibility.Web.ApiModels;
using Ansibility.Web.ApiModels.Enums;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace Ansibility.Intergration.Tests
{
    public class ApiTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public ApiTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        /// <summary>
        /// task will run at once call it , but result will be avaliable until task is finished
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task AsyncTaskCallTest()
        {
            const string urlBase = "http://localhost:8000/api/";
            const string taskUrl = urlBase + "tasks/";
            const string taskResultsUrl = urlBase + "taskResults/";
            using (var client = new HttpClient())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(new AnsibilityTask
                {
                    Inventory = @"[localhost]
            local ansible_connection=local",
                    Playbook = @"---
            - name: test
              hosts: all
              tasks: 
              - name: ls
                raw: sleep 3 "
                }), Encoding.UTF8, "application/json");
                var re = await client.PostAsync(taskUrl, stringContent);
                re.IsSuccessStatusCode.Should().BeTrue();
                var idmodel = await re.Content.ReadAsStringAsync();
                var id = JsonConvert.DeserializeObject<IdModel>(idmodel);
                _testOutputHelper.WriteLine(id.Id);
                re = await client.GetAsync(taskResultsUrl + id.Id);
                re.IsSuccessStatusCode.Should().BeTrue();
                (await re.Content.ReadAsObject<TaskResult>()).TaskState.Should()
                    .Be(TaskState.Running, "task is not finished");
                Thread.Sleep(6000);
                re = await client.GetAsync(taskResultsUrl + id.Id);
                re.IsSuccessStatusCode.Should().BeTrue();
                var foo = await re.Content.ReadAsObject<TaskResult>();
                foo.TaskState.Should().Be(TaskState.Finished, "task is finished");
                foo.PlaybookResult.Raw.Should().NotBeNullOrEmpty();
                foo.PlaybookResult.TaskId.Should().Be(id.Id);
                _testOutputHelper.WriteLine(JsonConvert.SerializeObject(foo));
            }
        }
    }

    public static class HttpContentExtensions
    {
        public static async Task<T> ReadAsObject<T>(this HttpContent content)
        {
            var str = await content.ReadAsStringAsync();
            var re = JsonConvert.DeserializeObject<T>(str);
            return re;
        }
    }
}