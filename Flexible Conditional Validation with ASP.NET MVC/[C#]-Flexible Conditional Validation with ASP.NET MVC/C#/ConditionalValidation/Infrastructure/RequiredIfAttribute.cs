using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ConditionalValidation.Infrastructure
{
    public class RequiredIfAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly string _condition;

        public RequiredIfAttribute(string condition)
        {
            _condition = condition;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Delegate conditionFunction = CreateExpressionDelegate(validationContext.ObjectType, _condition);

            bool conditionMet = (bool) conditionFunction.DynamicInvoke(validationContext.ObjectInstance);

            if (conditionMet)
            {
                if (value == null)
                {
                    return new ValidationResult(FormatErrorMessage(null));
                }
            }
            return null;
        }

        private Delegate CreateExpressionDelegate(Type objectType, string expression)
        {
            // TODO - add caching
            var lambdaExpression = CreateExpression(objectType, expression);
            Delegate func = lambdaExpression.Compile();
            return func;
        }

        private LambdaExpression CreateExpression(Type objectType, string expression)
        {
            // TODO - add caching
            LambdaExpression lambdaExpression =
                System.Linq.Dynamic.DynamicExpression.ParseLambda(
                    objectType, typeof(bool), expression);
            return lambdaExpression;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            string errorMessage = FormatErrorMessage(metadata.GetDisplayName());

            Expression expression = CreateExpression(metadata.ContainerType, _condition);
            var visitor = new JavascriptExpressionVisitor();
            string javascriptExpression = visitor.Translate(expression);

            var clientRule = new ModelClientValidationRule
            {
                ErrorMessage = errorMessage,
                ValidationType = "requiredif",
                ValidationParameters =
                                         {
                                             { "expression", javascriptExpression }
                                         }
            };

            return new[] { clientRule };
        }

    }
}