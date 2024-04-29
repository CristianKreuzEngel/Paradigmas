using System;

namespace ApiWebDB.Services.Exceptions
{
    public class InvalidEntityException : Exception
    {
        public InvalidEntityException(string message) : base(message) { 
        }
    }
}
