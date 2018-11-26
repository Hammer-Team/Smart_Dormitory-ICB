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

namespace SmartDormitory.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISensorService sensorService;

        public HomeController(ISensorService sensorService)
        {
            this.sensorService = sensorService;
        }

        public IActionResult Index()
        {
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
