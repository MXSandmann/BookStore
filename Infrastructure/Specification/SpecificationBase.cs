using System;
using System.Linq.Expressions;

namespace Infrastructure.Specification
{
    public abstract class SpecificationBase<T> : ISpecification<T>
    {

        public abstract Expression<Func<T, bool>> CreateCriterium();

        public ISpecification<T> And(ISpecification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }

        public ISpecification<T> Or(ISpecification<T> specification)
        {
            return new OrSpecification<T>(this, specification);
        }


        protected Expression<Func<T, bool>> AlwaysTrue()
        {
            return Expression.Lambda<Func<T, bool>>(Expression.Constant(true), Expression.Parameter(typeof(T), "_"));
        }
    }
}
