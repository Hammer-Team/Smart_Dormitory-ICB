using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmartDormitory.Data.Models;
using SmartDormitory.Web.Areas.Admin.Controllers;
using SmartDormitory.Web.Areas.Admin.Models;
using SmartDormitory.Web.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDormitory.Tests.WebTests.AdminAriaTests
{
    [TestClass]
    public class IndexActionShould
    {
        [TestMethod]
        public void CallCorrectServiceMethod()
        {
            //Arrange
            var userManagerMock = new Mock<IUserManager<User>>();
            var sut = new UsersController(userManagerMock.Object);
            //Act
            var result = sut.Index() as ViewResult;
            //Assert
            userManagerMock.Verify(s => s.Users, Times.Once);
        }

        [TestMethod]
        public void ReturnCorrectViewModel()
        {
            //Arrange
            var userManagerMock = new Mock<IUserManager<User>>();
            var sut = new UsersController(userManagerMock.Object);
            //Acts
            var result = sut.Index() as ViewResult;
            //Assert
            Assert.IsInstanceOfType(result.Model, typeof(IndexViewModel));
        }

        [TestMethod]
        public void ReturnsCorrectViewResult()
        {
            //Arrange
            var userManagerMock = new Mock<IUserManager<User>>();
            var sut = new UsersController(userManagerMock.Object);
            //Act
            var result = sut.Index();
            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
