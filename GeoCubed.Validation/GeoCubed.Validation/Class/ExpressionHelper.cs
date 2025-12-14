using System.Linq.Expressions;
using System.Reflection;

namespace GeoCubed.Validation.Custom;

internal static class ExpressionHelper
{
    internal static MemberInfo GetMember<TModel, TProperty>(this Expression<Func<TModel, TProperty>> expression)
    {
        var rawExpression = RemoveUnary(expression.Body) as MemberExpression;

        if (rawExpression == null)
        {
            throw new ExpressionUnwrapException("The expression body is null");
        }

        var currentExpression = rawExpression.Expression;
        while (true)
        {
            currentExpression = RemoveUnary(currentExpression);

            if (currentExpression != null && currentExpression.NodeType == ExpressionType.MemberAccess)
            {
                currentExpression = ((MemberExpression)currentExpression).Expression;
            }
            else
            {
                break;
            }
        }

        if (currentExpression == null || currentExpression.NodeType != ExpressionType.Parameter)
        {
            throw new ExpressionUnwrapException("Expression is null or not a parameter.");
        }

        return rawExpression.Member;
    }

    private static Expression RemoveUnary(Expression expression)
    {
        if (expression is UnaryExpression)
        {
            return ((UnaryExpression)expression).Operand;

        }

        return expression;
    }
}
