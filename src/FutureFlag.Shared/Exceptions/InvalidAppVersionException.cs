using System;

namespace FutureFlag.Exceptions
{
    public class InvalidAppVersionException : Exception
    {
        public InvalidAppVersionException(string message) : base(message){}
    }
}