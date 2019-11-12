// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace AzureMobile.Samples.FieldEngineer.Manager.Models
{
    public class JobsViewModel
    {
        public string AgentId { get; set; }

        public string EtaTime { get; set; }

        public string Title { get; set; }

        public string CustomerId { get; set; }

        public List<String> EquipmentsIds { get; set; }
    }
}