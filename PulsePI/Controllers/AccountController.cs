using Microsoft.AspNetCore.Mvc;


namespace PulsePI.Controllers
{
    [Route("api/account")]
    public class AccountController : Controller
    {
       
        [HttpPost("login")]
        public string Login()
        {
            return "string";
        }


    }
}