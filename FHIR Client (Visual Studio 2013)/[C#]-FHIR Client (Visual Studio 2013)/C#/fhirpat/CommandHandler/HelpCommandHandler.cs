// ***********************************************************************
// Assembly         : FhirPatient
// Author           : SH
// Created          : 05-07-2014
//
// Last Modified By : SH
// Last Modified On : 05-08-2014
// ***********************************************************************
// <copyright file="HelpCommandHandler.cs" author="Stefan Heesch, @hb9tws">
//     Licensend under the Apache 2.0 license : http://www.apache.org/licenses/LICENSE-2.0.html.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Reflection;

namespace FhirPatient
{
    /// <summary>
    /// Class HelpCommandHandler.
    /// </summary>
    /// <remarks> </remarks>
    class HelpCommandHandler : CommandHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HelpCommandHandler"/> class.
        /// </summary>
        /// <remarks> </remarks>
        public HelpCommandHandler()
        {
            ID = "help";
        }

        /// <summary>
        /// Executes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="System.InvalidOperationException">Help is not meant to execute a command - you found a bug</exception>
        /// <remarks> </remarks>
        public override int Execute(Arguments args)
        {
            // Help never executes a command against the FHIR server, so if we come here something went wrong
            //
            throw new InvalidOperationException("Help is not meant to execute a command - you found a bug");
        }

        /// <summary>
        /// Shows the usage.
        /// </summary>
        /// <remarks> </remarks>
        public override void ShowUsage()
        {
            var name = Assembly.GetExecutingAssembly().GetName().Name;

            Console.WriteLine();
            Console.WriteLine("Usage:    {0} -url <server> -cmd <command> [paramters]", name);
            Console.WriteLine("          Send a command for handling a Patient resource to the FHIR server ");
            Console.WriteLine();
            Console.WriteLine("Usage:    {0} -help -cmd <command>", name);
            Console.WriteLine("          Explains available parameters for that command. ");
            Console.WriteLine();
            Console.WriteLine("Usage:    {0} -help",name);
            Console.WriteLine("          Show the list of available commands for handling the FHIR Patient resource. ");
            Console.WriteLine();
            Console.Write("Commands: ");
            ShowCommand();
            Console.WriteLine();
        }

        /// <summary>
        /// Shows the command.
        /// </summary>
        /// <remarks> </remarks>
        public override void ShowCommand()
        {
            if (Successor != null)
            {
                Successor.ShowCommand();
            }
         }

        /// <summary>
        /// Runs the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks> </remarks>
        public override int Run(Arguments args)
        {
            // When we want to execute a command against a FHIR server we always need the command and the server address
            //
            if ( String.IsNullOrEmpty(args["cmd"]) || String.IsNullOrEmpty(args["url"]) || !String.IsNullOrEmpty(args["help"]))
            {
                // User needs obviously some help
                //
                ShowUsage();
                
                if ( !String.IsNullOrEmpty(args["cmd"]) )
                {
                    // See if we we can explain alsoe the parameters by calling the chain of responsibilities ...
                    // 
                    if (Successor != null)
                    {
                        return Successor.Run(args);
                    }
                }
                return 1;
            }

            // We have a command and a server address and were not asked for help, so lets try to throw the command against the
            // FHIR server by running the chain of responsibities ...
            // 
            if (Successor != null)
            {
                return Successor.Run(args);
            }

            // If we end up here something went wrong
            //
            Console.WriteLine("Something went wrong, you found a bug");
            return 1;
        }
    }
}