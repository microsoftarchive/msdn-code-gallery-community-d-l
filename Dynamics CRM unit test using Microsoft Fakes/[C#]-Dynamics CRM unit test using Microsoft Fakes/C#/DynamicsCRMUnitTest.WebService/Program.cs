using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrmOrganizationServiceContextExtensions;
using Microsoft.Xrm.Client;
using Microsoft.Xrm.Client.Services;
using Microsoft.Xrm.Sdk.Client;

namespace DynamicsCRMUnitTest.WebService
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Test Program Started.");

            var connection = new CrmConnection("Crm");
            var context = new OrganizationService(connection);
            var contextMethods = new OrganizationServiceMethods(context);

            var accountId = contextMethods.RetrieveAccountIdByName("test");

            Console.ReadLine();
        }
    }
}
