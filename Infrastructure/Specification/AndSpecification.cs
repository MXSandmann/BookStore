using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Specification
{
    public class AndSpecification<T> : SpecificationBase<T>
    {
        private ISpecification<T> _left;
        private ISpecification<T> _right;
        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _left = left;
            _right = right;
        }

        public override Expression<Func<T, bool>> CreateCriterium()
        {
            var leftExpr = _left.CreateCriterium();
            var rightExpr = _right.CreateCriterium();
            BinaryExpression andExpression = Expression.AndAlso(leftExpr.Body, rightExpr.Body);
            andExpression = (BinaryExpression)new ParameterReplacer(Expression.Parameter(typeof(T))).Visit(andExpression);
            return Expression.Lambda<Func<T, bool>>(andExpression, Expression.Parameter(typeof(T)));
        }
    }
}
