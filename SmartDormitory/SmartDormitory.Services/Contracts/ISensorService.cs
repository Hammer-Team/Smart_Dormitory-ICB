using SmartDormitory.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartDormitory.Services.Contracts
{
    public interface ISensorService
    {
        Task<SensorsFromUser> CreateSensorAsync(string name, string description, string type,
            string latitude, string longitude, bool alarm, bool isPublic, string UserId, string ApiId, DateTime TimeStamp);

        IEnumerable<string> GetApiSensorIds();

        SensorsFromUser GetSensorById(int id);

        IEnumerable<SensorsFromUser> GetAllPublicSensors();

        IEnumerable<SensorsFromUser> GetSensorsByUsername(string username);

        Task<IEnumerable<SensorType>> GetSensorTypesAsync();

        void UpdateSensor(SensorsFromUser editedSensor);

        void Delete(SensorsFromUser sensor);
    }
}
