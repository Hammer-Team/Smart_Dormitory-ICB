using Microsoft.AspNetCore.Mvc.Rendering;
using SmartDormitory.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SmartDormitory.Web.Models
{
    public class SensorViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public string Type { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool Alarm { get; set; }
        public bool IsPublic { get; set; }
        public string UserId { get; set; }
        public double ValueRangeMin { get; set; }
        public double ValueRangeMax { get; set; }
        public DateTime TimeStamp { get; set; } 
        public string ApiId { get; set; }
        public int PollingIntervalInSeconds { get; set; }
        public IEnumerable<SelectListItem> TypeList { get; set; }
        public ICollection<string> Types { get; set; }

        public SensorViewModel()
        {

        }

        public SensorViewModel(Sensor sensor)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
            this.PollingIntervalInSeconds = PollingIntervalInSeconds;
            this.URL = URL;
            this.Type = Type;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
            this.Alarm = Alarm;
            this.IsPublic = IsPublic;
            this.ApiId = ApiId;
            this.ValueRangeMin = ValueRangeMin;
            this.ValueRangeMax = ValueRangeMax;
            this.TimeStamp = DateTime.Now;
            this.UserId = UserId;
        }

        public SensorViewModel(SensorsFromUser sensor)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
            this.PollingIntervalInSeconds = PollingIntervalInSeconds;
            this.URL = URL;
            this.Type = Type;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
            this.Alarm = Alarm;
            this.IsPublic = IsPublic;
            this.ApiId = ApiId;
            this.ValueRangeMin = ValueRangeMin;
            this.ValueRangeMax = ValueRangeMax;
            this.TimeStamp = DateTime.Now;
            this.UserId = UserId;
        }
    }
}
