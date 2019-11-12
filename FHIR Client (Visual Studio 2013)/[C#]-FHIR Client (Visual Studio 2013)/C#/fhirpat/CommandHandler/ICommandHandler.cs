// ***********************************************************************
// Assembly         : FhirPatient
// Author           : SH
// Created          : 05-07-2014
//
// Last Modified By : SH
// Last Modified On : 05-08-2014
// ***********************************************************************
// <copyright file="ICommandHandler.cs" author="Stefan Heesch, @hb9tws">
//     Licensend under the Apache 2.0 license : http://www.apache.org/licenses/LICENSE-2.0.html.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace FhirPatient
{
    /// <summary>
    /// Interface ICommandHandler
    /// </summary>
    /// <remarks> </remarks>
    public interface ICommandHandler
    {
        /// <summary>
        /// Shows the commands usage and possible parameters
        /// </summary>
        void ShowUsage();
        
        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>System.Int32 - In case of a successfull operation 0 is returned, in case of an error 1</returns>
        int Execute(Arguments args);
    }
}