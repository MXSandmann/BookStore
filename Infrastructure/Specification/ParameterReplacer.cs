using System.Linq.Expressions;

namespace Infrastructure.Specification
{
    internal class ParameterReplacer : ExpressionVisitor
    {
        private ParameterExpression _parameter;
        public ParameterReplacer(ParameterExpression parameter)
        {
            _parameter = parameter;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return base.VisitParameter(_parameter);
        }
    }
}
