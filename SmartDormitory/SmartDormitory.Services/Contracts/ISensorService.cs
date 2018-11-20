using SmartDormitory.Data.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartDormitory.Services.Contracts
{
    public interface ISensorService
    {
        Task<Sensor> CreateSensorAsync(string name, string description, string url,
            string type, string latitude, string longitude, bool alarm, bool isPublic);
    }
}
