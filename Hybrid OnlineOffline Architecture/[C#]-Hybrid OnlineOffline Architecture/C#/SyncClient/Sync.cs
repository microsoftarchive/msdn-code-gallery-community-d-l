using System;
using System.Data.SqlClient;
using System.Linq;

using ApexSql.Diff;
using ApexSql.Diff.Structure;
using ApexSql.Diff.Data;

using SyncClient.Properties;
using SyncClient.SchemaService;
using ApexSql.Diff.SqlServer;
using System.Text;
using System.Data;

namespace SyncClient
{
    public static class Sync
    {
        public static void Synchronize()
        {
            ConnectionProperties
                remote = new ConnectionProperties(Settings.Default.RemoteServer, Settings.Default.RemoteDb),
                local = new ConnectionProperties(Settings.Default.LocalServer, Settings.Default.LocalDb);

            using (var service = new SchemaServiceClient()) {

                //check for schema update
                byte version = service.GetSchemaVersion();
                if (version > Settings.Default.SchemaVersion) {
                    //synchronise schema
                    StructureProject structure = new StructureProject(remote, local);

                    structure.ComparisonOptions.IgnoreIdentitySeedAndIncrement = true;
                    structure.MappedObjects.ExcludeAllFromComparison();

                    //select the desired tables and triggers
                    var tables = Settings.Default.Tables.Split(',');
                    structure.MappedTables.IncludeInComparison(tables.Select(t => '^' + t + '$').ToArray());
                    structure.MappedTriggers.IncludeInComparison(tables.Select(t => '^' + t + "_TimeStamp$").ToArray());

                    structure.ComparedObjects.IncludeAllInSynchronization();
                    Synchronise(structure);

                    Settings.Default.SchemaVersion = version;
                    Settings.Default.Save();
                }

                //server to client
                DataProject down = new DataProject(remote, local);
#pragma warning disable 612
                down.ComparisonOptions.CompareAdditionalRows = false;
#pragma warning restore 612

                //only retrieve rows which have changed since last sync
                string timestamp = "TimeStamp > '" + Settings.Default.LastSync.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                foreach (MappedDataObject<Table> table in down.MappedTables) {
                    table.WhereClause.SourceFilter = timestamp;
                    table.WhereClause.UseSourceFilterForDestination = false;
                }

                down.ComparedObjects.IncludeAllInSynchronization();
                Synchronise(down);

                //client to server
                DataProject up = new DataProject(local, remote);
#pragma warning disable 612
                up.ComparisonOptions.CompareAdditionalRows = false;
#pragma warning restore 612

                using (var con = new SqlConnection(Settings.Default.Local))
                    foreach (MappedDataObject<Table> table in up.MappedTables) {
                        StringBuilder ids = new StringBuilder("ID in (");
                        using (var com = new SqlCommand("select ID from " + table.SourceName + " where " + timestamp, con)) {
                            con.Open();
                            using (var results = com.ExecuteReader(CommandBehavior.CloseConnection))
                                while (results.Read())
                                    ids.Append(results[0]).Append(',');
                        }
                        if (ids[ids.Length - 1] == '(')
                            table.IncludeInComparison = false;
                        else
                            table.WhereClause.SourceFilter = ids.Remove(ids.Length - 1, 1).Append(')').ToString();
                    }

                try {
                    up.ComparedObjects.IncludeAllInSynchronization();
                    Synchronise(up);
                }
                catch (NoSelectedForOperationObjectsException) { }

                Settings.Default.LastSync = DateTime.Now;
                Settings.Default.Save();

                //do we have an ID range?
                if (Settings.Default.MaxID == 0) {
                    var range = service.GetIdRange(Environment.MachineName);
                    Settings.Default.MinID = range.Min;
                    Settings.Default.MaxID = range.Max;
                    Settings.Default.Save();
                }
            }

            //reseed the client
            using (var db = new SqlConnection(Settings.Default.Local))
                Repository.Repository.Reseed(Settings.Default.MinID, Settings.Default.MaxID, db);
        }

        private static void Synchronise(ProjectBase project)
        {
            try {
                var errors = project.ExecuteSynchronizationScript();
                if (errors.Length > 0)
                    throw new ApplicationException(string.Join("\n", errors));
            }
            catch (NoSelectedForOperationObjectsException) { }
            catch (UnhandledException e) {
                if (!(e.InnerException is NoSelectedForOperationObjectsException))
                    throw;
            }
            finally {
                project.CloseConnectionToDataSources();
            }
        }

        public static bool IsProvisioned()
        {
            return Settings.Default.SchemaVersion > 0;
        }
    }
}