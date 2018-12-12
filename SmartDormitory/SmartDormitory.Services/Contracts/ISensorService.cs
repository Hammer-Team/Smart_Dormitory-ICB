using SmartDormitory.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartDormitory.Services.Contracts
{
    public interface ISensorService
    {
        Task<SensorsFromUser> CreateSensorAsync(string name, string description, string url,
                                       string type, string latitude, string longitude, 
                                       bool alarm, bool isPublic, string UserId,
                                        string ApiId, DateTime TimeStamp);

        SensorsFromUser GetSensorById(int id);

        IEnumerable<SensorsFromUser> GetAllPublicSensors();

        IEnumerable<SensorsFromUser> GetSensorsByUsername(string username);

        Task<IEnumerable<SensorType>> GetSensorTypesAsync();
    }
}
