// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorks.UILogic.Services
{
    public interface IAlertMessageService
    {
        Task ShowAsync(string message, string title);

        Task ShowAsync(string message, string title, IEnumerable<DialogCommand> dialogCommands);
    }
}
