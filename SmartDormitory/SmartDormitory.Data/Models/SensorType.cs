using System.Collections.Generic;

namespace SmartDormitory.Data.Models
{
    public class SensorType
    {
        public string Id { get; set; }

        public string Type { get; set; }

        public IEnumerable<Sensor> Sensors { get; set; }
    }
}
