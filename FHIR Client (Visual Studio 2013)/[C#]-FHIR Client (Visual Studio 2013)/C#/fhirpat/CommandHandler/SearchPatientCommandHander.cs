// ***********************************************************************
// Assembly         : FhirPatient
// Author           : SH
// Created          : 05-08-2014
//
// Last Modified By : SH
// Last Modified On : 05-08-2014
// ***********************************************************************
// <copyright file="SearchPatientCommandHander.cs" author="Stefan Heesch">
//     Apache 2.0 license : http://www.apache.org/licenses/LICENSE-2.0.html.
// </copyright>
// <summary>
// This file shows hou you can search for a patient resource by his name.
// The code make use the of the FHIR .NET reference implementation.
// For addtional information regarding HL7 FHIR
// please refer to the FHIR specification http://www.hl7.org/implement/standards/fhir/
// For further information about the .NET reference implementation please
// refer to Ewout Kramer's Github repository:http://ewoutkramer.github.io/fhir-net-api/
//</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Rest;

namespace FhirPatient
{
    /// <summary>
    /// Class SearchPatientCommandHander.
    /// </summary>
    /// <remarks>N/A</remarks>
    class SearchPatientCommandHander : CommandHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchPatientCommandHander" /> class.
        /// </summary>
        /// <remarks>N/A</remarks>
        public SearchPatientCommandHander()
        {
            ID = "search";
        }

        /// <summary>
        /// Shows the commands usage and possible parameters
        /// </summary>
        /// <remarks>N/A</remarks>
        public override void ShowUsage()
        {
            Console.WriteLine(String.Format("Command : {0} -url <server> -text <some piece of text in the patient's name", ID));
        }

        /// <summary>
        /// Executes the specified arguments.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>N/A</remarks>
        public override int Execute(Arguments arguments)
        {
            // Get us the needed parameters first
            //
            var url = arguments["url"];
            var text = new [] { "name=" + arguments["text"]};

            // Query FHIR server for a list of matching patient resources
            //
            try
            {
                var client = new FhirClient(url);
                var result = client.SearchAsync("Patient", text).Result;

                if (result.Entries.Count == 0)
                {
                    Console.WriteLine("Server {0} returned not results for search criteria [{1}]", url, text[0]);
                    return 1;
                }

                foreach (var entry in result.Entries)
                {
                    var rid = new ResourceIdentity(entry.Id);
                    Console.WriteLine("Found patient {0} that matches {1} on {2}", rid.Id, text[0], url);
                }
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 1;
            }

        }
    }
}
