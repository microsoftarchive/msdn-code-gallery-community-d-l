// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System.Collections.Generic;

namespace AdventureWorks.WebServices.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetItem(int id);
        T Create(T item);
        bool Update(T item);
        bool Delete(int id);
        void Reset();
    }
}