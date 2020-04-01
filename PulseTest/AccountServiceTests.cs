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


namespace PulseTest
{
    
    public class AccountServiceTests
    {

        public void AccountService_Login_Test()
        {
            var mockLogin = new Mock<LoginData>();

            // mockLogin.Setup(m => m.username(" ")).Throws<InvalidOperationException>();
            //mockLogin.Setup(m => m.password(" ")).Throws<InvalidOperationException>();
            mockLogin.SetupGet(m => m.username).Returns("boyland");
            mockLogin.SetupGet(m => m.password).Returns("boyland");


            var obj = mockLogin.Object;
   
           


        }

        public void AccountService_CreateAccount_Test()
        {
            var mockCreateAccount = new Mock<CreateAccountData>();

        }
        
    }

}
