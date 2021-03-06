﻿namespace SmartDormitory.Data.Models
{
    public class SensorsFromUser
    {
        public int ID { get; set; }

        public string ApiId { get; set; }

        public string Name { get; set; }

        public string SensorTypeId { get; set; }

        public SensorType SensorType { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }

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

        public string TimeStamp { get; set; }

        public User User { get; set; }
    }
}
