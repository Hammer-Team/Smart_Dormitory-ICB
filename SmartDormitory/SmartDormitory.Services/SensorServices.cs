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

        public SensorServices(IRepository<SensorsFromUser> sensorRepo, IRepository<SensorType> sensorTypeRepo)
        {
            this.sensorRepo = sensorRepo;
            this.sensorTypeRepo = sensorTypeRepo;
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
            //sensorToAdd.PoolInterval = sensorRepo.All().ToList().Select(s => s.PoolInterval).Where(sensorToAdd.ApiId.Equals(ApiId));
            //sensorToAdd.MeasurmentType = sensorRepo.All().ToList().Select(s => s.MeasurmentType).Where(sensorToAdd.ApiId.Equals(ApiId));
            //sensorToAdd.ValueRangeMin = sensorRepo.All().ToList().Select(s => s.ValueRangeMin).Where(sensorToAdd.ApiId.Equals(ApiId));
            //sensorToAdd.ValueRangeMax = sensorRepo.All().ToList().Select(s => s.ValueRangeMax).Where(sensorToAdd.ApiId.Equals(ApiId));
            await sensorRepo.AddAsync(sensorToAdd);
            await sensorRepo.SaveAsync();
            return sensorToAdd;
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
            return  sensorRepo.All()
                .Where(s => s.User.UserName == username);
        }
    }
}
