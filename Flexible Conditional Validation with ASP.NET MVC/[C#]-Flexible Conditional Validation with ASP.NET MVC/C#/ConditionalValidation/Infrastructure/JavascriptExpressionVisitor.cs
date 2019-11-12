using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web.Script.Serialization;

namespace ConditionalValidation.Infrastructure
{
    public class JavascriptExpressionVisitor : ExpressionVisitor
    {
        private StringBuilder _buf;

        private readonly JavaScriptSerializer _javaScriptSerializer = new JavaScriptSerializer();

        public string Translate(Expression expression)
        {
            _buf = new StringBuilder();
            Visit(expression);
            return _buf.ToString().Trim();
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            var expression = ConvertMemberExpression(node);
            _buf.Append(expression);
            return node;
        }

        private string ConvertMemberExpression(MemberExpression memberExpression)
        {
            if (memberExpression.Expression == null)
            {
                // only support DateTime static properties for now
                if (memberExpression.Member.DeclaringType != typeof(DateTime)
                    && memberExpression.Member.MemberType != MemberTypes.Property
                    )
                {
                    throw new ArgumentException("Member access must either be against the model or static properties such as DateTime.Now");
                }
                var value = GetDatePropertyValue(memberExpression);
                var serialisedValue = SerializeDate(value);
                return serialisedValue;
            }
            else
            {
                var propertyName = memberExpression.Member.Name;
                // TODO - should verify that it's the model...
                return string.Format("gv('*.{0}')", propertyName);
            }
            throw new InvalidOperationException("Shouldn't reach here!");
        }

        private DateTime GetDatePropertyValue(MemberExpression memberExpression)
        {
            PropertyInfo propertyInfo = (PropertyInfo)memberExpression.Member;
            DateTime value = (DateTime)propertyInfo.GetValue(null, null);
            return value;
        }


        private string SerializeDate(DateTime value)
        {
            return string.Format("new Date({0},{1},{2},{3},{4},{5})", value.Year, value.Month - 1, value.Day, value.Hour, value.Minute, value.Second);
        }

        protected override Expression VisitUnary(UnaryExpression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.Not:
                    _buf.Append("!");
                    return base.VisitUnary(node);
            }
            throw new NotSupportedException();
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            string operatorString = null;
            switch (node.NodeType)
            {
                case ExpressionType.AndAlso:
                    operatorString = "&&";
                    break;
                case ExpressionType.OrElse:
                    operatorString = "||";
                    break;
                case ExpressionType.And:
                    operatorString = "&";
                    break;
                case ExpressionType.Or:
                    operatorString = "|";
                    break;
                case ExpressionType.LessThan:
                    operatorString = "<";
                    break;
                case ExpressionType.LessThanOrEqual:
                    operatorString = "<=";
                    break;
                case ExpressionType.GreaterThan:
                    operatorString = ">";
                    break;
                case ExpressionType.GreaterThanOrEqual:
                    operatorString = ">=";
                    break;
                case ExpressionType.Equal:
                    operatorString = "==";
                    break;
                case ExpressionType.NotEqual:
                    operatorString = "!=";
                    break;
                default:
                    throw new NotSupportedException();
            }

            Visit(node.Left);
            _buf.Append(" ");
            _buf.Append(operatorString);
            _buf.Append(" ");
            Visit(node.Right);

            return node;
        }
        protected override Expression VisitConstant(ConstantExpression node)
        {
            var value = node.Value;
            if (value is DateTime)
                _buf.Append(SerializeDate((DateTime)value));
            else
                _javaScriptSerializer.Serialize(value, _buf);

            return base.VisitConstant(node);
        }

        protected override Expression VisitNew(NewExpression node)
        {
            if (node.Constructor.DeclaringType == typeof(DateTime))
            {
                object[] args = GetConstArgumentValues(node.Arguments);
                DateTime dateTime = (DateTime)node.Constructor.Invoke(args);
                _buf.Append(SerializeDate(dateTime));
                return node;
            }
            throw new NotSupportedException();
        }

        private object[] GetConstArgumentValues(ReadOnlyCollection<Expression> argumentExpressions)
        {
            object[] args = new object[argumentExpressions.Count];
            for (int i = 0; i < argumentExpressions.Count; i++)
            {
                Expression expression = argumentExpressions[i];
                args[i] = GetConstArgumentValue(expression);
            }
            return args;
        }

        private object GetConstArgumentValue(Expression expression)
        {
            if (expression.NodeType != ExpressionType.Constant)
            {
                throw new ArgumentException("expression must be a constant expression");
            }
            ConstantExpression constantExpression = (ConstantExpression)expression;
            return constantExpression.Value;
        }


        //protected override Expression VisitLambda<T>(Expression<T> node)
        //{
        //    // delve into the lambda
        //    return base.VisitLambda(node);
        //}

        //protected override Expression VisitParameter(ParameterExpression node)
        //{
        //    // called on member invoke
        //    return base.VisitParameter(node);
        //}




        protected override Expression VisitBlock(BlockExpression node)
        {
            throw new NotSupportedException();
        }
        protected override CatchBlock VisitCatchBlock(CatchBlock node)
        {
            throw new NotSupportedException();
        }
        protected override Expression VisitConditional(ConditionalExpression node)
        {
            throw new NotSupportedException();
        }
        protected override Expression VisitDebugInfo(DebugInfoExpression node)
        {
            throw new NotSupportedException();
        }
        protected override Expression VisitDefault(DefaultExpression node)
        {
            throw new NotSupportedException();
        }
        protected override Expression VisitDynamic(DynamicExpression node)
        {
            throw new NotSupportedException();
        }
        protected override ElementInit VisitElementInit(ElementInit node)
        {
            throw new NotSupportedException();
        }
        protected override Expression VisitExtension(Expression node)
        {
            throw new NotSupportedException();
        }
        protected override Expression VisitGoto(GotoExpression node)
        {
            throw new NotSupportedException();
        }
        protected override Expression VisitIndex(IndexExpression node)
        {
            throw new NotSupportedException();
        }
        protected override Expression VisitInvocation(InvocationExpression node)
        {
            throw new NotSupportedException();
        }
        protected override Expression VisitLabel(LabelExpression node)
        {
            throw new NotSupportedException();
        }
        protected override LabelTarget VisitLabelTarget(LabelTarget node)
        {
            throw new NotSupportedException();
        }
        protected override Expression VisitListInit(ListInitExpression node)
        {
            throw new NotSupportedException();
        }
        protected override MemberAssignment VisitMemberAssignment(MemberAssignment node)
        {
            throw new NotSupportedException();
        }
        protected override Expression VisitLoop(LoopExpression node)
        {
            throw new NotSupportedException();
        }
        protected override MemberBinding VisitMemberBinding(MemberBinding node)
        {
            throw new NotSupportedException();
        }
        protected override Expression VisitMemberInit(MemberInitExpression node)
        {
            throw new NotSupportedException();
        }
        protected override MemberListBinding VisitMemberListBinding(MemberListBinding node)
        {
            throw new NotSupportedException();
        }
        protected override MemberMemberBinding VisitMemberMemberBinding(MemberMemberBinding node)
        {
            throw new NotSupportedException();
        }
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            throw new NotSupportedException();
        }
        protected override Expression VisitNewArray(NewArrayExpression node)
        {
            throw new NotSupportedException();
        }
        protected override Expression VisitRuntimeVariables(RuntimeVariablesExpression node)
        {
            throw new NotSupportedException();
        }
        protected override Expression VisitSwitch(SwitchExpression node)
        {
            throw new NotSupportedException();
        }
        protected override SwitchCase VisitSwitchCase(SwitchCase node)
        {
            throw new NotSupportedException();
        }
        protected override Expression VisitTry(TryExpression node)
        {
            throw new NotSupportedException();
        }
        protected override Expression VisitTypeBinary(TypeBinaryExpression node)
        {
            throw new NotSupportedException();
        }
    }
}