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

        IDictionary<string, Sensor> InitialSensorLoad();

        IDictionary<string, Sensor> CheckForNewSensor(IDictionary<string, Sensor> listOfSensors);

        IDictionary<string, Sensor> UpdateSensors(IDictionary<string, Sensor> listOfSensors);

        
    }
}
