using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using Contoso.Cloud.Integration.Demo.LoanApplication.Data;

namespace Contoso.Cloud.Integration.Demo.LoanApplication.Contract
{
    [ServiceContract(Name = "ILoanApplicationProcessingService", Namespace = "Contoso.Cloud.Integration.Demo")]
    public interface ILoanApplicationProcessingService
    {
        //[OperationContract]
        //bool Submit(LoanApplicationData loanApp);
        [OperationContract(IsOneWay = true, Name = "SubmitApplication")]
        void Submit([MessageParameter(Name = "LoanApplication")] LoanApplicationData loanApp);
    }

    /// <summary>
    /// Defines a client channel contract to communicate with the Loan Processing service.
    /// </summary>
    public interface ILoanApplicationProcessingServiceChannel : ILoanApplicationProcessingService, IClientChannel { }
}