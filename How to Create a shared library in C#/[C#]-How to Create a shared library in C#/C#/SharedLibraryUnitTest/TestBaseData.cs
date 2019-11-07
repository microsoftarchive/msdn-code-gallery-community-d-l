using DataConnections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlOperationsProject;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibraryUnitTest
{
    /// <summary>
    /// This base class is responsible for
    /// * setting up backend database connection
    /// * methods to reset people table so each unit test has a clean slate
    /// </summary>
    /// <remarks>
    /// Try/catch statements may be used yet we want any data operation to
    /// work without them while in production try/catch are a must as the
    /// environment is fluid, out of our control as in a test environment.
    /// </remarks>
    public class TestBaseData : BaseSqlServerConnection
    {
        public static string TestCatalog = "ApplicationTestData";
        public static string connectionString;
        public static string PeopleTable = "People";

        protected string textContextFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Traces.txt");
        protected TestContext testContextInstance;
        
        /// <summary>
        ///  Gets or sets the test context which provides
        ///  information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
        public TestBaseData()
        {
            DefaultCatalog = "ApplicationProductionData";
        }
        public static void SetDatabaseConnectionString()
        {
            var backEndOperations = new SqlOperations();
            connectionString = $"Data Source={backEndOperations.Server};Initial Catalog={TestCatalog};Integrated Security=True";

        }
        /// <summary>
        /// Method to first truncate people table followed by populating people
        /// table from another database.
        /// </summary>
        /// <remarks>
        /// PopulateApplicationTestDataPeopleTable() and TruncateApplicationTestDataPeopleTable()
        /// split this method up so we can test ResetPeopleTable() method. So you could discard 
        /// this method and use the individual methods if you desire. I rather use ResetPeopleTable
        /// method, use the other methods to test then remove them but for this article they will
        /// remain here.
        /// </remarks>
        public void ResetPeopleTable()
        {
            using (SqlConnection cn = new SqlConnection { ConnectionString = connectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {


                    cn.Open();

                    // remove constraint for truncation
                    cmd.CommandText = "ALTER TABLE ApplicationTestData.dbo.People  DROP CONSTRAINT FK_People_Gender;";
                    cmd.ExecuteNonQuery();

                    // truncate and populate
                    cmd.CommandText = "TRUNCATE TABLE ApplicationTestData.dbo.Gender;" +
                                      "INSERT INTO ApplicationTestData.dbo.Gender " +
                                      "( [Role] ,RoleId ) " +
                                      "SELECT [Role] ,RoleId " +
                                      "FROM  ApplicationProductionData.dbo.Gender";

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "TRUNCATE TABLE ApplicationTestData.dbo.People;" +
                                      "INSERT INTO ApplicationTestData.dbo.People " +
                                      "( FirstName , LastName , Gender , BirthDay ) " +
                                      "SELECT FirstName , LastName , Gender , BirthDay " +
                                      "FROM  ApplicationProductionData.dbo.People";


                    cmd.ExecuteNonQuery();

                    // re-create constraint
                    cmd.CommandText = "ALTER TABLE ApplicationTestData.dbo.People WITH NOCHECK ADD CONSTRAINT " + 
                        "[FK_People_Gender] FOREIGN KEY([Gender]) REFERENCES ApplicationTestData.dbo.Gender ([id]);" + 
                        "ALTER TABLE [dbo].[People] NOCHECK CONSTRAINT [FK_People_Gender]";

                    cmd.ExecuteNonQuery();


                }
            }
        }
        protected List<Gender> GenderList()
        {
            return new List<Gender>()
            {
                new Gender() { Id = 1, Role = "Male", RoleId = 1 },
                new Gender() { Id = 2, Role = "Female", RoleId = 2 },
                new Gender() { Id = 3, Role = "Other", RoleId = 3 }
            };
        }
        public List<Person> MockedPersonList()
        {
            return new List<Person>()
            {
                new Person() { FirstName = "Lea", LastName = "Miller", BirthDay = new DateTime(2000,12,1), Gender = 2 },
                new Person() { FirstName = "Ben", LastName = "White", BirthDay = new DateTime(2010,8,3), Gender = 1 },
                new Person() { FirstName = "Mary Ann", LastName = "O'Brian", BirthDay = new DateTime(1987,5,22), Gender = 2 },
                new Person() { FirstName = "Steve", LastName = "Jenkins", BirthDay = new DateTime(1987,5,22), Gender = 3 }
            };
        }
        /// <summary>
        /// Internal method to populate people table where TruncateApplicationTestDataPeopleTable
        /// method needs to be called first else we append records and run into tainted test.
        /// </summary>
        public void PopulateApplicationTestDataPeopleTable()
        {
            using (SqlConnection cn = new SqlConnection { ConnectionString = connectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {

                    cmd.CommandText = "INSERT INTO ApplicationTestData.dbo.People " +
                                      "( FirstName , LastName , Gender , BirthDay ) " +
                                      "SELECT FirstName , LastName , Gender , BirthDay " +
                                      "FROM  ApplicationProductionData.dbo.People";

                    cn.Open();
                    cmd.ExecuteNonQuery();

                }
            }
        }
        /// <summary>
        /// Interal method to truncate people table
        /// </summary>
        public void TruncateApplicationTestDataPeopleTable()
        {
            using (SqlConnection cn = new SqlConnection { ConnectionString = connectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {

                    cmd.CommandText = "TRUNCATE TABLE ApplicationTestData.dbo.People;";

                    cn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                    }

                }
            }
        }
        /// <summary>
        /// Internal usage for testing resetting the people table
        /// </summary>
        /// <returns></returns>
        public int GetRowCountFromApplicationTestDataPeopleTable()
        {
            int rowCount = 0;
            using (SqlConnection cn = new SqlConnection { ConnectionString = connectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = "SELECT COUNT(id) FROM dbo.People AS p";
                    cn.Open();
                    rowCount = (int)cmd.ExecuteScalar();
                }
            }

            return rowCount;
        }
        /// <summary>
        /// Find person by id and return the person or a null person
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        public Person PersonExists(int pId)
        {
            Person foundPerson = null;

            using (SqlConnection cn = new SqlConnection() { ConnectionString = connectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                {

                    cmd.CommandText = "SELECT FirstName, LastName, Gender, BirthDay FROM People " +
                                      "WHERE Id = @Id";

                    cmd.Parameters.AddWithValue("@Id", pId);
                    cn.Open();
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        foundPerson = new Person();
                        foundPerson.Id = pId;
                        foundPerson.FirstName = reader.GetString(0);
                        foundPerson.LastName = reader.GetString(1);
                        foundPerson.Gender = reader.GetInt32(2);
                        foundPerson.BirthDay = reader.GetDateTime(3);
                    }
                }
            }
            return foundPerson;
        }

        /// <summary>
        /// Find person by first and last name
        /// </summary>
        /// <param name="pFirstName"></param>
        /// <param name="pLastName"></param>
        /// <returns>true if found, false if not found</returns>
        public bool PersonExists(string pFirstName, string pLastName)
        {
            bool succcess = false;
            using (SqlConnection cn = new SqlConnection() { ConnectionString = connectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                {

                    cmd.CommandText = "SELECT  Id FROM People " +
                                      "WHERE FirstName = @FirstName AND LastName = @LastName";

                    cmd.Parameters.AddWithValue("@FirstName", pFirstName);
                    cmd.Parameters.AddWithValue("@LastName", pLastName);
                    cn.Open();
                    succcess = !(cmd.ExecuteScalar() == null);
                }
            }
            return succcess;
        }


    }
}
