using Domain;
using System;
using System.Linq.Expressions;

namespace Infrastructure.Specification.Autors
{
    public class AutorFilterSpecification : SpecificationBase<Autor>
    {

        private readonly string _name;
        private readonly string _surname;

        public AutorFilterSpecification(string name, string surname)
        {
            _name = name;
            _surname = surname;
        }

        public override Expression<Func<Autor, bool>> CreateCriterium()
        {
            if (_name == null && _surname == null)
                return AlwaysTrue();

            ISpecification<Autor> compositeSpec = default;

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
