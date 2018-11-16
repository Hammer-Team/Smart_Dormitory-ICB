using System;
using System.Collections.Generic;
using System.Text;

namespace Data.SmartDormitory.Models
{
    public class SensorDataHistory
    {
        public int ID { get; set; }

        public string SensorID { get; set; }

        public double Value { get; set; }

        public DateTimeOffset DateTimeOffset { get; set; }
    }
}
