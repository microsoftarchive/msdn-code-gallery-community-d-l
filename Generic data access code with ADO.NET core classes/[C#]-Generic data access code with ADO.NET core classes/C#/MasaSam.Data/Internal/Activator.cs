using System;
using System.Linq.Expressions;
using System.Reflection;

namespace MasaSam.Data.Internal
{
    internal delegate T Activator<T>(params object[] args);

    internal static class ActivatorFactory
    {
        public static Activator<T> GetActivator<T>(ConstructorInfo ctor)
        {
            if (ctor == null)
                throw new ArgumentNullException("ctor");

            Type type = ctor.DeclaringType;

            if (type.IsAbstract)
                throw new ArgumentException("Constructor is from abstract type.", "ctor");

            if (ctor.IsPrivate)
                throw new ArgumentException("Constructor is private.", "ctor");

            ParameterInfo[] parameters = ctor.GetParameters();

            //// create parameter array of object
            var parameterExpression = Expression.Parameter(typeof(object[]), "args");

            var argsExp = new Expression[parameters.Length];

            //// pick each argument from array
            //// and create a typed expression
            for (int i = 0; i < parameters.Length; i++)
            {
                var index = Expression.Constant(i);

                Type paramType = parameters[i].ParameterType;

                var paramAccessorExpression = Expression.ArrayIndex(parameterExpression, index);

                var paramCastExpression = Expression.Convert(paramAccessorExpression, paramType);

                argsExp[i] = paramCastExpression;
            }

            //// make expression that calls the constructor
            var newExpression = Expression.New(ctor, argsExp);

            //// create lambda with new
            var lambda = Expression.Lambda(typeof(Activator<T>), newExpression, parameterExpression);

            //// compile
            var activator = (Activator<T>)lambda.Compile();

            return activator;
        }
    }
}
