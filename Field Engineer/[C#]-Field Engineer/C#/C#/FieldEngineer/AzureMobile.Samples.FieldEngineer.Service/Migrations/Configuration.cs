// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

namespace AzureMobile.Samples.FieldEngineer.Service.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<FieldEngineer.Service.Models.MobileServiceContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FieldEngineer.Service.Models.MobileServiceContext context)
        {
            //  This method will be called after migrating to the latest version.
        }
    }
}
