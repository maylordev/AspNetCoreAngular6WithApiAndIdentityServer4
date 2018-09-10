using LiveStreams.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LiveStreams.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelsController : Controller
    {
        [HttpGet]
        [Route("{*catch-all}")]
        public IActionResult Get()
        {
            LiveStreamsAppContext context = HttpContext.RequestServices.GetService(typeof(LiveStreams.Api.Models.LiveStreamsAppContext)) as LiveStreamsAppContext;

            return Json(context.GetAllChannels());
        }

    }
}