using Microsoft.EntityFrameworkCore;
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
        private readonly IRepository<SensorType> sensorTypeRepo;

        public SensorServices(IRepository<Sensor> sensorRepo, IRepository<SensorType> sensorTypeRepo)
        {
            this.sensorRepo = sensorRepo;
            this.sensorTypeRepo = sensorTypeRepo;
        }

        public async Task<Sensor> CreateSensorAsync(string name, string description, string url, string type,
            string latitude, string longitude, bool alarm, bool isPublic, string UserId)
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
                IsPublic = isPublic,
                UserId = UserId
            };
            await sensorRepo.AddAsync(sensorToAdd);
            await sensorRepo.SaveAsync();
            return sensorToAdd;
        }

        public Sensor GetSensorById(int id)
        {
            return sensorRepo.All().SingleOrDefault(s => s.ID == id);
        }

        public IEnumerable<Sensor> GetAllSensors()
        {
            return sensorRepo.All();
        }

        public async Task<IEnumerable<SensorType>> GetSensorTypesAsync()
        {
            return await sensorTypeRepo.All().ToListAsync();
        }

        public IEnumerable<Sensor> GetAllPublicSensors()
        {
            return sensorRepo.All()
                .Where(s => s.IsPublic);
        }

        public IEnumerable<Sensor> GetSensorsByUsername(string username)
        {
            return  sensorRepo.All()
                .Where(s => s.User.UserName == username);
        }
    }
}
