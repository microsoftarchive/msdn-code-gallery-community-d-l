// ***********************************************************************
// Assembly         : FhirPatient
// Author           : SH
// Created          : 05-07-2014
//
// Last Modified By : SH
// Last Modified On : 05-08-2014
// ***********************************************************************
// <copyright file="CommandHandler.cs" author="Stefan Heesch, @hb9tws">
//     Licensend under the Apache 2.0 license : http://www.apache.org/licenses/LICENSE-2.0.html.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace FhirPatient
{
    /// <summary>
    /// Class CommandHandler.
    /// </summary>
    /// <remarks> </remarks>
    public abstract class CommandHandler : ICommandHandler
    {
        /// <summary>
        /// Gets or sets the successor.
        /// </summary>
        /// <value>The successor.</value>
        /// <remarks> </remarks>
        public CommandHandler Successor { set; get; }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        /// <remarks> </remarks>
        public String ID { set; get; }

        // Display ourself
        //
        /// <summary>
        /// Shows the command.
        /// </summary>
        /// <remarks> </remarks>
        public virtual void ShowCommand()
        {
            Console.Write("{0} ", ID);
            if (Successor != null)
            {
                Successor.ShowCommand();
            }
        }

        // Template method for command execution
        //
        /// <summary>
        /// Runs the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="System.NotSupportedException">CommandHandler field ID needs to be set</exception>
        /// <remarks> </remarks>
        public virtual int Run(Arguments args)
        {
            // Make sure that the command has got a valid ID
            if (String.IsNullOrEmpty(ID))
            {
                throw new NotSupportedException("CommandHandler field ID needs to be set");
            }

            // If we have a url and a command then we try to execute the command against the specified FHIR server
            //
            if ( !(String.IsNullOrEmpty(args["cmd"]) && String.IsNullOrEmpty(args["url"]) ) )
            {
                if (args["cmd"] == ID)
                {
                    if (String.IsNullOrEmpty(args["help"]))
                    {
                        // We execute the command ourself
                        return Execute(args);
                    }
                    else
                    {
                        ShowUsage();
                        return 0;
                    }
                }
                else
                {
                    // Otherwise pass the execution to the next one
                    if (Successor != null)
                    {
                        return Successor.Run(args);
                    }

                    // If we come here then we know that nobody felt responsible to execute the command. Return errorlevel 1
                    return 1;
                }
            }

            // We are missing some parameters, so we explain the usage of this command
            //
            ShowUsage();
            return 1;
        }

        // Subclasses have to implement these two methods
        // 
        #region ICommandHandler
        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>System.Int32 - In case of a successfull operation 0 is returned, in case of an error 1</returns>
        /// <remarks> </remarks>
        public abstract int Execute(Arguments args);
        /// <summary>
        /// Shows the commands usage and possible parameters
        /// </summary>
        /// <remarks> </remarks>
        public abstract void ShowUsage();
        #endregion
    }
}
