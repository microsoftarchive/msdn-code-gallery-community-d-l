// ***********************************************************************
// Assembly         : FhirPatient
// Author           : SH
// Created          : 05-07-2014
//
// Last Modified By : SH
// Last Modified On : 05-08-2014
// ***********************************************************************
// <copyright file="ListPatientHistoryCommandHandler.cs" author="Stefan Heesch, @hb9tws">
//     Licensend under the Apache 2.0 license : http://www.apache.org/licenses/LICENSE-2.0.html.
// </copyright>
// <summary>
// This file shows hou you can retrieve the history of a patient resource identified by
// it's ID from a FHIR server. The code make use the of the FHIR .NET
// reference implementation. For addtional information regarding HL7 FHIR
// please refer to the FHIR specification http://www.hl7.org/implement/standards/fhir/
// For further information about the .NET reference implementation please
// refer to Ewout Kramer's Github repository:http://ewoutkramer.github.io/fhir-net-api/
//</summary>
// ***********************************************************************
using System;
using Hl7.Fhir.Rest;

/// <summary>
/// The FhirPatient namespace.
/// </summary>
/// <remarks>N/A</remarks>
namespace FhirPatient
{
    /// <summary>
    /// Class ListPatientHistoryCommandHandler.
    /// </summary>
    /// <remarks>N/A</remarks>
    class ListPatientHistoryCommandHandler : CommandHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListPatientHistoryCommandHandler" /> class.
        /// </summary>
        /// <remarks>N/A</remarks>
        public ListPatientHistoryCommandHandler()
        {
            ID = "history";
        }

        /// <summary>
        /// Shows the usage.
        /// </summary>
        /// <remarks>N/A</remarks>
        public override void ShowUsage()
        {
            Console.WriteLine(String.Format("Command : {0} -id <patient identifier>" , ID));
            Console.WriteLine();
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
            var id = arguments["id"];

            // Call the FHIR server
            //
            try
            {
                // First find patient on the server
                //
                var client = new FhirClient(url);
                var identity = ResourceIdentity.Build("Patient", id );
                var patient = client.Read(identity);

                if (patient == null)
                {
                    Console.WriteLine("Did not find patient resource {0} on server {1}", id, url);
                    return 1;
                }

                // Get the history for that patient and display it
                //
                var result = client.History(patient.Id);
                foreach (var e in result.Entries)
                {
                    var rid = new ResourceIdentity(e.SelfLink);
                    Console.WriteLine("Found version {0} of patient resource {1}", rid.VersionId, rid.Id);
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
