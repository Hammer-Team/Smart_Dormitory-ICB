using Microsoft.EntityFrameworkCore;
using SmartDormitory.Data.Models;
using SmartDormitory.Data.Repository;
using SmartDormitory.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDormitory.Services
{
    public class SensorServices : ISensorService
    {
        private readonly IRepository<SensorsFromUser> sensorRepo;
        private readonly IRepository<SensorType> sensorTypeRepo;
        private readonly IRepository<Sensor> apiSensorRepo;

        public SensorServices(IRepository<SensorsFromUser> sensorRepo, IRepository<SensorType> sensorTypeRepo, IRepository<Sensor> apiSensorRepo)
        {
            this.sensorRepo = sensorRepo;
            this.sensorTypeRepo = sensorTypeRepo;
            this.apiSensorRepo = apiSensorRepo;
        }

        public async Task<SensorsFromUser> CreateSensorAsync(string name, string description, string type,
            string latitude, string longitude, bool alarm, bool isPublic, string UserId, string ApiId, DateTime TimeStamp)
        {
            var sensorToAdd = new SensorsFromUser()
            {
                Name = name,
                Description = description,
                MeasurmentType = type,
                Latitude = latitude,
                Longitude = longitude,
                Alarm = alarm,
                IsPublic = isPublic,
                UserId = UserId,
                ApiId = ApiId,
                TimeStamp = DateTime.Now.ToString("O")//"yyyy-MM-ddTHH:mm:ss.FFFFFFF"
            };
            var test = sensorRepo.All().Where(s => ApiId == s.ApiId).ToList();
            var test2 = sensorRepo.All().ToList();
            sensorToAdd.PoolInterval = apiSensorRepo.All().Where(s => ApiId == s.ApiId).Select(s => s.PoolInterval).FirstOrDefault();
            sensorToAdd.MeasurmentType = apiSensorRepo.All().Where(s => ApiId == s.ApiId).Select(s => s.MeasurmentType).FirstOrDefault();
            sensorToAdd.ValueRangeMin = apiSensorRepo.All().Where(s => ApiId == s.ApiId).Select(s => s.ValueRangeMin).FirstOrDefault();
            sensorToAdd.ValueRangeMax = apiSensorRepo.All().Where(s => ApiId == s.ApiId).Select(s => s.ValueRangeMax).FirstOrDefault();
            
            await sensorRepo.AddAsync(sensorToAdd);
            await sensorRepo.SaveAsync();
            return sensorToAdd;
        }

        public IEnumerable<string> GetApiSensorIds()
        {
            return apiSensorRepo.All().Select(s => s.ApiId);
        }

        public SensorsFromUser GetSensorById(int id)
        {
            return sensorRepo.All().SingleOrDefault(s => s.ID == id);
        }

        public IEnumerable<SensorsFromUser> GetAllSensors()
        {
            return sensorRepo.All();
        }

        public async Task<IEnumerable<SensorType>> GetSensorTypesAsync()
        {
            return await sensorTypeRepo.All().ToListAsync();
        }

        public IEnumerable<SensorsFromUser> GetAllPublicSensors()
        {
            return sensorRepo.All()
                .Where(s => s.IsPublic);
        }

        public IEnumerable<SensorsFromUser> GetSensorsByUsername(string username)
        {
            return sensorRepo.All()
                .Where(s => s.User.UserName == username);
        }

        public void UpdateSensor(SensorsFromUser editedSensor)
        {
            sensorRepo.Update(editedSensor);
            sensorRepo.Save();
        }

        public void Delete(SensorsFromUser entity)
        {
            sensorRepo.Delete(entity);
            sensorRepo.Save();
        }
    }
}
