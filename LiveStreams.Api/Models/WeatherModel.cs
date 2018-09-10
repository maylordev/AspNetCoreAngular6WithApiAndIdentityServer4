using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveStreams.Api.Models
{
    public class WeatherModel
    {
		public string DateFormatted { get; set; }
		public int TemperatureC { get; set; }
		public string Summary { get; set; }
		public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
	}
}