// ***********************************************************************
// Assembly         : FhirPatient
// Author           : SH
// Created          : 05-07-2014
//
// Last Modified By : SH
// Last Modified On : 05-08-2014
// ***********************************************************************
// <copyright file="RegisterPatientCommandHandler.cs" author="Stefan Heesch, @hb9tws">
//     Licensend under the Apache 2.0 license : http://www.apache.org/licenses/LICENSE-2.0.html.
// </copyright>
// <summary>
// This file shows hou you can register a new patient resource on a FHIR server.
// The code make use the of the FHIR .NET reference implementation.
// For addtional information regarding HL7 FHIR
// please refer to the FHIR specification http://www.hl7.org/implement/standards/fhir/
// For further information about the .NET reference implementation please
// refer to Ewout Kramer's Github repository:http://ewoutkramer.github.io/fhir-net-api/
// </summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Globalization;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

namespace FhirPatient
{
    /// <summary>
    /// Class RegisterPatientCommandHandler.
    /// </summary>
    class RegisterPatientCommandHandler : CommandHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterPatientCommandHandler"/> class.
        /// </summary>
        public RegisterPatientCommandHandler()
        {
            ID = "register";
        }

        /// <summary>
        /// Shows the usage.
        /// </summary>
        public override void ShowUsage()
        {
            Console.WriteLine(String.Format("Command : {0} -url <server> [...]", ID));
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
        public override int Execute(Arguments arguments)
        {
            // Get us the needed parameters first
            //
            var url = arguments["url"];

            var name = arguments["name"];
            var firstname = arguments["firstname"];
            var gender = arguments["gender"];
            var dob = arguments["dob"];
            var phone = arguments["phone"];
            var email = arguments["email"];

            // Create an in-memory representation of a Patient resource

            var patient = new Patient();
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


            try
            {
                var client = new FhirClient(url);
                var entry = client.Create(patient);

                if (entry == null)
                {
                    Console.WriteLine("Couldn not register patient on server {0}", url);
                    return 1;
                }

                var identity = new ResourceIdentity(entry.Id);
                ID = identity.Id;

                Console.WriteLine("Registered patient {0} on server {1}", ID, url);
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
