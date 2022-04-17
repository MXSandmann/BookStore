using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Specification.Autors
{
    public class AutorNameContainSpecification : SpecificationBase<Autor>
    {
        private string _name;
        public AutorNameContainSpecification(string name)
        {
            _name = name;
        }
        public override Expression<Func<Autor, bool>> CreateCriterium()
        {
            return (autor) => autor.Name.Contains(_name);
          
        }
    }
}
