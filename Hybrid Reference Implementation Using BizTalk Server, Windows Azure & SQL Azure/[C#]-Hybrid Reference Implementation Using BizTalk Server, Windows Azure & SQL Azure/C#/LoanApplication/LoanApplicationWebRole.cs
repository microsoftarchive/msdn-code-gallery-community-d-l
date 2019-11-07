//==================================================================================
// Contoso Cloud Integration Service Layer Solution - Loan Application
//
// The web role implementation
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Demo.LoanApplication
{
    #region Using references
    using System;

    using Contoso.Cloud.Integration.Azure.Services.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Extensions;
    #endregion

    public class LoanApplicationWebRole : ReliableWebRoleBase
    {
        #region ReliableWorkerRoleBase implementation
        protected override void OnRoleStart()
        {
            this.EnsureExists<ActivityTrackingEventStreamExtension>();
            this.EnsureExists<RulesEngineServiceClientExtension>();
        }

        protected override void OnRoleStop()
        {
        } 
        #endregion
    }
}
