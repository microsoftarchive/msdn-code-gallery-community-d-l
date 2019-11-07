// ***********************************************************************
// Assembly         : FhirPatient
// Author           : SH
// Created          : 05-08-2014
//
// Last Modified By : SH
// Last Modified On : 05-08-2014
// ***********************************************************************
// <copyright file="UpdatePatientCommandHandler.cs" author="Stefan Heesch">
//     Apache 2.0 license : http://www.apache.org/licenses/LICENSE-2.0.html.
// </copyright>
// <summary>
// This file shows hou you can update a patient resource identified by
// it's ID from a FHIR server. 
// The code make use the of the FHIR .NET reference implementation. 
// For addtional information regarding HL7 FHIR please refer to the FHIR 
// specification http://www.hl7.org/implement/standards/fhir/
// More about the .NET reference implementation can be found on Ewout 
// Kramer's Github repository: http://ewoutkramer.github.io/fhir-net-api/
//</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Globalization;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;


namespace FhirPatient
{
    /// <summary>
    /// Class UpdatePatientCommandHandler.
    /// </summary>
    /// <remarks>N/A</remarks>
    class UpdatePatientCommandHandler : CommandHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdatePatientCommandHandler"/> class.
        /// </summary>
        /// <remarks>N/A</remarks>
        public UpdatePatientCommandHandler()
        {
            ID = "update";
        }

        /// <summary>
        /// Shows the commands usage and possible parameters
        /// </summary>
        /// <remarks>N/A</remarks>
        public override void ShowUsage()
        {
            Console.WriteLine(String.Format("Command : {0} -url <server> -id <patient identifier> [...]", ID));
            Console.WriteLine("-name <Patient's last name>");
            Console.WriteLine("-firstname <Patient's first name>");
            Console.WriteLine("-dob <Patient's date of birth in format dd/MM/yyyy>");
            Console.WriteLine("-gender <Patient's gender F|M|U");
            Console.WriteLine("-phone <Patient's phone number>");
            Console.WriteLine("-email <Patient's email address>");
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

            var name = arguments["name"];
            var firstname = arguments["firstname"];
            var gender = arguments["gender"];
            var dob = arguments["dob"];
            var phone = arguments["phone"];
            var email = arguments["email"];


            // Try to retrieve patient from server and update it
            try
            {
                // Get patient representation from server
                //
                #region retrieve patient
                var client = new FhirClient(url);
                var identity = ResourceIdentity.Build("Patient", id);
                var entry = client.Read(identity) as ResourceEntry<Patient>;

                var patient = entry.Resource as Patient;
                if (patient == null)
                {
                    Console.WriteLine("Could not retrieve patient {0} from server {1}", id, url);
                    return 1;
                }
                #endregion

                // We have the patient now modify local representation
                //
                #region prepare patient update
                if ( !( String.IsNullOrEmpty( name ) && !String.IsNullOrEmpty( firstname) ))
                {
                    patient.Name = new List<HumanName>();
                    patient.Name.Add( HumanName.ForFamily(name).WithGiven(firstname));
                }

                if (!String.IsNullOrEmpty(gender))
                {
                    patient.Gender = new CodeableConcept("http://dummy.org/gender", gender, gender);
             
                }
            
                if (!String.IsNullOrEmpty(dob))
                {
                    var birthdate = DateTime.ParseExact(dob, "dd/MM/yyyy",new CultureInfo("en-US"));
                    patient.BirthDate = birthdate.ToString("s");
                }

                patient.Telecom = new List<Contact>();
                if (!String.IsNullOrEmpty(phone))
                {
                    patient.Telecom.Add(new Contact()
                    {
                        Value = phone,
                        System = Contact.ContactSystem.Phone,
                        Use = Contact.ContactUse.Home
                    });
                }

                if (!String.IsNullOrEmpty(email))
                {
                    patient.Telecom.Add(new Contact()
                    {
                        Value = email,
                        System = Contact.ContactSystem.Email,
                        Use = Contact.ContactUse.Home
                    });
                }
                #endregion

                // Finally send the update to the server
                //
                #region do patient update 
                entry.Resource = patient;
                client.Update(entry, false);
                Console.WriteLine("Patient {0} updated on server {1}", id, url);
                return 0;
                #endregion
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 1;
            }
        }
    }
}
