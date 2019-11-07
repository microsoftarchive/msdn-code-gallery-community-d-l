// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System;
using System.Threading.Tasks;
using Windows.UI.Notifications;

namespace AdventureWorks.UILogic.Services
{
    public interface ISecondaryTileService
    {
        bool SecondaryTileExists(string tileId);

        Task<bool> PinSquareSecondaryTile(string tileId, string displayName, string arguments);

        Task<bool> PinWideSecondaryTile(string tileId, string displayName, string arguments);

        Task<bool> UnpinTile(string tileId);

        void ActivateTileNotifications(string tileId, Uri tileContentUri, PeriodicUpdateRecurrence recurrence);
    }
}
