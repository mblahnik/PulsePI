using PulsePI.Models;
using Xunit;
using System;
using Moq;
using PulsePI.DataContracts;
using FluentAssertions;
using PulsePI.Controllers;
using PulsePI.Service;
using PulsePI.Service.ServiceInterfaces;


namespace PulseTest.ControllerTest{

      public class AccountContollerTests{


 private Mock<IAccountService> mockAccountService = new Mock<IAccountService>();
          [Fact]

        public void AccountController_Login_Test()
        {
            //arrange 
            var mockController = new AccountController(mockAccountService.Object);
            var loginData = new LoginData()
            {
                username = "mary",
                password = "mary123"
            };

            //act 
            var result = mockController.Login(loginData);
            var result2 = result as OkObjectResult<LoginData>;

            //assert

    Assert.NotNull(result2);
    Assert.Equals(200, okResult.StatusCode);
        }

      }

}