using System;
using System.Data;
using System.Data.SqlClient;
using DeepEqual.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedLibraryUnitTest.CustomTraits;
using SqlOperationsProject;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using ExceptionsLibrary;
using System.Windows.Forms;
using SMO_Library;

namespace SharedLibraryUnitTest
{
    /// <summary>
    /// The unit class is responsible for validating that the CRUD operations
    /// actually work so they can be used in an application. This is not to
    /// say something will not fail yet with these test method when an exception
    /// is thrown the first thing to do is run these test methods to first rule
    /// out the basic operations.
    /// 
    /// The SqlOperations constructor accepts an optional second parameter which
    /// is false but detault where setting this parameter to true will cause
    /// a SQL statement with parameters to be written to the codelens output window
    /// for a test. Once the test has completed and there are no errors at the
    /// point the query and parameters are written out the sql statement will 
    /// be available in the codelens output window. If you set the second parameter
    /// to true and there is no output in codelens this indicates there was an issue
    /// on the lines of code prior to getting the query and live values for parameters
    /// for the command object CommandText.
    /// 
    /// There is room for more unit test methods but there are the basics, feel free
    /// to add more test methods as needed for your project. One example would be to
    /// test for adding or updating a record that would violate a constraint on the
    /// table e.g. FirstName and LastName columns must be unique and adding a new
    /// record with a FirstName + LastName combination already exists 
    /// 
    /// Not all test belong in this test class, for instance, business validation
    /// rules would be prior to hitting the database layer thus there would be another
    /// test class(s) for performing business rule validation.
    /// </summary>
    /// <remarks>
    /// Requires nu-get package
    /// https://github.com/jamesfoster/DeepEqual
    /// 
    /// Added reference for 
    /// System.Data.DataSetExtensions to this project.
    /// </remarks>
    [TestClass]
    public class UnitTest1 : TestBaseData
    {

        private int peopleRowCount = 2000;
        private int genderRowCount = 3;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            SetDatabaseConnectionString();
        }
        /// <summary>
        /// For each unit test reset People table for
        /// a clean slate.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            ResetPeopleTable();

