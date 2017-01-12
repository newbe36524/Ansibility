using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ansibility.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult TestConsole()
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo("dotnet")
                {
                    UseShellExecute =false,
                    RedirectStandardOutput = true,
                }
                
            };
            process.Start();
            var output = process.StandardOutput.ReadLine();
            process.WaitForExit();
            return View(output);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
