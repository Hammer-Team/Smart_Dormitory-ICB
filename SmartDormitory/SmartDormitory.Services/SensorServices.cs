using SmartDormitory.Data.Models;
using SmartDormitory.Data.Repository;
using SmartDormitory.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Sensor> GetAllSensors()
        {
            return sensorRepo.All();
        }

        public IEnumerable<Sensor> GetAllPublicSensors()
        {
            return sensorRepo.All()
                .Where(s => s.IsPublic);
        }

        public IEnumerable<Sensor> GetSensorsByUsername(string username)
        {
            return sensorRepo.All()
                .Where(s => s.User.UserName == username);
        }
    }
}
