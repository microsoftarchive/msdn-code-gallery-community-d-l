// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AdventureWorks.UILogic.Services;
namespace AdventureWorks.UILogic.Tests.Mocks
{
    public class MockLocationService : ILocationService
    {
        public Task<IReadOnlyCollection<string>> GetStatesAsync()
        {
            var states = new List<string> {"State1", "State2"};
            IReadOnlyCollection<string> stateCollection = new ReadOnlyCollection<string>(states);
            return Task.FromResult(stateCollection);
        }
    }
}
