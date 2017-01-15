using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Ansibility.Web.Tests
{
    public class Class1
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public Class1(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Test()
        {
            _testOutputHelper.WriteLine("asdasd");
        }
    }
}
