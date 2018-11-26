using SmartDormitory.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartDormitory.Services.Contracts
{
    public interface ISensorService
    {
        Task<Sensor> CreateSensorAsync(string name, string description, string url,
            string type, string latitude, string longitude, bool alarm, bool isPublic);

        IEnumerable<Sensor> GetAllPublicSensors();

        IEnumerable<Sensor> GetSensorsByUsername(string username);
    }
}
