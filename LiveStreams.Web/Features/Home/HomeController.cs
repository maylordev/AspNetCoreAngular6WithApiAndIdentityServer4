using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LiveStreamsApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LiveStreamsApp.Features.Home
{
    public class HomeController : Controller
    {
        // gets called when going to "/" from a new session

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
