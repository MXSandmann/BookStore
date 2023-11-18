using Domain;
using System;
using System.Linq.Expressions;

namespace Infrastructure.Specification.Autors
{
    public class AutorSurnameContainSpecification : SpecificationBase<Autor>
    {
        private string _surname;
        public AutorSurnameContainSpecification(string surname)
        {
            _surname = surname;
        }
        public override Expression<Func<Autor, bool>> CreateCriterium()
        {
            return (autor) => autor.Surname.Contains(_surname);

        }
    }
}
