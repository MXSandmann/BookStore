using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
