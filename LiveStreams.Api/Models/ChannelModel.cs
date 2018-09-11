using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveStreams.Api.Models.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveStreams.Api.Models
{
    [Table("Channels")]
    public partial class ChannelModel : IEntity
    {
        public ChannelModel()
        {
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string StreamUrl { get; set; }
        public string ChannelId { get; set; }
        public string SubscriptionId { get; set; }
        public string BrandingImage { get; set; }
        public string Branding { get; set; }
    }
}