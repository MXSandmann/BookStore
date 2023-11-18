using System;
using System.Linq.Expressions;

namespace Infrastructure.Specification
{
    public interface ISpecification<T>
    {
        abstract Expression<Func<T, bool>> CreateCriterium();

        ISpecification<T> And(ISpecification<T> specification);
        ISpecification<T> Or(ISpecification<T> specification);
    }
}
