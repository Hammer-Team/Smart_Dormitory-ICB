using System;

namespace SmartDormitory.Data.Models
{
    public class SensorFromUser
    {
        public int ID { get; set; }
        
        public string ApiId { get; set; }

        public string SensorTypeId { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }

        public int PoolInterval { get; set; }

        public string MeasurmentType { get; set; }

        public double ValueRangeMin { get; set; }

        public double ValueRangeMax { get; set; }

        public string TimeStamp { get; set; }

        public SensorType SensorType { get; set; }
    }
}
