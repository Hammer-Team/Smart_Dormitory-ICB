using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmartDormitory.Data.Models;
using SmartDormitory.Services;
using SmartDormitory.Services.Contracts;
using SmartDormitory.Web.Controllers;
using SmartDormitory.Web.Models;
using SmartDormitory.Web.Providers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartDormitory.Tests.WebTests.ControllerTests
{
    [TestClass]
    public class ModifyActionPostShould
    {
        [TestMethod]
        public async Task CallCorrectServiceMethod()
        {
            //Arrange
            var sensor = new SensorsFromUser();
            var model = new SensorCreateViewModel() { Name = "SomeSensor" };
            var sensorServiceMock = new Mock<SensorServices>();
            sensorServiceMock
                .Setup(ss => ss.UpdateSensor(sensor));

            var sensorCacheMock = new Mock<IMemoryCache>();
            var userManagerMock = new Mock<IUserManager<User>>();
            var sut = new SensorController(sensorServiceMock.Object, sensorCacheMock.Object, userManagerMock.Object);
            //Act
            var result = sut.Modify(model) as ViewResult;
            //Assert
            sensorServiceMock.Verify(s => s.UpdateSensor(sensor));
        }

        [TestMethod]
        public void ReturnCorrectViewModel()
        {
            //Arrange
            var model = new SensorCreateViewModel();
            var sensor = new SensorsFromUser();
            var sensorServiceMock = new Mock<ISensorService>();
            sensorServiceMock
                .Setup(ms => ms.UpdateSensor(sensor));
            var movieCacheMock = new Mock<IMemoryCache>();
            var userManagerMock = new Mock<IUserManager<User>>();
            var sut = new SensorController(sensorServiceMock.Object, movieCacheMock.Object, userManagerMock.Object);
            //Act
            var result = sut.Modify(model) as ViewResult;
            //Assert
            Assert.IsInstanceOfType(result.Model, typeof(SensorCreateViewModel));
        }
    }
}
