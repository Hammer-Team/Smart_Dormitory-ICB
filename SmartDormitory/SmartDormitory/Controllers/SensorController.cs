using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using SmartDormitory.Data.Models;
using SmartDormitory.Services;
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
        [Authorize]
        public async Task<IActionResult> Create()
        {
            var newSensor = new SensorViewModel();
            var cachedSensorTypes = await _memoryCache.GetOrCreateAsync("Types", async entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromHours(2);
                var sensorTypes = await sensorService.GetSensorTypesAsync();
                var s = sensorTypes.Select(t => new SelectListItem(t.Type, t.Type));
                newSensor.TypeList = s;
                return s;
            });
            return View(newSensor);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(SensorViewModel sensorViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var newMovie = await sensorService.CreateSensorAsync(
                sensorViewModel.Name, 
                sensorViewModel.Description,
                sensorViewModel.Type,
                sensorViewModel.Latitude, 
                sensorViewModel.Longitude, 
                sensorViewModel.Alarm, 
                sensorViewModel.IsPublic, 
                User.FindFirst(ClaimTypes.NameIdentifier).Value,
                sensorViewModel.ApiId,
                sensorViewModel.TimeStamp
                );

            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Details(int id)
        {
            var sensor = sensorService.GetSensorById(id);

            return View(sensor);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Test(int id)
        {
            var sensor = sensorService.GetSensorById(id);

            return Json(sensor);
        }
    }
}
