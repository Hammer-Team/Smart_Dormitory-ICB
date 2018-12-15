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
using X.PagedList;

namespace SmartDormitory.Tests.WebTests.AdminAriaTests
{
    [TestClass]
    public class UserGridShould
    {
        [TestMethod]
        public void CallCorrectServiceMethod()
        {
            //Arrange
            var userManagerMock = new Mock<IUserManager<User>>();
            var sut = new UsersController(userManagerMock.Object);
            //Act
            var result = sut.UserGrid(21) as PartialViewResult;
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
            var result = sut.UserGrid(21) as PartialViewResult;
            //Assert
            Assert.IsInstanceOfType(result.Model, typeof(IPagedList<UserViewModel>));
        }

        [TestMethod]
        public void ReturnsCorrectViewResult()
        {
            //Arrange
            var userManagerMock = new Mock<IUserManager<User>>();
            var sut = new UsersController(userManagerMock.Object);
            //Act
            var result = sut.UserGrid(21);
            //Assert
            Assert.IsInstanceOfType(result, typeof(PartialViewResult));
        }
    }
}
