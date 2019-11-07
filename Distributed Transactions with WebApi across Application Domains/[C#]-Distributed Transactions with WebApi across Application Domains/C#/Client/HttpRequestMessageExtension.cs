using System;
using System.Net.Http;
using System.Transactions;

namespace Client
{
    public static class HttpRequestMessageExtension
    {
        public static void AddTransactionPropagationToken(this HttpRequestMessage request)
        {
            if (Transaction.Current != null) 
            { 
                var token = TransactionInterop.GetTransmitterPropagationToken(Transaction.Current);
                request.Headers.Add("TransactionToken", Convert.ToBase64String(token));                
            }
        }
    }
}