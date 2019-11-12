// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Configuration;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace EventAggregation.AcceptanceTests.Helpers
{
    /// <summary>
    /// Class use for handling the config file and XML Test Data reading
    /// </summary>
    public static class ConfigHandler
    {
        public static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key] ?? String.Empty;
        }

        public static NameValueCollection GetConfigSection(string name)
        {
            return (NameValueCollection)ConfigurationManager.GetSection(name) ?? null;
        }
    }
}
