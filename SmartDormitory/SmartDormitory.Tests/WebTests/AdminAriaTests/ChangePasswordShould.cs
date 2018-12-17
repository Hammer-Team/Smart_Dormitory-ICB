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
    public class ChangePasswordShould
    {
        [TestMethod]
        public async Task CallCorrectServiceMethod()
        {
            //Arrange
            const string uID = "213123";
            const string pass = "123";
            var user = new User { Id = uID };
            var userManagerMock = new Mock<IUserManager<User>>();
            var passwordValidatorMock = new Mock<IPasswordValidator<User>>();
            var passwordValidatorMock2 = new Mock<IPasswordValidator<User>>();
            passwordValidatorMock
                .Setup(pvm => pvm.ValidateAsync(It.IsAny<UserManager<User>>(), user, pass))
                .ReturnsAsync(IdentityResult.Success);
            passwordValidatorMock2
                .Setup(pvm => pvm.ValidateAsync(It.IsAny<UserManager<User>>(), user, pass))
                .ReturnsAsync(IdentityResult.Success);
            userManagerMock
                .SetupGet(umm => umm.Users)
                .Returns(new List<User> { user }.AsQueryable());
            userManagerMock
                .SetupGet(umm => umm.PasswordValidators)
                .Returns(new List<IPasswordValidator<User>> { passwordValidatorMock.Object, passwordValidatorMock2.Object });
            userManagerMock
                .Setup(umm => umm.RemovePasswordAsync(It.IsAny<User>()))
                .ReturnsAsync(IdentityResult.Success);
            userManagerMock
                .Setup(umm => umm.AddPasswordAsync(It.IsAny<User>(), pass))
                .ReturnsAsync(IdentityResult.Success);

            var sut = new UsersController(userManagerMock.Object);
            //Act
            await sut.ChangePassword(new UserModalModelView { ID = uID, ConfirmPassword = pass, NewPassword = pass });
            //Assert
            userManagerMock.Verify(umm => umm.Users, Times.Once);
            userManagerMock.VerifyGet(umm => umm.PasswordValidators, Times.Once);
            passwordValidatorMock.Verify(pvm => pvm.ValidateAsync(It.IsAny<UserManager<User>>(), user, pass), Times.Once);
            passwordValidatorMock2.Verify(pvm => pvm.ValidateAsync(It.IsAny<UserManager<User>>(), user, pass), Times.Once);
            userManagerMock.Verify(s => s.RemovePasswordAsync(user), Times.Once);
            userManagerMock.Verify(s => s.AddPasswordAsync(user, pass), Times.Once);
        }

        [TestMethod]
        public async Task ReturnsCorrectViewResult()
        {
            //Arrange
            const string uID = "213123";
            const string pass = "123";
            var user = new User { Id = uID };
            var userManagerMock = new Mock<IUserManager<User>>();
            var passwordValidatorMock = new Mock<IPasswordValidator<User>>();
            passwordValidatorMock
                .Setup(pvm => pvm.ValidateAsync(It.IsAny<UserManager<User>>(), user, pass))
                .ReturnsAsync(IdentityResult.Success);
            userManagerMock
                .SetupGet(umm => umm.Users)
                .Returns(new List<User> { user }.AsQueryable());
            userManagerMock
                .SetupGet(umm => umm.PasswordValidators)
                .Returns(new List<IPasswordValidator<User>> { passwordValidatorMock.Object });
            userManagerMock
                .Setup(umm => umm.RemovePasswordAsync(It.IsAny<User>()))
                .ReturnsAsync(IdentityResult.Success);
            userManagerMock
                .Setup(umm => umm.AddPasswordAsync(It.IsAny<User>(), pass))
                .ReturnsAsync(IdentityResult.Success);

            var sut = new UsersController(userManagerMock.Object);
            //Act
            await sut.ChangePassword(new UserModalModelView { ID = uID, ConfirmPassword = pass, NewPassword = pass });
            //Assert
            //Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            Assert.IsTrue(sut.StatusMessage.Contains("changed"));
        }
        [TestMethod]
        public async Task RedirectWithError_WhenUserIsNull()
        {
            //Arrange
            const string uID = "213123";
            const string pass = "123";
            var userManagerMock = new Mock<IUserManager<User>>();
            var sut = new UsersController(userManagerMock.Object);
            //Act
            await sut.ChangePassword(new UserModalModelView { ID = uID, NewPassword = pass, ConfirmPassword = pass });
            //Assert
            //Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            Assert.IsTrue(sut.StatusMessage.Contains("Error"));
        }
        [TestMethod]
        public async Task Redirect_WhenValidatorsFail()
        {
            //Arrange
            const string uID = "213123";
            const string pass = "123";
            var user = new User { Id = uID };
            var userManagerMock = new Mock<IUserManager<User>>();
            var passwordValidatorMock = new Mock<IPasswordValidator<User>>();
            var passwordValidatorMock2 = new Mock<IPasswordValidator<User>>();
            passwordValidatorMock
                .Setup(pvm => pvm.ValidateAsync(It.IsAny<UserManager<User>>(), user, pass))
                .ReturnsAsync(IdentityResult.Failed());
            userManagerMock
                .SetupGet(umm => umm.Users)
                .Returns(new List<User> { user }.AsQueryable());
            userManagerMock
                .SetupGet(umm => umm.PasswordValidators)
                .Returns(new List<IPasswordValidator<User>> { passwordValidatorMock.Object, passwordValidatorMock2.Object });
            userManagerMock
                .Setup(umm => umm.RemovePasswordAsync(It.IsAny<User>()))
                .ReturnsAsync(IdentityResult.Success);
            userManagerMock
                .Setup(umm => umm.AddPasswordAsync(It.IsAny<User>(), pass))
                .ReturnsAsync(IdentityResult.Success);

            var sut = new UsersController(userManagerMock.Object);
            //Act
            await sut.ChangePassword(new UserModalModelView { ID = uID, ConfirmPassword = pass, NewPassword = pass });
            //Assert
            //Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            Assert.IsTrue(sut.StatusMessage.Contains("Error"));
        }
        [TestMethod]
        public async Task Redirect_RemovePasswordFails()
        {
            //Arrange
            const string uID = "213123";
            const string pass = "123";
            var user = new User { Id = uID };
            var userManagerMock = new Mock<IUserManager<User>>();
            var passwordValidatorMock = new Mock<IPasswordValidator<User>>();
            passwordValidatorMock
                .Setup(pvm => pvm.ValidateAsync(It.IsAny<UserManager<User>>(), user, pass))
                .ReturnsAsync(IdentityResult.Success);
            userManagerMock
                .SetupGet(umm => umm.Users)
                .Returns(new List<User> { user }.AsQueryable());
            userManagerMock
                .SetupGet(umm => umm.PasswordValidators)
                .Returns(new List<IPasswordValidator<User>> { passwordValidatorMock.Object });
            userManagerMock
                .Setup(umm => umm.RemovePasswordAsync(It.IsAny<User>()))
                .ReturnsAsync(IdentityResult.Failed());
            userManagerMock
                .Setup(umm => umm.AddPasswordAsync(It.IsAny<User>(), pass))
                .ReturnsAsync(IdentityResult.Success);

            var sut = new UsersController(userManagerMock.Object);
            //Act
            await sut.ChangePassword(new UserModalModelView { ID = uID, ConfirmPassword = pass, NewPassword = pass });
            //Assert
            //Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            Assert.IsTrue(sut.StatusMessage.Contains("Error"));
        }
        [TestMethod]
        public async Task Redirect_AddPasswordFails()
        {
            //Arrange
            const string uID = "213123";
            const string pass = "123";
            var user = new User { Id = uID };
            var userManagerMock = new Mock<IUserManager<User>>();
            var passwordValidatorMock = new Mock<IPasswordValidator<User>>();
            passwordValidatorMock
                .Setup(pvm => pvm.ValidateAsync(It.IsAny<UserManager<User>>(), user, pass))
                .ReturnsAsync(IdentityResult.Success);
            userManagerMock
                .SetupGet(umm => umm.Users)
                .Returns(new List<User> { user }.AsQueryable());
            userManagerMock
                .SetupGet(umm => umm.PasswordValidators)
                .Returns(new List<IPasswordValidator<User>> { passwordValidatorMock.Object });
            userManagerMock
                .Setup(umm => umm.RemovePasswordAsync(It.IsAny<User>()))
                .ReturnsAsync(IdentityResult.Success);
            userManagerMock
                .Setup(umm => umm.AddPasswordAsync(It.IsAny<User>(), pass))
                .ReturnsAsync(IdentityResult.Failed());

            var sut = new UsersController(userManagerMock.Object);
            //Act
            await sut.ChangePassword(new UserModalModelView { ID = uID, ConfirmPassword = pass, NewPassword = pass });
            //Assert
            //Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            Assert.IsTrue(sut.StatusMessage.Contains("Error"));
        }
    }
}
