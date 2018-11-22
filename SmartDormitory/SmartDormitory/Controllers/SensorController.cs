using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SmartDormitory.Data.Models;
using SmartDormitory.Services.Contracts;
using SmartDormitory.Web.Models;
using SmartDormitory.Web.Providers;

namespace SmartDormitory.Web.Controllers
{
    public class SensorController : Controller
    {
        private readonly IUserManager<User> _userManager; // To do
        private readonly IMemoryCache _memoryCache; // To Do
        private readonly ISensorService sensorService; // To Do
        private string StatusMessage { get; set; }

        public SensorController(ISensorService sensorService, IMemoryCache memoryCache, IUserManager<User> userManager)
        {
            this._userManager = userManager;
            this._memoryCache = memoryCache;
            this.sensorService = sensorService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SensorViewModel sensorViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }
            var newMovie = await sensorService.CreateSensorAsync(sensorViewModel.Name, sensorViewModel.Description, sensorViewModel.URL, sensorViewModel.Type,
                sensorViewModel.Latitude, sensorViewModel.Longitude, sensorViewModel.Alarm, sensorViewModel.IsPublic);

            return View();
        }
    }
}
