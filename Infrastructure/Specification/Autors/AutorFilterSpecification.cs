using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Specification.Autors
{
    public class AutorFilterSpecification : SpecificationBase<Autor>
    {

        private string _name;
        private string _surname;

        public AutorFilterSpecification(string name, string surname)
        {
            _name = name;
            _surname = surname;
        }

        public override Expression<Func<Autor, bool>> CreateCriterium()
        {
            if (_name == null && _surname == null)
                return AlwaysTrue();

            ISpecification<Autor> compositeSpec = default(ISpecification<Autor>);

            if (_name != null)
                compositeSpec = new AutorNameContainSpecification(_name);

            if (_surname != null)
            {
                var autorSurnameSpec = new AutorSurnameContainSpecification(_surname);
                compositeSpec = compositeSpec == null ? autorSurnameSpec : compositeSpec.Or(autorSurnameSpec); 

            }

            return compositeSpec.CreateCriterium();
        }
    }
}
