using System;
using System.Linq.Expressions;

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
