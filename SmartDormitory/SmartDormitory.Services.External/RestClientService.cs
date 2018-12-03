using Newtonsoft.Json;
using SmartDormitory.Services.External.Contracts;
using SmartDormitory.Services.External.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SmartDormitory.Services.External
{
    public class RestClientService : IRestClientService
    {
        private readonly HttpClient _client;

        public RestClientService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _client.BaseAddress = new Uri("http://telerikacademy.icb.bg/api/sensor");
            this._client.DefaultRequestHeaders.Add("auth-token", "8e4c46fe-5e1d-4382-b7fc-19541f7bf3b0");
        }

        public async Task<IEnumerable<SensorDTO>> GetAllSensorsAsync(string apiRoute, string authToken)
        {
            var response = await this._client.GetAsync(_client.BaseAddress + "/" + apiRoute);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<SensorDTO>>(json);
        }

        public async Task<SensorInfoDTO> GetSensorById(string authToken,string id)
        {
            var response = await this._client.GetAsync(_client.BaseAddress + "/" + id);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<SensorInfoDTO>(json);
        }
    }
}
