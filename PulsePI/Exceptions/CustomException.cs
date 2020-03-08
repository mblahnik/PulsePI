using System;
namespace PulsePI.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException() { }
        public CustomException(string msg) : base(msg) { }
        public CustomException(string msg, Exception inner) : base(msg, inner) { }
    }
}
