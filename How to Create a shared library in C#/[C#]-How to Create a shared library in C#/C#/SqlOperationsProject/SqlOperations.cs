using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionsLibrary;
using DataConnections;
using System.Data.SqlClient;
using System.Data;
using DataHelperLibrary;

namespace SqlOperationsProject
{
    public enum GenderRole
    {
        Male =   1,
        Female = 2,
        Other =  3
    }
    public class SqlOperations : BaseSqlServerConnection
    {
        
        /// <summary>
        /// Represents a solutions default catalog/database. 
        /// </summary>
        public SqlOperations() => DefaultCatalog = "ApplicationProductionData";

        /// <summary>
        /// Provides the capability to change the default catalog/database
        /// </summary>
        /// <param name="pCatalog"></param>
        /// <param name="pViewCommand"></param>
        public SqlOperations(string pCatalog, bool pViewCommand = false)
        {
            DefaultCatalog = pCatalog;
            GetGenderValues();
            ViewCommand = pViewCommand;
        }

        /// <summary>
        /// used to permit peeking at command text that use parameters
        /// </summary>
        public bool ViewCommand { get; set; }

        /// <summary>
        /// List of gender identifiers in the database
        /// </summary>
        protected List<int> mGenderIdentifiers;
        public List<int> GenderIdentifiers { get { return mGenderIdentifiers; } }
        protected List<Gender> mGenderList;
        /// <summary>
        /// List of gender records from the database
        /// </summary>
        public List<Gender> GenderList { get { return mGenderList; } }

        /// <summary>
        /// Provides a method to get gender data from backend database
        /// </summary>
        private void GetGenderValues()
        {
            if (mGenderIdentifiers != null)
            {
                return;
            }

            mGenderIdentifiers = new List<int>();

            mHasException = false;

            mGenderList = new List<Gender>();

            using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                {
                    cmd.CommandText = "SELECT RoleId, id, Role  FROM dbo.Gender";
                    try
                    {
                        cn.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            mGenderList.Add(new Gender()
                            {
                                RoleId = reader.GetInt32(0),
                                Id = reader.GetInt32(1),
                                Role = reader.GetString(2)
                            });
                        }
                    }
                    catch (SqlException sqlException)
                    {
                        mHasException = true;
                        mLastException = sqlException;
                        Console.WriteLine(sqlException.Message);
                        throw sqlException;
                    }
                    catch (Exception generalException)
                    {
                        mHasException = true;
                        mLastException = generalException;
                    }
                }
            }

