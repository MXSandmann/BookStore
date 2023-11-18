using System;

namespace Domain.Exceptions
{
    public abstract class APIException : Exception
    {
        public abstract int Code { get; }

        public APIException(string Message) : base(Message)
        {

        }
    }
}
