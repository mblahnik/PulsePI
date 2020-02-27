using System;
using Microsoft.AspNetCore.Mvc;

namespace PulsePI.Service.ServiceInterfaces
{
    public interface IAccountService
    {
        public JsonResult Login();
    }
}
