using System;

namespace SaqueContaBancaria_Console.Entities.Exceptions
{
    internal class DomainException : ApplicationException
    {
        public DomainException(string message) : base(message)
        {

        }
    }
}
