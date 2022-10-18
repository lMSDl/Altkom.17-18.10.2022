using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Models;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using WebApi.MockDemo.Controllers;

namespace WebApi.MockDemo.Test.Controllers
{
    [TestClass]
    public class UsersControllerTest
    {
        [TestMethod]
        public void Get_OkWithAllUsers()
        {
            //Arrange
            var service = new Mock<ICrudService<User>>();
            var expectedUsers = new Fixture().CreateMany<User>();
            service.Setup(x => x.Read())
                .Returns(expectedUsers);

            var controller = new UsersController(service.Object);
            
            //Act
            var result = controller.Get();

            //Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result;
            Assert.IsInstanceOfType(okResult.Value, typeof(IEnumerable<User>));
            var resultUsers = (IEnumerable<User>)okResult.Value;
            Assert.AreEqual(expectedUsers, resultUsers);
        }

        [TestMethod]
        public void Get_ExistingId_OkWithUser()
        {
            //Arrange
            var service = new Mock<ICrudService<User>>();
            var expectedUser = new Fixture().Create<User>();

            service.Setup(x => x.Read(expectedUser.Id))
                .Returns(expectedUser);

            var controller = new UsersController(service.Object);

            //Act
            var result = controller.Get(expectedUser.Id);

            //Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result;
            Assert.IsInstanceOfType(okResult.Value, typeof(User));
            Assert.AreEqual(expectedUser, (User)okResult.Value);
            service.Verify(x => x.Read(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void Get_NotExistingId_NotFound()
        {
            //Arrange
            var service = new Mock<ICrudService<User>>();
            var id = new Fixture().Create<int>();

            service.Setup(x => x.Read(id))
                .Returns((User)null);

            var controller = new UsersController(service.Object);

            //Act
            var result = controller.Get(id);

            //Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            service.Verify();
        }
    }
}
