using System;
using System.Linq;
using System.Transactions;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApplication.Filters
{
    public class EnlistToDistributedTransactionActionFilter : ActionFilterAttribute
    {
        private const string TransactionId = "TransactionToken";

        /// <summary>
        /// Retrieve a transaction propagation token, create a transaction scope and promote the current transaction to a distributed transaction.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Contains(TransactionId))
            {
                var values = actionContext.Request.Headers.GetValues(TransactionId);
                if (values != null && values.Any())
                {
                    byte[] transactionToken = Convert.FromBase64String(values.FirstOrDefault());
                    var transaction = TransactionInterop.GetTransactionFromTransmitterPropagationToken(transactionToken);
                    var transactionScope = new TransactionScope(transaction);

                    actionContext.Request.Properties.Add(TransactionId, transactionScope);
                }
            }
        }

        /// <summary>
        /// Rollback or commit transaction.
        /// </summary>
        /// <param name="actionExecutedContext">The action executed context.</param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Request.Properties.Keys.Contains(TransactionId))
            {
                var transactionScope = actionExecutedContext.Request.Properties[TransactionId] as TransactionScope;
                if (transactionScope != null)
                {
                    if (actionExecutedContext.Exception != null)
                    {
                        Transaction.Current.Rollback();
                    }
                    else
                    {
                        transactionScope.Complete();
                    }

                    transactionScope.Dispose();
                    actionExecutedContext.Request.Properties[TransactionId] = null;
                }
            }
        }
    }
}