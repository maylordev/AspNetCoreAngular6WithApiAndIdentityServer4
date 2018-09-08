using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LiveStreamsApp.Features.Counter
{
    // gets called when going to "/couter" from a new session
	[Route("counter")]
    public class CounterController : Controller
    {
		[Route("{*catch-all}")]
        public IActionResult Index()
        {
            return View();
        }
    }
}