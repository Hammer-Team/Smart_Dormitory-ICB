using Microsoft.AspNetCore.Mvc;
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
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SmartDormitory.Tests.WebTests.ControllerTests.SensorControllerTests
{
    [TestClass]
    public class CreateActionShould
    {

        /*[TestMethod]
        public async Task CallCorrectServiceMethodWithCorrectParams()
        {
            //Arrange
            var date = DateTime.Now;
            var sensorServiceMock = new Mock<ISensorService>();
            sensorServiceMock
                .Setup(ssm => ssm.GetSensorTypesAsync())
                .Returns(new List<SensorType>());
            var cache = new MemoryCache(new MemoryCacheOptions());
            var userManagerMock = new Mock<IUserManager<User>>();

            var sut = new SensorController(sensorServiceMock.Object, cache, userManagerMock.Object);
            //Act
            await sut.Create();
            //Assert
            sensorServiceMock.Verify(msm => msm.GetSensorTypesAsync(), Times.Once);
        }*/

        [TestMethod]
        public async Task ReturnCorrectViewModel()
        {
            //Arrange
            var sensorServiceMock = new Mock<ISensorService>();
            var cache = new MemoryCache(new MemoryCacheOptions());
            var userManagerMock = new Mock<IUserManager<User>>();

            var sut = new SensorController(sensorServiceMock.Object, cache, userManagerMock.Object);
            //Act
            var result = await sut.Create() as ViewResult;
            //Assert
            Assert.IsInstanceOfType(result.Model, typeof(SensorCreateViewModel));
        }

        [TestMethod]
        public async Task ReturnsCorrectViewResult()
        {
            //Arrange
            var sensorServiceMock = new Mock<ISensorService>();
            var cache = new MemoryCache(new MemoryCacheOptions());
            var userManagerMock = new Mock<IUserManager<User>>();
            var sut = new SensorController(sensorServiceMock.Object, cache, userManagerMock.Object);
            //Act
            var result = await sut.Create() as ViewResult;
            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
