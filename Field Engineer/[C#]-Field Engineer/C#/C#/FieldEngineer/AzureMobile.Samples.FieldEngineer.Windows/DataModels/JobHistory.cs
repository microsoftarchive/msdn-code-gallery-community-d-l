// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;

namespace AzureMobile.Samples.FieldEngineer.DataModels
{
    public partial class JobHistory
    {
        public string Id { get; set; }
        public string ActionBy { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public string Comments { get; set; }
        public string JobId { get; set; }
    }
}
