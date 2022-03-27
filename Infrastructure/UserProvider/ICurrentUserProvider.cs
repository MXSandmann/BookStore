using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UserProvider
{
    public interface ICurrentUserProvider
    {
        int UserId();
        

        
    }
}
