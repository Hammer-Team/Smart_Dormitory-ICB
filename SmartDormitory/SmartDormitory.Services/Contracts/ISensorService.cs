using SmartDormitory.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartDormitory.Services.Contracts
{
    public interface ISensorService
    {
        Task<Sensor> CreateSensorAsync(string name, string description, string url,
                                       string type, string latitude, string longitude, 
                                       bool alarm, bool isPublic, string UserId);
        Sensor GetSensorById(int id);

        IEnumerable<Sensor> GetAllPublicSensors();

        IEnumerable<Sensor> GetSensorsByUsername(string username);

        Task<IEnumerable<SensorType>> GetSensorTypesAsync();
    }
}
