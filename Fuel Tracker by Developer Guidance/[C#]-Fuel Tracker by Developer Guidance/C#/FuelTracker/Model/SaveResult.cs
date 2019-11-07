// ===================================================================================
//  Microsoft Developer Guidance
//  Application Guidance for Windows Phone 7 
// ===================================================================================
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//  OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//  LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//  FITNESS FOR A PARTICULAR PURPOSE.
// ===================================================================================
//  The example companies, organizations, products, domain names,
//  e-mail addresses, logos, people, places, and events depicted
//  herein are fictitious.  No association with any real company,
//  organization, product, domain name, email address, logo, person,
//  places, or events is intended or should be inferred.
// ===================================================================================

using System.Collections.Generic;
using System.Linq;

namespace FuelTracker.Model
{
    /// <summary>
    /// Represents the results of a validation operation. 
    /// </summary>
    public class SaveResult
    {
        private IEnumerable<string> _errorMessages = Enumerable.Empty<string>();
        
        /// <summary>
        /// Gets or sets the error messages, if any, produced by the validation operation.
        /// </summary>
        public IEnumerable<string> ErrorMessages
        {
            get { return _errorMessages; }
            set { _errorMessages = value; }
        }

        /// <summary>
        /// Gets or sets a value that indicates whether validation was successful.
        /// </summary>
        public bool SaveSuccessful { get; set; }
    }
}