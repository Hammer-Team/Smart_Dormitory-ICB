using SmartDormitory.Data.Data;
using SmartDormitory.Data.Repository;
using SmartDormitory.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartDormitory.Services
{
    public class SensorServices : ISensorService
    {

        private readonly IRepository<Sensor> sensorRepo;

        public SensorServices(IRepository<Sensor> sensorRepo)
        {
            this.sensorRepo = sensorRepo;
        }

        public async Task<Sensor> CreateSensorAsync(string name, string description, string url, string type, 
            string latitude, string longitude, bool alarm, bool isPublic)
        {
            var sensorToAdd = new Sensor()
            {
                Name = name,
                Description = description,
                URLSensorData = url,
                MeasurmentType = type,
                Latitude = latitude,
                Longitude = longitude,
                Alarm = alarm,
                IsPublic = isPublic
            };
            await sensorRepo.AddAsync(sensorToAdd);
            await sensorRepo.SaveAsync();
            return sensorToAdd;
        }
    }
}
