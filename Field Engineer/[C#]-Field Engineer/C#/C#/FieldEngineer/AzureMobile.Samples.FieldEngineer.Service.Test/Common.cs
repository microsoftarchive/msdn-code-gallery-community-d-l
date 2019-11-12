// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using AzureMobile.Samples.AAD.Graph;

namespace AzureMobile.Samples.FieldEngineer.Service.Test
{
    static class Common
    {
        public const string LocalhostAddress = "http://localhost:58972";

        public static readonly string LocalUserObjectId = AuthorizeAadGroupAttribute.LocalUserObjectId;
        public static readonly string LocalUserName = AuthorizeAadGroupAttribute.LocalUserName;

        public static readonly string FieldAgentAadGroup = AadGroups.FieldAgent.ToString();
        public static readonly string FieldManagerAadGroup = AadGroups.FieldManager.ToString();
    }
}
