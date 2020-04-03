using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PulsePI.MessageContracts;
using Moq;
using Moq.Protected;
using PulsePI.DataAccess.DaoInterfaces;
using PulsePI.DataContracts;
using PulsePI.Service;
using PulsePI.Controllers;
using PulsePI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace PulseTest
{
    [TestClass]
    public class AccountServiceTests
    {
        [TestMethod]
        public void AccountService_Login_Test()
        {
            var mockLogin = new Mock<LoginData>();
            mockLogin.Should().NotBeNull();

            mockLogin.SetupGet(m => m.username).Returns(" ")
            .Callback(() => Console.WriteLine("ERROR: Type your ID"));

            mockLogin.SetupGet(m => m.password).Returns(" ")
                .Callback(() => Console.WriteLine("ERROR: Type your Password"));








        }

        public void AccountService_CreateAccount_Test()
        {
            var mockCreateAccount = new Mock<CreateAccountData>();

        }

    }

}
