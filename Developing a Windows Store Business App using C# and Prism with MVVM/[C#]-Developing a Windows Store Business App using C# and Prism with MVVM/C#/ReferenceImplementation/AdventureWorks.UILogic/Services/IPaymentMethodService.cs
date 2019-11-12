// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using AdventureWorks.UILogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorks.UILogic.Services
{
    public interface IPaymentMethodService
    {
        Task<IReadOnlyCollection<PaymentMethod>> GetPaymentMethodsAsync();
        Task SavePaymentMethodAsync(PaymentMethod paymentMethod);
        Task SetDefault(string defaultPaymentMethodId);
    }
}
