//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// This library contains framework components used by all Azure-hosted services.
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Azure.Services.Framework.Internal
{
    #region Using references
    using System;
    using System.Threading;
    #endregion

    internal sealed class AnonymousDisposable : IDisposable
    {
        private readonly Action dispose;
        private int isDisposed;

        public AnonymousDisposable(Action dispose)
        {
            this.dispose = dispose;
        }

        public void Dispose()
        {
            if (Interlocked.Exchange(ref this.isDisposed, 1) == 0)
            {
                this.dispose();
            }
        }
    }
}
