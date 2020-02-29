using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PulsePI.DataContracts;
using PulsePI.MessageContracts;
using PulsePI.Service.ServiceInterfaces;

namespace PulsePI.Controllers
{

    //Reveives a post request containing username and password 
    [Route("api/account")]
    public class AccountController : Controller
    {
        IAccountService _accountService;

        public AccountController(IAccountService acc)
        {
            _accountService = acc;
        }

        [HttpPost("login")]
        public async Task<LoginMessage> Login([FromBody] LoginData contract)
        {
            return await _accountService.Login(contract);
        }


    }
}