using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveStreams.Api.Models
{
    public class ChannelModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string StreamUrl { get; set; }
        public string ChannelId { get; set; }
        public string SubscriptionId { get; set; }
        public dynamic Branding { get; set; }
    }
}