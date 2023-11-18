using System;

namespace Domain.Exceptions
{
    public class AlreadyExistException : APIException
    {
        public AlreadyExistException(Type EntityType, int ID) : base($"{EntityType.Name}, ID: {ID}")
        {
        }
        public override int Code => 409;
    }
}
