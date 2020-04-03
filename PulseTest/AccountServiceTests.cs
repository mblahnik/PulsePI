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

            //var obj = mockLogin.Object;
       


        }
        [TestMethod]
        public void AccountService_CreateAccount_Test()
        {
            var mockCreateAccount = new Mock<CreateAccountData>();
            mockCreateAccount.Should().NotBeNull();

            mockCreateAccount.SetupGet(m => m.username).Returns(" ")
            .Callback(() => Console.WriteLine("ERROR: Type your ID"));

            mockCreateAccount.SetupGet(m => m.password).Returns(" ")
                .Callback(() => Console.WriteLine("ERROR: Type your Password"));

            mockCreateAccount.SetupGet(m => m.firstName).Returns(" ")
             .Callback(() => Console.WriteLine("ERROR: Type your First Name"));

            mockCreateAccount.SetupGet(m => m.lastName).Returns(" ")
             .Callback(() => Console.WriteLine("ERROR: Type your Last Name"));

            mockCreateAccount.SetupGet(m => m.email).Returns(" ")
             .Callback(() => Console.WriteLine("ERROR: Type your email"));

            //var obj = mockLogin.Object;

        }

    }

}
