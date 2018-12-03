using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;

namespace SmartDormitory.Data.JsonTools
{
    public class JsonManager
    {
        private const string folderPathOfJsons = @"..\SmartDormitory.Data\JsonData\";
        private readonly ModelBuilder modelBuilder;

        public JsonManager(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void RegisterJson<T>(string jsonName) where T : class
        {
            string textJson = File.ReadAllText(Path.Combine(folderPathOfJsons, jsonName));

            var entityJson = JsonConvert.DeserializeObject<T[]>(textJson);

            this.modelBuilder.Entity<T>().HasData(entityJson);
        }
    }
}
