using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace EntityFrameWorkNorthWind_cs
{
    /// <summary>
    /// Provides property name and validate message. 
    /// This can be placed if you want into a class project and use
    /// in other projects or drop it into your project and use it there.
    /// </summary>
    /// <remarks>
    /// Found here http://stackoverflow.com/questions/13825495/entity-framework-printing-entityvalidationerrors-to-log and modified
    /// </remarks>
    public static class ValidationExtensions
    {
        /// <summary>
        /// A DbEntityValidationException extension method that formates validation errors to string.
        /// </summary>
        public static string DbEntityValidationExceptionToString(this DbEntityValidationException e)
        {
            return e.DbEntityValidationResultToString();
        }
        /// <summary>
        /// A DbEntityValidationException extension method that aggregate database entity validation results to string.
        /// </summary>
        public static string DbEntityValidationResultToString(this DbEntityValidationException e)
        {
            return e.EntityValidationErrors
                    .Select(dbEntityValidationResult => dbEntityValidationResult.DbValidationErrorsToString(dbEntityValidationResult.ValidationErrors))
                    .Aggregate(string.Empty, (current, next) => string.Format("{0}{1}", Environment.NewLine, next));
        }
        /// <summary>
        /// A DbEntityValidationResult extension method that to strings database validation errors.
        /// </summary>
        public static string DbValidationErrorsToString(this DbEntityValidationResult dbEntityValidationResult, IEnumerable<DbValidationError> dbValidationErrors)
        {
            var entityName = string.Format("[{0}]", dbEntityValidationResult.Entry.Entity.GetType().Name);
            const string indentation = "";
            var aggregatedValidationErrorMessages = dbValidationErrors.Select(error => string.Format("[{0} - {1}]", error.PropertyName, error.ErrorMessage))
                                                   .Aggregate(string.Empty, (current, validationErrorMessage) => 
                                                        current + (Environment.NewLine + indentation + validationErrorMessage));
            return aggregatedValidationErrorMessages;
        }
    }
}
