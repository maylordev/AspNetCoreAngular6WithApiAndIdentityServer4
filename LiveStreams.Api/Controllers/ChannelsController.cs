using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveStreams.Api.Models;
using LiveStreams.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LiveStreams.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelsController : Controller
    {
        private readonly IChannelRepository _channelRepo;

        public ChannelsController(
            IChannelRepository channelRepo
        )
        {
            _channelRepo = channelRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<ChannelModel>>> Get()
        {
            var channels = await _channelRepo.GetAllChannels();

            return channels.ToList();
        }

    }
}