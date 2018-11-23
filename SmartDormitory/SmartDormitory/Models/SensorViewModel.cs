using SmartDormitory.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDormitory.Web.Models
{
    public class SensorViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public ICollection<Type> Type { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool Alarm { get; set; }
        public bool IsPublic { get; set; }

        public SensorViewModel()
        {
        }

        public SensorViewModel(Sensor sensor)
        {
            this.Name = Name;
            this.Description = Description;
            this.URL = URL;
        }
    }
}