            if (TestContext.TestName == "ReadAllPeopleRecords")
            {
                if (!string.IsNullOrEmpty(textContextFileName))
                {
                    File.AppendAllText(textContextFileName, $"Being{Environment.NewLine}");
                }
            }
        }
        /// <summary>
        /// Clean up after all tests within this class
        /// </summary>
        [ClassCleanup()]
        public static void ClassCleanup()
        {

        }
        /// <summary>
        /// If there is any cleanup to be done after a test
        /// this is where we would do so.
        /// </summary>
        /// <remarks>
        /// We can perform actions on any and all test methods
        /// or perform actions against specific test methods
        /// as done below, perform a write to a file only when
        /// the test ReadAllPeopleRecords is executed. Please note
        /// that this is brittle in that if the test method name
        /// changes the if statement will never run.
        /// </remarks>
        [TestCleanup]
        public void MethodCleanUp()
        {

            if (TestContext.TestName == "ReadAllPeopleRecords")
            {
                if (!string.IsNullOrEmpty(textContextFileName))
                {
                    File.AppendAllText(textContextFileName, $"End{Environment.NewLine}");
                }
            }
        }
        /// <summary>
        /// This method validates ResetPeopleTable works
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.Internal)]
        public void ResetDatabase()
        {

            TruncateApplicationTestDataPeopleTable();

            Assert.IsTrue(GetRowCountFromApplicationTestDataPeopleTable() == 0, 
                "Expected now rows");

            PopulateApplicationTestDataPeopleTable();

            Assert.IsTrue(GetRowCountFromApplicationTestDataPeopleTable() == peopleRowCount, 
                $"Expected {peopleRowCount} records");

        }
        /// <summary>
        /// Determine if all genders are in the database table using a extensible deep equality comparison library
        /// https://github.com/jamesfoster/DeepEqual
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.Internal)]
        public void ValidateGendersExists()
        {
            var ops = new SqlOperations(TestCatalog);

            Assert.IsTrue(ops.GenderList.Count == genderRowCount, 
                "Expected three gender items");

            Assert.IsTrue(GenderList().All(gender => gender.IsDeepEqual(gender)),
                "Expected to find all genders");

        }
        /// <summary>
        /// Determine read operation functions as expected by
        /// validating there are xxx records which is what is in
        /// the test repository database table. If you change the
        /// row count then of course this test will fail unless
        /// the count is updated here.
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.ReadRecords)]
        public void ReadAllPeopleRecords()
        {           
            var ops = new SqlOperations(TestCatalog,true);
            var dt = ops.ReadPeople();

            Assert.IsTrue(dt.Rows.Count == peopleRowCount, 
                $"Expected {peopleRowCount} rows");
        }
        /// <summary>
        /// Determine sorting function correctly.
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.ReadRecords)]
        public void ReadPeopleRecordsWithSort()
        {
            var expectedLastName = "Acevedo";
            var ops = new SqlOperations(TestCatalog, true);
            BindingSource bs = new BindingSource();
            bs.DataSource = ops.ReadPeople();
            bs.Sort = "LastName";

            Assert.IsTrue(bs.Sort == "LastName", 
                "Expected sort to be LastName");

            var firstRowLastName = ((DataRowView)bs.Current).Row.Field<string>("LastName");
            Assert.IsTrue(firstRowLastName == expectedLastName, 
                "Sorting incorrect");

        }
        /// <summary>
        /// Test to ensure we can return both male and female
        /// list from back end database table
        /// 
        /// Note that SqlOperations constructor sets the
        /// second parameter to true so we can view the command text
        /// for both select statements. Once the test has completed
        /// click on the codelens for the test and click output to
        /// view the two select statements which will show the values
        /// for the values passed to the parameters for the command.
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.ReadRecords)]
        public void GetPeopleByGender()
        {

            var expectedFemaleCount = 1098;
            var expectedMaleCount = 898;

            var ops = new SqlOperations(TestCatalog, true);

            var count = ops.PersonListByGender(GenderRole.Female).Count;
            Assert.IsTrue(count == expectedFemaleCount, 
                $"Expected {expectedFemaleCount} females in list but returned {count}");


            count = ops.PersonListByGender(GenderRole.Male).Count;
            Assert.IsTrue(count == expectedMaleCount,
                $"Expected {expectedMaleCount} males in list but returned {count}");

        }
        /// <summary>
        /// Validate removal of a record
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.DeleteRecord)]
        public void DeleteSinglePerson()
        {
            var ops = new SqlOperations(TestCatalog);

            int personIdentifier = peopleRowCount + 1000;
            Assert.IsFalse(ops.RemovePerson(personIdentifier), 
                "Expected not to delete record");

        }
        [TestMethod]
        [TestTraits(Trait.DeleteRecord)]
        public void DeleteSinglePersonFailure()
        {
            var ops = new SqlOperations(TestCatalog);

            int personIdentifier = 10;
            string firstName = "Charlotte";
            string lastName = "Blevins";

            if (ops.RemovePerson(personIdentifier))
            {

                Assert.IsFalse(PersonExists(firstName, lastName),
                    $"Expected to not find person with id '{personIdentifier}' " +
                     "after delete operation");

            }
            else
            {
                Assert.Fail("Expected record to have been removed");
            }
        }

        /// <summary>
        /// This method test the find birthday method
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.Search)]
        public void BetweenDatesFromPeopleTable()
        {
            var ops = new SqlOperations(TestCatalog);
            var expectedRowCount = 374;

            var startDate = new DateTime(1974, 1, 2, 1, 12, 0);
            var endDate = new DateTime(1984, 1, 2, 1, 12, 0);

            var dtPeople = ops.FindBetweenBirthDay(startDate, endDate);

            Assert.IsTrue(dtPeople.Rows.Count == expectedRowCount,
                $"Expected {expectedRowCount} rows but" + 
                $"returned {dtPeople.Rows.Count} rows");

        }
        [TestMethod]
        [TestTraits(Trait.Search)]
        [Ignore]
        public void FindPersonByIdentifier()
        {
            /*
             * No need to test as we use a method
             * in TestBase for validating finding a person
             * by their primary key via PersonExists
             */
        }
        [TestMethod]
        [TestTraits(Trait.Search)]
        [Ignore]
        public void FindPersonByFirstAndLastName()
        {
            /*
             * No need to test as we use a method
             * in TestBase for validating finding a person
             * ny first and last name via PersonExists
             */
        }

        /// <summary>
        /// This test sets up the backend connection string
        /// with an invalid server instance name. The expected
        /// result is to have a SqlException thrown.
        /// </summary>
        /// <seealso cref="https://msdn.microsoft.com/en-us/library/microsoft.visualstudio.testtools.unittesting.expectedexceptionattribute.aspx"/>
        [TestMethod]
        [TestTraits(Trait.Internal)]
        [ExpectedException(typeof(SqlException))]
        public void InvalidConnection()
        {
            var ops = new SqlOperations("BadServerName");
            var dt = ops.ReadPeople();
            /*
             * Normally one would use an Assert.IsTrue as commented out
             * below but in this case we can use ExpectedException Attribute,
             * see link above in seealso in method header comments.
             */
            //Assert.IsTrue(ops.HasSqlException);
        }
        /// <summary>
        /// Validates the server specified in SqlOperations class is available
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.Internal)]
        public void ValidateServerIsAvailable()
        {
            var backEndOperations = new SqlOperations();
            var smo = new SmoOperations();

            Assert.IsNotNull(smo.LocalServers().FirstOrDefault(server => server.Name == backEndOperations.Server),
                $"Expected server {backEndOperations.Server} to be available");
        }
        /// <summary>
        /// Reverse test from ValidateServerIsAvailable, this ensures LocalServers is working
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.Internal)]
        public void ValidateServerIsNotAvailable()
        {
            var backEndOperations = new SqlOperations();
            var smo = new SmoOperations();

            var badServerName = "BadBadServerName";
            Assert.IsNull(smo.LocalServers().FirstOrDefault(server => server.Name == badServerName),
                $"Expected not to find {badServerName}");
        }
        /// <summary>
        /// Example to see if the catalog exists in the database
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.Internal)]
        public void DefaultCatalogExists()
        {
            var ops = new SqlOperations(TestCatalog);

            SqlConnectionStringBuilder builder =
                        new SqlConnectionStringBuilder(ops.ConnectionString);

            var catalog = builder.InitialCatalog;
            var smo = new SmoOperations();
            var results = smo.DatabaseExists(catalog);
            Assert.IsTrue(smo.DatabaseExists(catalog));
        }

        [TestMethod]
        [TestTraits(Trait.Internal)]
        public void ValidateDatabaseExistsWorks()
        {
            var catalog = "NoneExistsCatalog";
            var smo = new SmoOperations();
            var results = smo.DatabaseExists(catalog);
            Assert.IsFalse(smo.DatabaseExists(catalog));
        }
        [TestMethod]
        [TestTraits(Trait.Internal)]
        public void TablesExists()
        {

            var ops = new SqlOperations(TestCatalog);

            SqlConnectionStringBuilder builder =
                        new SqlConnectionStringBuilder(ops.ConnectionString);

            var catalog = builder.InitialCatalog;
            var smo = new SmoOperations();

            Assert.IsTrue(smo.TableExists(catalog, "People"),
                "Expected to find People table");

            Assert.IsTrue(smo.TableExists(catalog, "Gender"),
                "Expected to find Gender table");

            Assert.IsFalse(smo.TableExists(catalog, "Products"),
                "Expected not to find Products table");

        }
        /// <summary>
        /// Validate constraint exists
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.Internal)]
        public void ConstraintExists()
        {
            var ops = new SqlOperations(TestCatalog);

            SqlConnectionStringBuilder builder =
                        new SqlConnectionStringBuilder(ops.ConnectionString);

            var catalog = builder.InitialCatalog;
            var smo = new SmoOperations();


            var test = smo.TableKeys(catalog, "Gender");
            Assert.IsTrue(test.Count == 1,
                "Expected one constraint");

            Assert.IsTrue(test.First().SchemaName == "FK_People_Gender", 
                "FK_People_Gender does not exists");

            Assert.IsTrue(test.First().TableName == "People",
                "TableName should be People");
        }

        #region Two versions of inserting a record, one by concrete class and one by DataRow
        /// <summary>
        /// Test we can add a new record
        /// * Two Asserts are used yet the first one is enough
        ///   but some may want to double check hence the second test.
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.InsertRecord)]
        public void InsertPerson()
        {
            var ops = new SqlOperations(TestCatalog, true);

            Person p = new Person()
            {
                FirstName = "Virginia",
                LastName = "Clime",
                Gender = 2,
                BirthDay = new DateTime(1920, 10, 20)
            };

            var success = ops.Add(p);
            Assert.IsTrue(success, "Failed adding person");

            if (success)
            {
                Person newPerson = PersonExists(p.Id);
                newPerson.ShouldDeepEqual(p);
            }
            else
            {
                Assert.Fail("Added record failed");
            }
        }
        /// <summary>
        /// Test that validates a invalid gender can not
        /// be used to insert a new record.
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.InsertRecord)]
        public void InsertPersonWithInvalidGender()
        {

            var ops = new SqlOperations(TestCatalog);
            var badGenderId = ops.GenderIdentifiers.Max() +10;

            Person p = new Person()
            {
                FirstName = "Virginia",
                LastName = "Clime",
                Gender = badGenderId,
                BirthDay = new DateTime(1920, 10, 20)
            };

            ops.Add(p);
            Assert.IsTrue(ops.HasException);

        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.InsertRecord)]
        [ExpectedException(typeof(InvalidGender))]
        public void AddMultiplePersonsWithBadGender()
        {
            var ops = new SqlOperations(TestCatalog);
            var peopleList = new List<Person>(MockedPersonList());
            peopleList.FirstOrDefault().Gender = 4;
            ops.AddPersonList(peopleList);
        }
        [TestMethod]
        [TestTraits(Trait.InsertRecord)]
        public void AddMultiplePersons()
        {
            // expected primary keys for multiple insert
            var expectedIdentifiers = new int[] {2001, 2002, 2003, 2004 };

            var ops = new SqlOperations(TestCatalog);

            // Get mocked list of person
            var peopleList = new List<Person>(MockedPersonList());

            // add multiple people
            ops.AddPersonList(peopleList);

            // Get identifiers for newly added records
            var peopleIdentifiers = peopleList.Select(p => p.Id);

            // Validate new primary keys match those in the expected list
            Assert.IsTrue(peopleIdentifiers.ContainsAll(expectedIdentifiers), 
                $"Expected {string.Join(",", expectedIdentifiers)} for multiple inserts but this was not true.");
            
        }
        [TestMethod]
        [TestTraits(Trait.InsertRecord)]
        public void InsertNewDataRowForPerson()
        {
            var ops = new SqlOperations(TestCatalog);
            var dt = ops.ReadPeople();

            DataRow row = dt.NewRow();
            row["FirstName"] = "Karen";
            row["LastName"] = "Payne";
            row["Gender"] = 1;
            row["BirthDay"] = new DateTime(1960, 8, 20);

            Assert.IsTrue(ops.Add(row));
            Assert.IsTrue(PersonExists(row.Field<string>("FirstName"), row.Field<string>("LastName")));
        }

        #endregion
        #region Two versions for updating a record, one by concrete class and one by DataRow
        /// <summary>
        /// Test updating a single person. The assertion is done via 
        /// a NuGet package library, see readme.txt
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.UpdatRecord)]
        public void UpdateSinglePerson()
        {

            var role = GenderRole.Female;

            var originalPerson = new Person()
            {
                Id = 108,
                FirstName = "Jessie",
                LastName = "Swanson",
                Gender = (int)role,
                BirthDay = new DateTime(1992, 8, 6)
            };

            var modifiedPerson = new Person()
            {
                Id = 108,
                FirstName = "Karen",
                LastName = "Payne",
                Gender = 2,
                BirthDay = new DateTime(1989, 1, 26)
            };


            var ops = new SqlOperations(TestCatalog);

            if (ops.UpdatePerson(modifiedPerson))
            {
                var resultPerson = PersonExists(originalPerson.Id);
                resultPerson.ShouldDeepEqual(modifiedPerson);
            }

        }
        [TestMethod]
        [ExpectedException(typeof(InvalidGender))]
        [TestTraits(Trait.UpdatRecord)]
        public void UpdateSinglePersonWithIncorrectGender()
        {
            
            var role = GenderRole.Female;

            var originalPerson = new Person()
            {
                Id = 108,
                FirstName = "Jessie",
                LastName = "Swanson",
                Gender = (int)role,
                BirthDay = new DateTime(1992, 8, 6)
            };

            // Gender value out of range
            var modifiedPerson = new Person()
            {
                Id = 108,
                FirstName = "Karen",
                LastName = "Payne",
                Gender = 10,
                BirthDay = new DateTime(1989, 1, 26)
            };


            var ops = new SqlOperations(TestCatalog);

            if (ops.UpdatePerson(modifiedPerson))
            {
                var resultPerson = PersonExists(originalPerson.Id);
                resultPerson.ShouldDeepEqual(modifiedPerson);
            }
        }
        /// <summary>
        /// Attempt to pass a invalid date time, when done this
        /// way we will never get passed assigning the invalid
        /// date time to the modifiedPerson var.
        /// </summary>
        [TestMethod]
        [Ignore]
        [TestTraits(Trait.UpdatRecord)]
        public void UpdatePersonInvalidBirthDate()
        {
            var role = GenderRole.Female;
            var invalidBirthDate = new DateTime(1989, 1, 50);

            var originalPerson = new Person()
            {
                Id = 108,
                FirstName = "Jessie",
                LastName = "Swanson",
                Gender = (int)role,
                BirthDay = new DateTime(1992, 8, 6)
            };

            // Gender value out of range
            var modifiedPerson = new Person()
            {
                Id = 108,
                FirstName = "Karen",
                LastName = "Payne",
                Gender = 2,
                BirthDay = invalidBirthDate
            };


            /*
             * We will not get this far because of the invalid BirtDay
             */

            var ops = new SqlOperations(TestCatalog);

            if (ops.UpdatePerson(modifiedPerson))
            {
                var resultPerson = PersonExists(originalPerson.Id);
                resultPerson.ShouldDeepEqual(modifiedPerson);
            }
     
        }
        [TestMethod]
        [TestTraits(Trait.UpdatRecord)]
        public void UpdatePersonUsingDataRow()
        {
            var ops = new SqlOperations(TestCatalog);
            var dt = ops.ReadPeople();

            var expectedFirstName = "Karen";
            var expectedLastName = "Payne";

            var row = dt.AsEnumerable().FirstOrDefault(p => p.Field<int>("id") == 1);
            var originalFirstName = row.Field<string>("FirstName");
            var originalLastName = row.Field<string>("LastName");

            row.SetField<string>("FirstName", expectedFirstName);
            row.SetField<string>("LastName", expectedLastName);

            var result = ops.UpDatePerson(row);
            Assert.IsTrue(result);

            var person = PersonExists(row.Field<int>("id"));

            Assert.IsTrue(person.FirstName == expectedFirstName,
                $"Expected first name {expectedFirstName} but was not the case");

            Assert.IsTrue(person.LastName == expectedLastName,
                $"Expected last name {expectedLastName} but was not the case");

        }
        /// <summary>
        /// Here we test updating more than one person
        /// </summary>
        /// <remarks>
        /// The assumption is that if first name checks out
        /// in two of the people and that the expected count
        /// is equal to the list going in we are good.
        /// 
        /// We could check other properties/field values
        /// to yet that is not needed as we know if BatchUpdatePeople
        /// returned true we are good to go.
        /// </remarks>
        [TestMethod]
        [TestTraits(Trait.UpdatRecord)]
        public void BulkPersonUpdate()
        {
            var ops = new SqlOperations(TestCatalog);
            var peopleList = new List<Person>(MockedPersonList());

            ops.AddPersonList(peopleList);

            var personOneId = peopleList[0].Id;
            peopleList[0].FirstName = "Betty";
            peopleList[0].LastName = "Jones";
            peopleList[0].BirthDay = new DateTime(1966, 11, 11);

            var personThreeId = peopleList[3].Id;
            peopleList[3].FirstName = "Gary";
            peopleList[3].LastName = "Smith";
            peopleList[3].BirthDay = new DateTime(1988, 10, 21);

            Assert.IsTrue(ops.BatchUpdatePeople(peopleList));

            var firstPerson = PersonExists(personOneId);
            Assert.IsTrue(firstPerson.FirstName == "Betty", 
                "Expected Betty");

            var thirdPerson = PersonExists(personThreeId);
            Assert.IsTrue(thirdPerson.FirstName == "Gary", 
                "Expected Gary");
        }

        #endregion
    }
}
