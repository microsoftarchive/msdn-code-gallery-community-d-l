// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


namespace AdventureWorks.UILogic.Tests.Mocks
{
    public static class CustomDelegates
    {
        public delegate void InOutOutAction<T, TOut1, TOut2>(T in1, out TOut1 out1, out TOut2 out2);
    }
}
