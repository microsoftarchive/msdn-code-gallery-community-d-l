// ***********************************************************************
// Assembly         : FhirPatient
// Author           : SH
// Created          : 05-07-2014
//
// Last Modified By : SH
// Last Modified On : 05-08-2014
// ***********************************************************************
// <copyright file="GetPatientCommandHandler.cs" author="Stefan Heesch, @hb9tws">
//     Licensend under the Apache 2.0 license : http://www.apache.org/licenses/LICENSE-2.0.html.
// </copyright>
// <summary>
// This file shows hou you can retrieve a patient resource identified by
// it's ID from a FHIR server. The code make use the of the FHIR .NET
// reference implementation. For addtional information regarding HL7 FHIR
// please refer to the FHIR specification http://www.hl7.org/implement/standards/fhir/
// For further information about the .NET reference implementation please
// refer to Ewout Kramer's Github repository:http://ewoutkramer.github.io/fhir-net-api/
//</summary>
// ***********************************************************************
using System;
using System.IO;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Serialization;


namespace FhirPatient
{
    /// <summary>
    /// Class GetPatientCommandHandler.
    /// </summary>
    /// <remarks> </remarks>
    class GetPatientCommandHandler : CommandHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetPatientCommandHandler"/> class.
        /// </summary>
        /// <remarks> </remarks>
        public GetPatientCommandHandler()
        {
            ID = "get";
        }

        /// <summary>
        /// Shows the usage.
        /// </summary>
        /// <remarks> </remarks>
        public override void ShowUsage()
        {
            Console.WriteLine( String.Format("Command : {0} -id <patient identifier> [-version <version>] [-format json|xml] [-file <output>]", ID));
            Console.WriteLine();
        }

        /// <summary>
        /// Executes the specified arguments.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks> </remarks>
        public override int Execute(Arguments arguments)
        {
            // Get us the needed parameters first
            //
            var url = arguments["url"];
            var id = arguments["id"];
            var version = arguments["version"];
            var format = arguments["format"];

            // Call the FHIR server
            //
            try
            {
                var client = new FhirClient(url);
                var identity = ResourceIdentity.Build("Patient", id, version);
                var patient = client.Read(identity);

                String text;

                if ( format == "json")
                {
                    text = FhirSerializer.SerializeResourceToJson(patient.Resource);
                }
                else
                {
                    text = FhirSerializer.SerializeResourceToXml(patient.Resource);
                }

                if ( !String.IsNullOrEmpty(arguments["file"]) )
                {
                    File.WriteAllText( arguments["file"], text);
                }
                else
                {
                    Console.WriteLine(text);
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
