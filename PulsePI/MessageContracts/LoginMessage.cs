using System;
namespace PulsePI.MessageContracts
{
    public class LoginMessage
    {
        public LoginMessage(string u, string f, string l, string m, DateTime bd, string av, string e)
        {
            username = u;
            firstName = f;
            lastName = l;
            middleName = m;
            birthDate = bd;
            avatarUrl = av;
            email = e;
        }

        public string username { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public DateTime birthDate { get; set; }
        public string avatarUrl { get; set; }
        public string email { get; set; }
    }
}
