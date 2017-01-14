using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Ansibility.Web.Controllers
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

        public IActionResult TestConsole(string prc, string q)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo(prc)
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    Arguments = q
                }
            };
            process.Start();
            var readToEnd = process.StandardOutput.ReadToEnd();
            var allLines = !string.IsNullOrEmpty(readToEnd) ? readToEnd : process.StandardError.ReadToEnd();
            ViewBag.Raw = allLines;
            process.WaitForExit();
            var re = new List<string>();
            foreach (var line in allLines.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries))
            {
                re.Add(line);
            }
            ViewBag.Output = re;
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}