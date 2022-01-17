using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public abstract class APIException : Exception
    {
        public abstract int Code  { get; }

        public APIException(string Message) : base(Message)
        {
            
        }
    }
}
