using SmartDormitory.Data.Models;

namespace SmartDormitory.Web.Models
{
    public class SensorDetailsViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Value { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public bool Alarm { get; set; }

        public bool IsPublic { get; set; }

        public double ValueRangeMin { get; set; }

        public double ValueRangeMax { get; set; }

        public int PollingInterval { get; set; }

        public string MeasurmentType { get; set; }

        public SensorDetailsViewModel(SensorsFromUser sensor)
        {
            this.ID = sensor.ID;
            this.Name = sensor.Name;
            this.Description = sensor.Description;
            this.Value = sensor.Value;
            this.Latitude = sensor.Latitude;
            this.Longitude = sensor.Longitude;
            this.Alarm = sensor.Alarm;
            this.IsPublic = sensor.IsPublic;
            this.ValueRangeMin = sensor.ValueRangeMin;
            this.ValueRangeMax = sensor.ValueRangeMax;
            this.PollingInterval = sensor.PoolInterval;
            this.MeasurmentType = sensor.MeasurmentType;
        }

        public string GetAlarmStatus() =>
            this.Alarm ? "Enabled" : "Disabled";
    }
}
