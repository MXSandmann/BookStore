using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Specification
{
    public class OrSpecification<T> : SpecificationBase<T>
    {
        private ISpecification<T> _left;
        private ISpecification<T> _right;
        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _left = left;
            _right = right;
        }

        public override Expression<Func<T, bool>> CreateCriterium()
        {
            var leftExpr = _left.CreateCriterium();
            var rightExpr = _right.CreateCriterium();
            BinaryExpression orExpression = Expression.OrElse(leftExpr.Body, rightExpr.Body);
            var paramExpr = Expression.Parameter(typeof(T));
            orExpression = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(orExpression);
            return Expression.Lambda<Func<T, bool>>(orExpression, paramExpr);
        }
    }
}
