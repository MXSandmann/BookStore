using System;

namespace Domain.Exceptions
{
    public class NotFoundException : APIException
    {
        //public NotFoundException(Type EntityType) : base($"{EntityType.Name}")
        //{
        //}

        public NotFoundException(Type EntityType, int ID) : base($"{EntityType.Name}, ID: {ID}")
        {
        }

        public override int Code => 404;
    }
}
