// ***********************************************************************
// Assembly         : ServerConsole
// Author           : SH
// Created          : 05-11-2014
//
// Last Modified By : SH
// Last Modified On : 05-11-2014
// ***********************************************************************
// <copyright file="Program.cs" author="Stefan Heesch">
//     Apache 2.0 license : http://www.apache.org/licenses/LICENSE-2.0.html.
// </copyright>
// <summary>Example implementation of an FHIR server based on WCF.
// Supports the Patient Resource only plus conformance statement</summary>
// ***********************************************************************

using System;
using System.Data.Entity;
using System.Reflection;
using System.ServiceModel.Web;
using DataAccess;
using Model;
using Service;

namespace Server
{
    /// <summary>
    /// Class Program.
    /// </summary>
    /// <remarks>N/A</remarks>
    class Program
    {

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <remarks>N/A</remarks>
        static void Main(string[] args)
        {
            InitializeDatabase();


            string url = String.Format("http://localhost:8732/Design_Time_Addresses/fhir");

            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
            var name = Assembly.GetExecutingAssembly().GetName().Name;

            var header = String.Format("FHIR Server - {0} version {1}", name, version);
            var line = new string('-', header.Length);
            Console.WriteLine(header);
            Console.WriteLine(line);
            Console.WriteLine();
          
            // Create an instance of our REST service and pass it to WCF
            var repository = new Repository();
            var service = new RestService(repository);            

            var server = new WebServiceHost( service, new Uri(url));
            server.Opened += server_Opened;
            try
            {
                server.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Press ENTER to exit.");
            Console.ReadLine();
        }

        /// <summary>
        /// Handles the Opened event of the server control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <remarks>N/A</remarks>
        static void server_Opened(object sender, EventArgs e)
        {
            var server = (WebServiceHost) sender;
            Console.WriteLine("Listening on {0}", server.BaseAddresses[0].OriginalString);
        }


        static void InitializeDatabase()
        {
            // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ResourceContext>());
            Database.SetInitializer(new DropCreateDatabaseAlways<ResourceContext>());

            // Add some code to see database with some patients. You can use the repository ...
            //
            var repository = new Repository();

            var patient = new Patient();
            patient.LastName = "Doe";
            patient.FirstName = "John";
            patient.Gender = GenderCode.Male;
            patient.Birthday = new DateTime(1919,11,30);

            patient.AddressLine1 = "Mainstreet";
            patient.City = "New York";
            patient.Country = "USA";

            patient.Nationality = "US";

            repository.CreatePatient(patient);
        }
    }
}
