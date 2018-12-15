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
using System.Text;
using System.Threading.Tasks;

namespace SmartDormitory.Tests.WebTests.ControllerTests.SensorControllerTests
{
    [TestClass]
    public class DetailActionShould
    {
        [TestClass]
        public class DetailsActionShould
        {
            [TestMethod]
            public void CallCorrectServiceMethod()
            {
                //Arrange
                const int sensorID = 3;
                var sensorServiceMock = new Mock<ISensorService>();
                sensorServiceMock
                .Setup(ss => ss.GetSensorById(sensorID))
                .Returns(new SensorsFromUser { ApiId = "ApiId" });

                var sensorCacheMock = new Mock<IMemoryCache>();
                var userManagerMock = new Mock<IUserManager<User>>();
                var sut = new SensorController(sensorServiceMock.Object, sensorCacheMock.Object, userManagerMock.Object);
                //Act
                var result = sut.Details(sensorID) as ViewResult;
                //Assert
                sensorServiceMock.Verify(s => s.GetSensorById(sensorID), Times.Once);
            }

            [TestMethod]
            public void ReturnCorrectViewModel()
            {
                //Arrange
                const int sensorId = 3;
                var sensorServiceMock = new Mock<ISensorService>();
                sensorServiceMock
                .Setup(ss => ss.GetSensorById(sensorId))
                .Returns(new SensorsFromUser {ApiId = "ApiId"});

                var sensorCacheMock = new Mock<IMemoryCache>();
                var userManagerMock = new Mock<IUserManager<User>>();
                var sut = new SensorController(sensorServiceMock.Object, sensorCacheMock.Object, userManagerMock.Object);
                //Act
                var result = sut.Details(sensorId) as ViewResult;
                //Assert
                Assert.IsInstanceOfType(result.Model, typeof(SensorDetailsViewModel));

            }

            [TestMethod]
            public void ReturnsCorrectViewResult()
            {
                //Arrange
                const int sensorId = 3;
                var sensorServiceMock = new Mock<ISensorService>();
                sensorServiceMock
                .Setup(ss => ss.GetSensorById(sensorId))
                .Returns(new SensorsFromUser { ApiId = "ApiId" });

                var movieCachMock = new Mock<IMemoryCache>();
                var userManagerMock = new Mock<IUserManager<User>>();
                var sut = new SensorController(sensorServiceMock.Object, movieCachMock.Object, userManagerMock.Object);
                //Act
                var result = sut.Details(sensorId);
                //Assert
                Assert.IsInstanceOfType(result, typeof(ViewResult));
            }
        }
    }
}
