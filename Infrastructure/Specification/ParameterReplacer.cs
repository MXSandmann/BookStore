using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
