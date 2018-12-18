using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartDormitory.Data.Context;
using SmartDormitory.Data.Models;
using SmartDormitory.Data.Repository;
using SmartDormitory.Services.External.Contracts;
using SmartDormitory.Services.External.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmartDormitory.Services.External
{
    public class RestClientService : IRestClientService
    {
        private readonly HttpClient _client;
        private readonly DormitoryContext context;
        private readonly IRepository<Sensor> sensorRepo;

        public RestClientService(DormitoryContext context, HttpClient client, IRepository<Sensor> sensorRepo)
        {
            this.context = context;
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _client.BaseAddress = new Uri("http://telerikacademy.icb.bg/api/sensor");
            this._client.DefaultRequestHeaders.Add("auth-token", "8e4c46fe-5e1d-4382-b7fc-19541f7bf3b0");
            this.sensorRepo = sensorRepo;
        }

        public IEnumerable<SensorDTO> GetAllSensorsAsync(string apiRoute, string authToken)
        {
            string json = null;
            try
            {
                var response = this._client.GetAsync(_client.BaseAddress + "/" + apiRoute).GetAwaiter().GetResult();

                json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                json = "[{\"SensorId\":\"f1796a28-642e-401f-8129-fd7465417061\",\"Tag\":\"TemperatureSensor1\",\"Description\":\"This sensor will return values between 15 and 28\",\"MinPollingIntervalInSeconds\":40,\"MeasureType\":\"°C\"},{\"SensorId\":\"81a2e1b1-ea5d-4356-8266-b6b42471653e\",\"Tag\":\"TemperatureSensor2\",\"Description\":\"This sensor will return values between 6 and 18\",\"MinPollingIntervalInSeconds\":30,\"MeasureType\":\"°C\"},{\"SensorId\":\"92f7dc9a-f2fe-4b60-82f5-400e42f099b4\",\"Tag\":\"TemperatureSensor3\",\"Description\":\"This sensor will return values between 19 and 23\",\"MinPollingIntervalInSeconds\":70,\"MeasureType\":\"°C\"},{\"SensorId\":\"216fc1e7-1496-4532-b9ee-29565b865ad6\",\"Tag\":\"HumiditySensor1\",\"Description\":\"This sensor will return values between 0 and 60\",\"MinPollingIntervalInSeconds\":40,\"MeasureType\":\"%\"},{\"SensorId\":\"61ff0614-64fd-4842-9a05-0b1541d2cc61\",\"Tag\":\"HumiditySensor2\",\"Description\":\"This sensor will return values between 10 and 90\",\"MinPollingIntervalInSeconds\":50,\"MeasureType\":\"%\"},{\"SensorId\":\"08503c1c-963f-4106-9088-82fa67d34f9d\",\"Tag\":\"ElectricPowerConsumtionSensor1\",\"Description\":\"This sensor will return values between 1000 and 5000\",\"MinPollingIntervalInSeconds\":70,\"MeasureType\":\"W\"},{\"SensorId\":\"1f0ef0ff-396b-40cb-ac3d-749196dee187\",\"Tag\":\"ElectricPowerConsumtionSensor2\",\"Description\":\"This sensor will return values between 500 and 3500\",\"MinPollingIntervalInSeconds\":105,\"MeasureType\":\"W\"},{\"SensorId\":\"4008e030-fd3a-4f8c-a8ca-4f7609ecdb1e\",\"Tag\":\"OccupancySensor1\",\"Description\":\"This sensor will return true or false value\",\"MinPollingIntervalInSeconds\":50,\"MeasureType\":\"(true/false)\"},{\"SensorId\":\"7a3b1db5-959d-46ce-82b6-517773327427\",\"Tag\":\"OccupancySensor2\",\"Description\":\"This sensor will return true or false value\",\"MinPollingIntervalInSeconds\":80,\"MeasureType\":\"(true/false)\"},{\"SensorId\":\"a3b8a078-0409-4365-ace6-6f8b5b93d592\",\"Tag\":\"DoorSensor1\",\"Description\":\"This sensor will return true or false value\",\"MinPollingIntervalInSeconds\":90,\"MeasureType\":\"(true/false)\"},{\"SensorId\":\"ec3c4770-5d57-4d81-9c83-a02140b883a1\",\"Tag\":\"DoorSensor2\",\"Description\":\"This sensor will return true or false value\",\"MinPollingIntervalInSeconds\":50,\"MeasureType\":\"(true/false)\"},{\"SensorId\":\"d5d37a46-8ab5-41ec-b7d5-d28c2fd68d3d\",\"Tag\":\"NoiseSensor1\",\"Description\":\"This sensor will return values between 20 and 70\",\"MinPollingIntervalInSeconds\":40,\"MeasureType\":\"dB\"},{\"SensorId\":\"65d98ff7-b524-49de-8d13-f85753d98858\",\"Tag\":\"NoiseSensor2\",\"Description\":\"This sensor will return values between 40 and 90\",\"MinPollingIntervalInSeconds\":85,\"MeasureType\":\"dB\"}]";
            }
            return JsonConvert.DeserializeObject<IEnumerable<SensorDTO>>(json);
            
        }

        public SensorInfoDTO GetSensorById(string authToken,string id)
        {
            
            try { 

            var response = this._client.GetAsync(_client.BaseAddress + "/" + id).GetAwaiter().GetResult();

            var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            return JsonConvert.DeserializeObject<SensorInfoDTO>(json);
            }
            catch (Exception ex)
            {
                //var sensorInfo = context.Sensors.Where(s => s.ApiId.Equals(id)).FirstOrDefault();
                string json = "{" +
                    "\"TimeStamp\":\"" +
                    DateTime.Now.ToString("O") +
                    "\",\"Value\":\"" +
                     -1 +
                    "\",\"ValueType\":\"°C\"}";
                return JsonConvert.DeserializeObject<SensorInfoDTO>(json);
            }
        }

        public IDictionary<string, Sensor> InitialSensorLoad()
        {
            var result = new Dictionary<string, Sensor>();

            var sensors = this.context.Sensors;

            foreach (var sensor in sensors)
            {
                if (!result.ContainsKey(sensor.ApiId.ToString()))
                {
                    result.Add(sensor.ApiId.ToString(), sensor);
                }
            }
            return result;
        }

        public IDictionary<string, SensorsFromUser> InitialSensorsFromUsersLoad()
        {
            var result = new Dictionary<string, SensorsFromUser>();

            var sensors = this.context.GetSensorsFromUsers;

            foreach (var sensor in sensors)
            {
                if (!result.ContainsKey(sensor.ID.ToString()))
                {
                    result.Add(sensor.ID.ToString(), sensor);
                }
            }
            return result;
        }

        public IDictionary<string, Sensor> CheckForNewSensor(IDictionary<string, Sensor> listOfSensors)
        {
            var response = GetAllSensorsAsync("all", "8e4c46fe-5e1d-4382-b7fc-19541f7bf3b0");

            foreach (var sensor in response)
            {
                string sensorId = sensor.SensorId;

                if (!listOfSensors.ContainsKey(sensorId))
                {
                    var measureType = sensor.MeasureType;
                    string tag = sensor.Tag;
                    string typeTag = tag.Substring(0, tag.IndexOf("Sensor"));
                    //var SensorTypeID = context.SensorTypes.Select(t=>t.Id
                    //.Where(t.Type.ToString().Equals(sensor.Tag.ToString())))
                    //.FirstOrDefault();
                    //var measure = CheckForNewMeasureType(measureType);
                    var type = CheckForNewSensorType(typeTag);
                    listOfSensors.Add(sensorId, AddNewSensoreToDatabase(sensor));
                }
            }
            return listOfSensors;
        }

        private Sensor AddNewSensoreToDatabase(SensorDTO sensorToAdd)
        {
            string sensorId = sensorToAdd.SensorId;
            string description = sensorToAdd.Description;
            var extractedValues = GetMinMaxValues(description);
            string tag = sensorToAdd.Tag;
            string measureType = sensorToAdd.MeasureType;

            int minPollInterval = int.TryParse
                (sensorToAdd.MinPollingIntervalInSeconds.ToString(), out int number)
                ? number : 10;

            var newSensor = new Sensor()
            {
                ApiId = sensorId,
                Description = description,
                PoolInterval = minPollInterval,
                MeasurmentType = measureType,
                ValueRangeMax = Math.Max(extractedValues[0], extractedValues[1]),
                ValueRangeMin = Math.Min(extractedValues[0], extractedValues[1]),
                TimeStamp = DateTime.Now.ToString()
            };

            this.context.Add(newSensor);
            this.context.SaveChanges();

            return newSensor;
        }

        private SensorType CheckForNewSensorType(string typeTag)
        {
            var result = this.context.SensorTypes.Where(s => s.Type == typeTag);
            SensorType newSensorType = null;

            if (result.Count() == 0)
            {
                newSensorType = new SensorType()
                {
                    Type = typeTag
                };
                this.context.SensorTypes.Add(newSensorType);
                this.context.SaveChanges();
            }
            return newSensorType;
        }

        public IDictionary<string, Sensor> UpdateSensors(IDictionary<string, Sensor> listOfSensors)
        {
            foreach (var sensor in listOfSensors.Values)
            {
                var senzorTime = DateTime.Parse(sensor.TimeStamp).AddSeconds(sensor.PoolInterval);
                if (DateTime.Parse(sensor.TimeStamp).AddSeconds(sensor.PoolInterval) < DateTime.Now)
                {
                    var response = GetSensorById("8e4c46fe-5e1d-4382-b7fc-19541f7bf3b0", sensor.ApiId);
                    if (response.Value.ToString().Equals("-1"))
                    {
                        continue;
                    }
                    else
                    {
                        sensor.TimeStamp = response.TimeStamp;
                        sensor.Value = response.Value.ToString();
                        context.Update(sensor);
                    }
                }
            }
            context.SaveChanges();

            return listOfSensors;
        }

        public IDictionary<string, SensorsFromUser> UpdateSensorsFromUsers(IDictionary<string, SensorsFromUser> listOfSensors)
        {
            listOfSensors = InitialSensorsFromUsersLoad();

            foreach (var sensor in listOfSensors.Values)
            {
                var date = DateTime.Parse(sensor.TimeStamp.ToString()).AddSeconds(sensor.PoolInterval);
                string senzorTime = sensor.TimeStamp;
                if (DateTime.Parse(sensor.TimeStamp).AddSeconds(sensor.PoolInterval) < DateTime.Now)
                {
                    //var response = GetSensorById("8e4c46fe-5e1d-4382-b7fc-19541f7bf3b0", sensor.ApiId);
                    var response = context.Sensors.Where(s => s.ApiId.Equals(sensor.ApiId)).FirstOrDefault();
                    sensor.TimeStamp = response.TimeStamp;
                    sensor.Value = response.Value.ToString();
                    context.Update(sensor);
                }
            }
            context.SaveChanges();

            return listOfSensors;
        }

        private double[] GetMinMaxValues(string input)
        {
            var numbers = Regex.Matches(input, @"(\+| -)?(\d+)(\,|\.)?(\d*)?");
            var result = new double[2];
            result[0] = 0;
            result[1] = 1;
            
            if (numbers.Count > 0)
            {
                double.TryParse(numbers[0].ToString(), out result[0]);
                double.TryParse(numbers[1].ToString(), out result[1]);
            }
            return result;
        }
    }
}
