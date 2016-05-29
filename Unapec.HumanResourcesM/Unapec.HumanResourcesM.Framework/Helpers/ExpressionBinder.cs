using System;
using System.Linq.Expressions;

namespace Unapec.HumanResourcesM.Framework.Helpers
{
    public class ExpressionBinder
    {

        public static Func<T, bool> BuildAndExpression<T>(params Expression<Func<T, bool>>[] expressions)
        {
            var builder = LinqKit.PredicateBuilder.True<T>();
            foreach (var expr in expressions)
            {
                builder = LinqKit.PredicateBuilder.And(builder, expr);
            }

            return builder.Compile();
        }

    }
}
