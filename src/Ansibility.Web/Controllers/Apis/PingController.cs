using System;
using Ansibility.Web.Common;
using Microsoft.AspNetCore.Mvc;

namespace Ansibility.Web.Controllers.Apis
{
    [SmallCamelRoute(nameof(PingController))]
    public class PingController : Controller
    {
        [HttpPost]
        public string Post()
        {
            return DateTime.Now.ToString("o");
        }
    }
}