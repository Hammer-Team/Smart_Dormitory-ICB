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
        public string Type { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool Alarm { get; set; }
        public bool IsPublic { get; set; }
    }
}
