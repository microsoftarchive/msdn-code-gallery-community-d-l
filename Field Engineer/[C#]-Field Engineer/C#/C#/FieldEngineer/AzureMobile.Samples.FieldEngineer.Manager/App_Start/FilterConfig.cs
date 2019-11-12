// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------
// This file reused from: https://github.com/AzureADSamples/WebApp-GraphAPI-DotNet/blob/master/WebAppGraphAPI/App_Start/FilterConfig.cs

using System.Web.Mvc;

namespace AzureMobile.Samples.FieldEngineer.Manager
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
