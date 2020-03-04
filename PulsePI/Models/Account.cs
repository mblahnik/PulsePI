using System;

namespace PulsePI.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public DateTime birthDate { get; set; }
        public string avatarUrl { get; set; }
        public string email { get; set; }

    }
}
