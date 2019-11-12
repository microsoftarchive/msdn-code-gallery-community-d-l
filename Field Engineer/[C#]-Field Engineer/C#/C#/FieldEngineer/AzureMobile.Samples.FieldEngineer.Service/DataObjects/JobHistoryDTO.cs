// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using Microsoft.WindowsAzure.Mobile.Service;

namespace AzureMobile.Samples.FieldEngineer.Service.DataObjects
{
    public class JobHistoryDTO : EntityData
    {
        public string ActionBy { get; set; }
        public string Comments { get; set; }
        public string JobId { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
