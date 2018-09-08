

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiveStreams.Api.Models;

namespace LiveStreams.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	public class WeatherController : Controller
    {
		private static string[] Summaries = new[]
	   {
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};
		// GET: /<controller>/
		[Route("{*catch-all}")]
		public IActionResult Index()
        {
			var rng = new Random();
			var forecasts = Enumerable.Range(1, 5).Select(c => new WeatherModel
			{
				DateFormatted = DateTime.Now.AddDays(c).ToString("d"),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			});
			// ReSharper disable once Mvc.ViewNotResolved
			return View(forecasts);
		}
    }
}
