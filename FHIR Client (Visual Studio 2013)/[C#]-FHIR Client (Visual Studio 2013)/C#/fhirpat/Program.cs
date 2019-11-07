// ***********************************************************************
// Assembly         : FhirPatient
// Author           : SH
// Created          : 05-07-2014
//
// Last Modified By : SH
// Last Modified On : 05-08-2014
// ***********************************************************************
// <copyright file="Program.cs" author="Stefan Heesch, @hb9tws">
//     Licensend under the Apache 2.0 license : http://www.apache.org/licenses/LICENSE-2.0.html.
// </copyright>
// <summary>Example client for accessing a FHIR Patient resource from 
// an HL7 FHIR REST service
// </summary>
// ***********************************************************************

using System;
using System.Reflection;

namespace FhirPatient
{
    /// <summary>
    /// Class Program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>System.Int32.</returns>
        static int Main(string[] args)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
            var name = Assembly.GetExecutingAssembly().GetName().Name;

            var header = String.Format("FHIR Client - {0} version {1}", name, version);
            var line = new string('-', header.Length);
            Console.WriteLine(header);
            Console.WriteLine(line);
            Console.WriteLine();

            var commandHandler = new HelpCommandHandler();

            // Wire up the chain of command handlers, helps does somtething special so it needs to come first
            // 
            var get = new GetPatientCommandHandler();
            commandHandler.Successor = get;

            var list = new ListPatientHistoryCommandHandler();
            get.Successor = list;

            var register = new RegisterPatientCommandHandler();
            list.Successor = register;

            var update = new UpdatePatientCommandHandler();
            register.Successor = update;

            var search = new SearchPatientCommandHander();
            update.Successor = search;
            
            // Parse commandline arguments and run chain of responsibilities
            //
            var arguments = new Arguments(args);
            return commandHandler.Run(arguments);
        }
    }
}
