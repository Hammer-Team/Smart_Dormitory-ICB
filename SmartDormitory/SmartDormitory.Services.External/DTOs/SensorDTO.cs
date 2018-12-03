using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDormitory.Services.External.DTOs
{
    public class SensorDTO
    {
        [JsonProperty(PropertyName = "sensorId")]
        public string SensorId { get; set; }

        [JsonProperty(PropertyName = "tag")]
        public string Tag { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "minPollingIntervalInSeconds")]
        public int MinPollingIntervalInSeconds { get; set; }

        [JsonProperty(PropertyName = "measureType")]
        public string MeasureType { get; set; }
    }
}
