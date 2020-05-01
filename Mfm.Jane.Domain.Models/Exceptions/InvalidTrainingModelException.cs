using System;

namespace Mfm.Jane.Domain.Models.Exceptions
{
    public class InvalidTestModelException: Exception
    {
        public InvalidTestModelException(string message): base(message)
        {
        }
    }
}
