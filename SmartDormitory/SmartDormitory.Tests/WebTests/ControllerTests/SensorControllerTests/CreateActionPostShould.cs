using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmartDormitory.Data.Models;
using SmartDormitory.Services.Contracts;
using SmartDormitory.Web.Controllers;
using SmartDormitory.Web.Models;
using SmartDormitory.Web.Providers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartDormitory.Tests.WebTests.ControllerTests.SensorControllerTests
{
    [TestClass]
    public class CreateActionPostShould
    {
        const string sensorName = "MySensor";
        const string description = "description";
        const string type = "Door";
        const string latitude = "latitude";
        const string logitude = "logitude";
        const string userId = "45a3335a-44de-44f7-b77c-bfa7d3c10a7c";
        const string ApiId = "f1796a28-642e-401f-8129-fd7465417061";
        DateTime date = DateTime.Now;

        [TestMethod]
        public async Task CallCorrectServiceMethodWithCorrectParams()
        {
            //Arrange
            var newSensor = new SensorsFromUser();

            var model = new SensorCreateViewModel() { Name = sensorName, Description = description, Type = type, Latitude =latitude,
            Longitude = logitude, Alarm = true, IsPublic = true, ApiId = ApiId, TimeStamp = date};
            var sensorServiceMock = new Mock<ISensorService>();
            sensorServiceMock
                .Setup(ms => ms.CreateSensorAsync(sensorName, description, type, latitude, logitude,
                true, true, userId, ApiId, date))
                .ReturnsAsync(newSensor);

            var cache = new MemoryCache(new MemoryCacheOptions());
            var userManagerMock = new Mock<IUserManager<User>>();

            var sut = new SensorController(sensorServiceMock.Object, cache, userManagerMock.Object);
            //Act
            var result = await sut.Create(model) as ViewResult;
            //Assert
            sensorServiceMock.Verify(s => s.CreateSensorAsync(sensorName, description, type, latitude, logitude, 
                true, true, userId, ApiId, date));
        }

        [TestMethod]
        public async Task ReturnsCorrectViewResult()
        {
            //Arrange
            var model = new SensorViewModel();
            var sensorServiceMock = new Mock<ISensorService>();
            sensorServiceMock
                .Setup(ms => ms.CreateSensorAsync(
                    sensorName, description, type, 
                    latitude, logitude,true, 
                    true, userId, ApiId, date))
                .ReturnsAsync(new SensorsFromUser());

            var cache = new MemoryCache(new MemoryCacheOptions());
            var userManagerMock = new Mock<IUserManager<User>>();

            var sut = new SensorController(sensorServiceMock.Object, cache, userManagerMock.Object);
            //Act
            var result = await sut.Create(model);
            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }
    }
}
