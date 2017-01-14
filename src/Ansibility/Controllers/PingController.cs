﻿using System;
using Microsoft.AspNetCore.Mvc;

namespace Ansibility.Controllers
{
    [Route("api/[controller]")]
    public class PingController : Controller
    {
        [HttpPost]
        public string Post()
        {
            return DateTime.Now.ToString("o");
        }
    }
}