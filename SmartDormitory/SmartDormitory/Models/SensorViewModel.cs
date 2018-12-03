using Microsoft.AspNetCore.Mvc.Rendering;
using SmartDormitory.Data.Models;
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
            this.URL = URL;
            this.Type = Type;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
            this.Alarm = Alarm;
            this.IsPublic = IsPublic;
            this.UserId = UserId;
        }
    }
}
