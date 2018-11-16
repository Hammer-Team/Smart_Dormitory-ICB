using System;
using System.Collections.Generic;
using System.Text;

namespace Data.SmartDormitory.Models
{
    public class Sensor
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public double Value { get; set; }

        public string Description { get; set; }

        public string URLSensorData { get; set; }

        public int PoolInterval { get; set; }

        public string MeasurmentType { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public double ValueRangeMin { get; set; }

        public double ValueRangeMax { get; set; }

        public bool Alarm { get; set; }

        public bool IsPublic { get; set; }

        public bool IsDeleted { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
