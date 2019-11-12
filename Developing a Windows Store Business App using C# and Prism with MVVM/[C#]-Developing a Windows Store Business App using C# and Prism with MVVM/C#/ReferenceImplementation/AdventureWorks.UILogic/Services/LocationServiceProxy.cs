// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading.Tasks;
using AdventureWorks.UILogic.Models;
using Windows.Web.Http;
using System;
using Newtonsoft.Json;

namespace AdventureWorks.UILogic.Services
{
    public class LocationServiceProxy : ILocationService
    {
        private string _clientBaseUrl = string.Format(CultureInfo.InvariantCulture, "{0}/api/Location", Constants.ServerAddress);

        public async Task<IReadOnlyCollection<string>> GetStatesAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(new Uri(_clientBaseUrl));
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ReadOnlyCollection<string>>(responseContent);

                return result;
            }
        }
    }
}
