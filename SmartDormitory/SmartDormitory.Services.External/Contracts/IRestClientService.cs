using SmartDormitory.Data.Models;
using SmartDormitory.Services.External.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartDormitory.Services.External.Contracts
{
    public interface IRestClientService
    {
        IEnumerable<SensorDTO> GetAllSensorsAsync(string apiURL, string authToken);

        SensorInfoDTO GetSensorById(string authToken, string id);

        IDictionary<string, SensorFromUser> InitialSensorLoad();

        IDictionary<string, SensorsFromUser> InitialSensorsFromUsersLoad();

        IDictionary<string, SensorFromUser> CheckForNewSensor(IDictionary<string, SensorFromUser> listOfSensors);

        IDictionary<string, SensorFromUser> UpdateSensors(IDictionary<string, SensorFromUser> listOfSensors);

        IDictionary<string, SensorsFromUser> UpdateSensorsFromUsers(IDictionary<string, SensorsFromUser> listOfSensors);
    }
}
