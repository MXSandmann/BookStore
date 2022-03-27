using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base
{
    public interface IAuditableEntity
    {
       

        void Create(int createdBy);
        void Update(int updatedBy);
    }
}
