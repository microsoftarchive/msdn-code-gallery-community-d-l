namespace EyeOpen.Extensions
{
	using System;
	using System.Linq.Expressions;

	public class TypeExtensions<T>
	{
		/// <exception cref="Exception"><c>Exception</c>.</exception>
		public static string GetProperty<TProperty>(Expression<Func<T, TProperty>> expression)
		{
			if (expression.Body.NodeType != ExpressionType.MemberAccess)
			{
				if ((expression.Body.NodeType == ExpressionType.Convert) && (expression.Body.Type == typeof(object)))
				{
					return ((MemberExpression)((UnaryExpression)expression.Body).Operand).Member.Name;
				}

				throw new Exception(
					string.Format(
						"Invalid expression type: Expected ExpressionType.MemberAccess, Found {0}",
						expression.Body.NodeType));
			}

			return ((MemberExpression)expression.Body).Member.Name;
		}
	}
}