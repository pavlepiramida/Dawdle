using Dawdle.API.Controllers;
using Dawdle.Core.DTO;
using Dawdle.Service;
using FizzWare.NBuilder;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Threading.Tasks;

namespace Dawdle.API.Test.Controllers
{
    [Category("UsersController")]
    class UsersControllerTest
    {
        private Randomizer _randomizer;

        [SetUp]
        public void Setup()
        {
            _randomizer = new Randomizer();
        }

        [Test]
        [Repeat(2)]
        public void Get_User_Should_Return_OK_With_Payload_When_Username_Is_Given()
        {
            // A
            var expectedValue = Builder<UserDTO>.CreateNew().Build();
            var service = new Mock<IService>();
            service.Setup(x => x.GetUser(It.IsAny<string>())).Returns(Task.FromResult(expectedValue)).Verifiable();
            var usersController = new UsersController(service.Object);
            var parametar = _randomizer.GetString(9);
            // A
            var action = usersController.Get(parametar).Result;
            var response = action.Result as OkObjectResult;
            var responsePayload = response.Value;

            // A
            service.Verify(x => x.GetUser(It.IsAny<string>()), Times.Once);
            Assert.AreEqual(typeof(UserDTO), responsePayload.GetType());
        }

        [Test]
        [TestCase(" ")]
        [TestCase(null)]
        public void Get_User_Should_Return_Bad_Request_If_Paramter_Is_Whitespace_Or_Null(string parametar)
        {
            // A
            var expectedValue = Builder<UserDTO>.CreateNew().Build();
            var service = new Mock<IService>();
            var usersController = new UsersController(service.Object);

            // A
            var action = usersController.Get(parametar).Result;
            var response = action.Result as BadRequestObjectResult;
            var responsePayload = response.Value;

            // A
            service.Verify(x => x.GetUser(It.IsAny<string>()), Times.Never);
            Assert.AreSame(typeof(string), response.Value.GetType());
        }
    }
}
