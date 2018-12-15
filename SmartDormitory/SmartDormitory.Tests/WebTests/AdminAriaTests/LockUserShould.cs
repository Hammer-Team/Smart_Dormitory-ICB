using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmartDormitory.Data.Models;
using SmartDormitory.Web.Areas.Admin.Controllers;
using SmartDormitory.Web.Areas.Admin.Models;
using SmartDormitory.Web.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDormitory.Tests.WebTests.AdminAriaTests
{
    [TestClass]
    public class LockUserShould
    {
        [TestMethod]
        public async Task CallCorrectServiceMethod()
        {
        //Arrange
        const string uID = "213123";
        var userManagerMock = new Mock<IUserManager<User>>();
        userManagerMock
            .Setup(umm => umm.SetLockoutEnabledAsync(It.IsAny<User>(), true))
            .ReturnsAsync(IdentityResult.Success);
        userManagerMock
            .Setup(umm => umm.SetLockoutEndDateAsync(It.IsAny<User>(), It.IsAny<DateTimeOffset>()))
            .ReturnsAsync(IdentityResult.Success);
        userManagerMock
            .SetupGet(umm => umm.Users)
            .Returns(new List<User> { new User { Id = uID } }.AsQueryable());

        var sut = new UsersController(userManagerMock.Object);
        //Act
        var result = await sut.LockUser(new UserModalModelView { ID = uID }) as RedirectToActionResult;
        //Assert
        userManagerMock.Verify(s => s.Users, Times.Once);
        userManagerMock.Verify(s => s.SetLockoutEnabledAsync(It.IsAny<User>(), true), Times.Once);
        userManagerMock.Verify(s => s.SetLockoutEndDateAsync(It.IsAny<User>(), It.IsAny<DateTimeOffset>()), Times.Once);
    }

    [TestMethod]
    public async Task ReturnsCorrectViewResult()
    {
        //Arrange
        const string uID = "213123";
        var userManagerMock = new Mock<IUserManager<User>>();
        userManagerMock
            .Setup(umm => umm.SetLockoutEnabledAsync(It.IsAny<User>(), true))
            .ReturnsAsync(IdentityResult.Success);
        userManagerMock
            .Setup(umm => umm.SetLockoutEndDateAsync(It.IsAny<User>(), It.IsAny<DateTimeOffset>()))
            .ReturnsAsync(IdentityResult.Success);
        userManagerMock
            .SetupGet(umm => umm.Users)
            .Returns(new List<User> { new User { Id = uID } }.AsQueryable());

        var sut = new UsersController(userManagerMock.Object);
        //Act
        var result = await sut.LockUser(new UserModalModelView { ID = uID }) as RedirectToActionResult;
        //Assert
        Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
    }
    [TestMethod]
    public async Task RedirectWithError_WhenUserIsNull()
    {
        //Arrange
        const string uID = "213123";
        var userManagerMock = new Mock<IUserManager<User>>();
        var sut = new UsersController(userManagerMock.Object);
        //Act
        var result = await sut.LockUser(new UserModalModelView { ID = uID }) as RedirectToActionResult;
        //Assert
        Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        Assert.IsTrue(sut.StatusMessage.Contains("Error"));
    }
    [TestMethod]
    public async Task RedirectWithError_WhenSetLockoutFails()
    {
        //Arrange
        const string uID = "213123";
        var userManagerMock = new Mock<IUserManager<User>>();
        userManagerMock
            .Setup(umm => umm.SetLockoutEnabledAsync(It.IsAny<User>(), true))
            .ReturnsAsync(IdentityResult.Success);
        userManagerMock
            .Setup(umm => umm.SetLockoutEndDateAsync(It.IsAny<User>(), It.IsAny<DateTimeOffset>()))
            .ReturnsAsync(IdentityResult.Failed());
        userManagerMock
            .SetupGet(umm => umm.Users)
            .Returns(new List<User> { new User { Id = uID } }.AsQueryable());

        var sut = new UsersController(userManagerMock.Object);
        //Act
        var result = await sut.LockUser(new UserModalModelView { ID = uID }) as RedirectToActionResult;
        //Assert
        Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        Assert.IsTrue(sut.StatusMessage.Contains("Error"));
    }
    [TestMethod]
    public async Task RedirectWithError_WhenSetLockoutDateFails()
    {
        //Arrange
        const string uID = "213123";
        var userManagerMock = new Mock<IUserManager<User>>();
        userManagerMock
            .Setup(umm => umm.SetLockoutEnabledAsync(It.IsAny<User>(), true))
            .ReturnsAsync(IdentityResult.Failed());
        userManagerMock
            .SetupGet(umm => umm.Users)
            .Returns(new List<User> { new User { Id = uID } }.AsQueryable());
        var sut = new UsersController(userManagerMock.Object);
        //Act
        var result = await sut.LockUser(new UserModalModelView { ID = uID }) as RedirectToActionResult;
        //Assert
        Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        Assert.IsTrue(sut.StatusMessage.Contains("Error"));
    }
}
}
