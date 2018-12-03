using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartDormitory.Data.Models;
using SmartDormitory.Models;
using SmartDormitory.Services.Contracts;
using SmartDormitory.Services.External.Contracts;

namespace SmartDormitory.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISensorService sensorService;
        private readonly IRestClientService test;

        public HomeController(ISensorService sensorService, IRestClientService test)
        {
            this.sensorService = sensorService;
            this.test = test;
        }

        public async Task<IActionResult> Index()
        {
            var testData = await test.GetAllSensorsAsync("all", "8e4c46fe-5e1d-4382-b7fc-19541f7bf3b0");
            var testData2 = await test.GetSensorById("8e4c46fe-5e1d-4382-b7fc-19541f7bf3b0", "f1796a28-642e-401f-8129-fd7465417061");
            
            IEnumerable<Sensor> sensors;
            bool isUserLogged = User.Identity.IsAuthenticated;

            if (!isUserLogged)
            {
                sensors = sensorService.GetAllPublicSensors();

                return View(sensors);
            }

            string username = User.Identity.Name;
            sensors = sensorService.GetSensorsByUsername(username);

            return View(sensors);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
