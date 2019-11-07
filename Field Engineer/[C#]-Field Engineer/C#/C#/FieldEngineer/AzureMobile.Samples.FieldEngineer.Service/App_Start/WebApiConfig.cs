// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System.Data.Entity;
using System.Web.Http;
using Autofac;
using AutoMapper;
using AzureMobile.Samples.AAD.Graph;
using AzureMobile.Samples.FieldEngineer.Service.Models;
using AzureMobile.Samples.FieldEngineer.Service.Utilities;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Security;

namespace AzureMobile.Samples.FieldEngineer.Service
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            ConfigOptions options = new ConfigOptions()
              {
                  PushAuthorization = AuthorizationLevel.User
              };

            ConfigBuilder builder = new ConfigBuilder(
                options,
                (httpConfig, autofac) =>
                {
                    autofac.RegisterType<AadHelperProvider>().As<IAadHelperProvider>();
                });

            HttpConfiguration config = ServiceConfig.Initialize(builder);
            Mapper.Initialize(cfg =>
            {
                JobDTOMapper.CreateMapping(cfg);
            });

            Database.SetInitializer(new MobileServiceInitializer());
        }
    }

    public class MobileServiceInitializer : DropCreateDatabaseIfModelChanges<MobileServiceContext>
    {
        protected override void Seed(MobileServiceContext context)
        {
            CreateUpdatedAtTrigger(context, "Job");

            AddDefaultForCreatedAtColumn(context, "Job");

            LocalDBPopulator.PopulateForLocalUser(context);

            base.Seed(context);
        }

        private void CreateUpdatedAtTrigger(MobileServiceContext context, string tableName)
        {
            const string TriggerTemplate = @"CREATE TRIGGER [{{SCHEMA_NAME}}].[TR_{{SCHEMA_NAME}}_{{TABLE_NAME}}_InsertUpdateDelete]
ON [{{SCHEMA_NAME}}].[{{TABLE_NAME}}]
AFTER INSERT, UPDATE, DELETE AS
BEGIN 
	UPDATE [{{SCHEMA_NAME}}].[{{TABLE_NAME}}]
	SET [{{SCHEMA_NAME}}].[{{TABLE_NAME}}].[UpdatedAt] = CONVERT(DATETIMEOFFSET, SYSUTCDATETIME())
	FROM INSERTED
	WHERE inserted.[Id] = [{{SCHEMA_NAME}}].[{{TABLE_NAME}}].[Id]
END";
            var sqlTrigger = TriggerTemplate
                .Replace("{{SCHEMA_NAME}}", context.Schema)
                .Replace("{{TABLE_NAME}}", tableName);
            context.Database.ExecuteSqlCommand(sqlTrigger);
        }

        private void AddDefaultForCreatedAtColumn(MobileServiceContext context, string tableName)
        {
            const string AlterTableTemplate = "ALTER TABLE [{{SCHEMA_NAME}}].[{{TABLE_NAME}}] ADD DEFAULT (sysutcdatetime()) FOR [CreatedAt]";
            var sqlAddDefault = AlterTableTemplate
                .Replace("{{SCHEMA_NAME}}", context.Schema)
                .Replace("{{TABLE_NAME}}", tableName);
            context.Database.ExecuteSqlCommand(sqlAddDefault);
        }
    }
}
