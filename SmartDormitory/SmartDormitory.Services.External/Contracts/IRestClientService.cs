using SmartDormitory.Services.External.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartDormitory.Services.External.Contracts
{
    public interface IRestClientService
    {
        Task<IEnumerable<SensorDTO>> GetAllSensorsAsync(string apiURL, string authToken);

        Task<SensorInfoDTO> GetSensorById(string authToken, string id);
    }
}
