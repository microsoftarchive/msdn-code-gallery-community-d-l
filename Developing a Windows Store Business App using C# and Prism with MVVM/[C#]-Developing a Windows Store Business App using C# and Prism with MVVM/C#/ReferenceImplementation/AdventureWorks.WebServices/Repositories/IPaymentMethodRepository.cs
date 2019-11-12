// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System.Collections.Generic;
using AdventureWorks.WebServices.Models;

namespace AdventureWorks.WebServices.Repositories
{
    public interface IPaymentMethodRepository
    {
        IEnumerable<PaymentMethod> GetAll(string userName);
        void AddUpdate(string userName, PaymentMethod paymentMethod);
        void SetDefault(string userName, string defaultPaymentMethodId);
    }
}