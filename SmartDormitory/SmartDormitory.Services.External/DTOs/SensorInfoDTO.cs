using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDormitory.Services.External.DTOs
{
    public class SensorInfoDTO
    {
        [JsonProperty(PropertyName = "timeStamp")]
        public string TimeStamp { get; set; }

        [JsonProperty(PropertyName = "value")]
        public decimal Value { get; set; }

        [JsonProperty(PropertyName = "valueType")]
        public string ValueType { get; set; }
    }
}