            mGenderIdentifiers = mGenderList.Select(g => g.RoleId).ToList();
        }
        /// <summary>
        /// Returns people by gender
        /// </summary>
        /// <param name="pGender"></param>
        /// <returns></returns>
        public List<Person> PersonListByGender(GenderRole pGender)
        {
            mHasException = false;
            var people = new List<Person>();
            using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                {
                    cmd.CommandText = "SELECT Id ,FirstName,LastName,BirthDay " + 
                                      "FROM ApplicationTestData.dbo.People " + 
                                      "WHERE Gender = @Gender";

                    cmd.Parameters.AddWithValue("@Gender", pGender);
                    
                    if (ViewCommand)
                    {
                        Console.WriteLine(cmd.ActualCommandText());
                    }

                    try
                    {
                        cn.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            people.Add(new Person()
                            {
                                Id = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                BirthDay = reader.GetDateTime(3),
                                Gender = (int)pGender
                            });
                        }
                    }
                    catch (SqlException sqlException)
                    {
                        mHasException = true;
                        mLastException = sqlException;
                        throw sqlException;
                    }
                    catch (Exception generalException)
                    {
                        mHasException = true;
                        mLastException = generalException;
                    }
                }
            }

            return people;
        }
        /// <summary>
        /// Get database server name
        /// </summary>
        public string Server { get { return DatabaseServer; } }
        /// <summary>
        /// Read all records from the People table
        /// </summary>
        /// <returns></returns>
        public DataTable ReadPeople()
        {
            mHasException = false;

            var dtPeople = new DataTable();
            using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                {
                    cmd.CommandText = "SELECT Id,FirstName,LastName,Gender,BirthDay FROM dbo.People";

                    if (ViewCommand)
                    {
                        Console.WriteLine(cmd.ActualCommandText());
                    }

                    try
                    {
                        cn.Open();

                        dtPeople.Load(cmd.ExecuteReader());

                    }
                    catch (SqlException sqlException)
                    {
                        mHasException = true;
                        mLastException = sqlException;
                        throw sqlException;
                    }
                    catch (Exception generalException)
                    {
                        mHasException = true;
                        mLastException = generalException;
                    }
                }
            }

            return dtPeople;
        }
        /// <summary>
        /// Provies functionality to get dates between a data range
        /// </summary>
        /// <param name="pStartDate"></param>
        /// <param name="pEndDate"></param>
        /// <returns></returns>
        public DataTable FindBetweenBirthDay(DateTime pStartDate, DateTime pEndDate)
        {
            mHasException = false;

            var dtPeople = new DataTable();
            using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                {
                    cmd.CommandText = "SELECT FirstName,LastName FROM People " +
                                      "WHERE CAST(BirthDay AS DATE) " + 
                                      "BETWEEN @StartDate AND @EndDate";

                    cmd.Parameters.AddWithValue("@StartDate", pStartDate.Date);
                    cmd.Parameters.AddWithValue("@EndDate", pEndDate.Date);

                    try
                    {
                        cn.Open();
                        dtPeople.Load(cmd.ExecuteReader());
                    }
                    catch (SqlException sqlException)
                    {
                        mHasException = true;
                        mLastException = sqlException;
                        throw sqlException;
                    }
                    catch (Exception generalException)
                    {
                        mHasException = true;
                        mLastException = generalException;
                    }
                }
            }

            return dtPeople;
        }
        /// <summary>
        /// Remove person by id
        /// </summary>
        /// <param name="pIdentifier">Person key</param>
        /// <returns></returns>
        public bool RemovePerson(int pIdentifier)
        {
            mHasException = false;
            bool succcess = false;

            using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                {
                    cmd.CommandText = "DELETE FROM People WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", pIdentifier);

                    if (ViewCommand)
                    {
                        Console.WriteLine(cmd.ActualCommandText());
                    }

                    try
                    {
                        cn.Open();
                        succcess = (cmd.ExecuteNonQuery() == 1);
                    }
                    catch (SqlException sqlException)
                    {
                        mHasException = true;
                        mLastException = sqlException;
                        throw sqlException;
                    }
                    catch (Exception generalException)
                    {
                        mHasException = true;
                        mLastException = generalException;
                    }
                }
            }

            return succcess;

        }
        /// <summary>
        /// Add a list of type person
        /// </summary>
        /// <param name="pList"></param>
        /// <returns></returns>
        /// <remarks>
        /// * Many developers use the incorrect pattern to perform multiple inserts.
        /// * Unlike other methods in this class that wrap the assertion on testing 
        ///   the first assertion simply throws an exception. This was done 
        ///   (and in a real app you would not do this) so you can see how a test method
        ///   can do a negative test via [ExpectedException(typeof(InvalidGender))]. And
        ///   with that never alter your code to make writing a test method easier, always
        ///   think in terms "I don't have access to the source code".
        /// </remarks>
        public bool AddPersonList(List<Person> pList)
        {
            mHasException = false;
            bool succcess = false;

            foreach (Person person in pList)
            {
                if (!mGenderIdentifiers.Contains(person.Gender))
                {
                    mHasException = true;
                    throw new InvalidGender($"{person.Gender} is a invalid gender");
                }
            }

            using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                {
                    // insert statement followed by select to get new primary key
                    cmd.CommandText = "INSERT INTO dbo.People (FirstName,LastName,Gender,BirthDay) " + 
                                      "VALUES (@FirstName,@LastName,@Gender,@BirthDay)" +
                                      ";SELECT CAST(scope_identity() AS int);";

                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@FirstName", DbType = DbType.String });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@LastName", DbType = DbType.String });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Gender", DbType = DbType.Int32});
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@BirthDay", DbType = DbType.DateTime });

                    if (ViewCommand)
                    {
                        Console.WriteLine(cmd.ActualCommandText());
                    }

                    cn.Open();

                    try
                    {
                        foreach (Person person in pList)
                        {
                            cmd.Parameters["@FirstName"].Value = person.FirstName;
                            cmd.Parameters["@LastName"].Value = person.LastName;
                            cmd.Parameters["@Gender"].Value = person.Gender;
                            cmd.Parameters["@BirthDay"].Value = person.BirthDay;
                            person.Id = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        succcess = true;
                    }
                    catch (SqlException sqlException)
                    {
                        mHasException = true;
                        mLastException = sqlException;
                        throw sqlException;
                    }
                    catch (Exception generalException)
                    {
                        mHasException = true;
                        mLastException = generalException;
                    }
                }
            }


            return succcess;

        }
        /// <summary>
        /// Add a single record to the people table using a Person object
        /// </summary>
        /// <param name="pPerson"></param>
        /// <returns></returns>
        public bool Add(Person pPerson)
        {
            mHasException = false;
            bool succcess = false;

            /*
             * In a real application this would be checked
             * in a validation method prior to entering this method.
             * It has been placed here to alert you this should be done.
             */
            try
            {
                if (!mGenderIdentifiers.Contains(pPerson.Gender))
                {
                    mHasException = true;
                    throw new Exception("Invalid gender");
                }
            }
            catch (Exception generalException)
            {
                mHasException = true;
                mLastException = generalException;
            }

            using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                {
                    // insert statement followed by select to get new primary key
                    cmd.CommandText = "INSERT INTO dbo.People (FirstName,LastName,Gender,BirthDay) " + 
                                       "VALUES (@FirstName,@LastName,@Gender,@BirthDay)" +
                                      ";SELECT CAST(scope_identity() AS int);";


                    cmd.Parameters.AddWithValue("@FirstName", pPerson.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", pPerson.LastName);
                    cmd.Parameters.AddWithValue("@Gender", pPerson.Gender);
                    cmd.Parameters.AddWithValue("@BirthDay", pPerson.BirthDay);

                    if (ViewCommand)
                    {
                        Console.WriteLine(cmd.ActualCommandText());
                    }

                    cn.Open();

                    try
                    {
                        pPerson.Id = Convert.ToInt32(cmd.ExecuteScalar());
                        succcess = true;
                    }
                    catch (SqlException sqlException)
                    {
                        mHasException = true;
                        mLastException = sqlException;
                        throw sqlException;
                    }
                    catch (Exception generalException)
                    {
                        mHasException = true;
                        mLastException = generalException;
                    }
                }
            }

            return succcess;
        }
        /// <summary>
        /// Add a single record using a DataRow
        /// </summary>
        /// <param name="pRow"></param>
        /// <returns></returns>
        public bool Add(DataRow pRow)
        {
            mHasException = false;
            bool succcess = false;

            using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                {
                    // insert statement followed by select to get new primary key
                    cmd.CommandText = "INSERT INTO dbo.People (FirstName,LastName,Gender,BirthDay) " + 
                                      "VALUES (@FirstName,@LastName,@Gender,@BirthDay)" +
                                      ";SELECT CAST(scope_identity() AS int);";


                    cmd.Parameters.AddWithValue("@FirstName", pRow.Field<string>("FirstName"));
                    cmd.Parameters.AddWithValue("@LastName", pRow.Field<string>("LastName"));
                    cmd.Parameters.AddWithValue("@Gender", pRow.Field<int>("Gender"));
                    cmd.Parameters.AddWithValue("@BirthDay", pRow.Field<DateTime>("BirthDay"));

                    if (ViewCommand)
                    {
                        Console.WriteLine(cmd.ActualCommandText());
                    }


                    cn.Open();

                    try
                    {
                        pRow.SetField<int>("id",Convert.ToInt32(cmd.ExecuteScalar()));
                        succcess = true;
                    }
                    catch (SqlException sqlException)
                    {
                        mHasException = true;
                        mLastException = sqlException;
                        throw sqlException;
                    }
                    catch (Exception generalException)
                    {
                        mHasException = true;
                        mLastException = generalException;
                    }
                }
            }

            return succcess;
        }
        /// <summary>
        /// Update an existing record by a valid DataRow
        /// </summary>
        /// <param name="pRow"></param>
        /// <returns></returns>
        public bool UpDatePerson(DataRow pRow)
        {
            mHasException = false;
            bool succcess = false;

            using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                {
                    cmd.CommandText = "UPDATE People " +
                                      "SET " +
                                      "FirstName = @FirstName," +
                                      "LastName = @LastName, " +
                                      "Gender = @Gender," +
                                      "BirthDay = @BirthDay " +
                                      "WHERE Id = @Id";

                    try
                    {

                        cmd.Parameters.AddWithValue("@FirstName", pRow.Field<string>("FirstName"));
                        cmd.Parameters.AddWithValue("@LastName", pRow.Field<string>("LastName"));
                        cmd.Parameters.AddWithValue("@Gender", pRow.Field<int>("Gender"));
                        cmd.Parameters.AddWithValue("@BirthDay", pRow.Field<DateTime>("BirthDay"));
                        cmd.Parameters.AddWithValue("@Id", pRow.Field<int>("id"));

                        if (ViewCommand)
                        {
                            Console.WriteLine(cmd.ActualCommandText());
                        }

                        cn.Open();
                        succcess = (cmd.ExecuteNonQuery() == 1);
                    }
                    catch (SqlException sqlException)
                    {
                        mHasException = true;
                        mLastException = sqlException;
                        throw sqlException;
                    }
                    catch (Exception generalException)
                    {
                        mHasException = true;
                        mLastException = generalException;
                    }
                }
            }
            return succcess;
        }
        /// <summary>
        /// Update an existing record using a valid Person object
        /// </summary>
        /// <param name="pPerson"></param>
        /// <returns></returns>
        public bool UpdatePerson(Person pPerson)
        {
            mHasException = false;
            bool succcess = false;
            if (!mGenderIdentifiers.Contains(pPerson.Gender))
            {
                mHasException = true;
                throw new InvalidGender($"{pPerson.Gender} is a invalid gender");
            }

            using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                {
                    cmd.CommandText = "UPDATE People " +
                                      "SET " +
                                      "FirstName = @FirstName," +
                                      "LastName = @LastName, " +
                                      "Gender = @Gender," +
                                      "BirthDay = @BirthDay " +
                                      "WHERE Id = @Id";


                    cmd.Parameters.AddWithValue("@FirstName", pPerson.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", pPerson.LastName);
                    cmd.Parameters.AddWithValue("@Gender", pPerson.Gender);
                    cmd.Parameters.AddWithValue("@BirthDay", pPerson.BirthDay);
                    cmd.Parameters.AddWithValue("@Id", pPerson.Id);

                    if (ViewCommand)
                    {
                        Console.WriteLine(cmd.ActualCommandText());
                    }

                    try
                    {
                        cn.Open();
                        succcess = (cmd.ExecuteNonQuery() == 1);
                    }
                    catch (SqlException sqlException)
                    {
                        mHasException = true;
                        mLastException = sqlException;
                        throw sqlException;
                    }
                    catch (Exception generalException)
                    {
                        mHasException = true;
                        mLastException = generalException;
                    }

                }
            }

            return succcess;
        }
        /// <summary>
        /// Perform a batch update on Person table
        /// </summary>
        /// <param name="pList"></param>
        /// <returns></returns>
        public bool BatchUpdatePeople(List<Person> pList)
        {
            mHasException = false;
            bool succcess = false;
            int affected = 0;

            foreach (Person person in pList)
            {
                if (!mGenderIdentifiers.Contains(person.Gender))
                {
                    mHasException = true;
                    throw new InvalidGender($"{person.Gender} is a invalid gender");
                }
            }

            using (SqlConnection cn = new SqlConnection() { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand() { Connection = cn })
                {

                    cmd.CommandText = "UPDATE dbo.People " + 
                                      "SET FirstName = @FirstName, " + 
                                          "LastName = @LastName , " + 
                                          "Gender = @Gender, " + 
                                          "BirthDay = @BirthDay " + 
                                       "WHERE Id = @Id";

                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@FirstName", DbType = DbType.String });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@LastName", DbType = DbType.String });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Gender", DbType = DbType.Int32 });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@BirthDay", DbType = DbType.DateTime });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Id", DbType = DbType.Int32 });
                    if (ViewCommand)
                    {
                        Console.WriteLine(cmd.ActualCommandText());
                    }

                    cn.Open();

                    try
                    {
                        foreach (Person person in pList)
                        {
                            cmd.Parameters["@FirstName"].Value = person.FirstName;
                            cmd.Parameters["@LastName"].Value = person.LastName;
                            cmd.Parameters["@Gender"].Value = person.Gender;
                            cmd.Parameters["@BirthDay"].Value = person.BirthDay;
                            cmd.Parameters["@id"].Value = person.Id;
                            affected += cmd.ExecuteNonQuery();
                        }

                        succcess = (affected == 4);
                    }
                    catch (SqlException sqlException)
                    {
                        mHasException = true;
                        mLastException = sqlException;
                        throw sqlException;
                    }
                    catch (Exception generalException)
                    {
                        mHasException = true;
                        mLastException = generalException;
                    }
                }
            }

            return succcess;

        }
    }
}
