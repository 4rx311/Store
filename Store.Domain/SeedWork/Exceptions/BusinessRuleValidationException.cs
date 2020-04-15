using System;

namespace Store.Domain.SeedWork.Exceptions
{
    public class BusinessRuleValidationException : Exception
    {
        public BusinessRuleValidationException(string message) : base(message)
        {
        }
    }
}
