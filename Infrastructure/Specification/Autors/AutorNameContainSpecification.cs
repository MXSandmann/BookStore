using Domain;
using System;
using System.Linq.Expressions;

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
