using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MasaSam.Data;
using MasaSam.Data.SqlClient;

namespace UsageExample
{
    class Program
    {
        static string cs = @"Data Source=localhost\SQLExpress;Initial Catalog=SampleDatabase;Integrated Security=True";

        static void Main(string[] args)
        {
            GetDataUsingProperties();

            GetDataUsingCtor();

            Console.WriteLine("\nSample end.");
            Console.ReadKey();
        }

        #region How to use default constructor and specified property mappings

        /// <summary>
        /// Executes queries and converts records to objects using default constructor
        /// and specified property mappings.
        /// </summary>
        static void GetDataUsingProperties()
        {
            var mappings = new PropertyColumnMapping[] {
                new PropertyColumnMapping("ID", "PersonID", typeof(int)),
                new PropertyColumnMapping("FirstName", typeof(string)),
                new PropertyColumnMapping("LastName", typeof(string))
            };

            Person person = GetSinglePerson(mappings);

            Console.WriteLine("Person 3 is {0} {1}\n", person.FirstName, person.LastName);

            person = GetFirstPerson(mappings);

            Console.WriteLine("1st Mouse is {0} {1}\n", person.FirstName, person.LastName);

            IEnumerable<Person> persons = GetAllPersons(mappings);

            Console.WriteLine("Persons are");

            foreach (var p in persons)
            {
                Console.WriteLine("{0}: {1} {2}", p.ID, p.FirstName, p.LastName);
            }
        }

        /// <summary>
        /// Executes query that expects only 1 record to be returned.
        /// </summary>
        static Person GetSinglePerson(IEnumerable<PropertyColumnMapping> mappings)
        {
            string sql = "SELECT * FROM Person WHERE PersonID = @id;";
            
            var settings = new SqlCommandSettings(sql, CommandType.Text);
            settings.AddParameter(new SqlParameter("@id", 3));

            var executor = new SqlExecutor(cs);

            var person = executor.GetSingleRecord<Person>(settings, mappings);

            return person;
        }

        /// <summary>
        /// Executes query that might return multiple records, but only takes 1st one.
        /// </summary>
        static Person GetFirstPerson(IEnumerable<PropertyColumnMapping> mappings)
        {
            string sql = "SELECT * FROM Person WHERE LastName = @lastName;";

            var settings = new SqlCommandSettings(sql, CommandType.Text);
            settings.AddParameter(new SqlParameter("@lastName", "Mouse"));

            var executor = new SqlExecutor(cs);

            var person = executor.GetFirstRecord<Person>(settings, mappings);

            return person;
        }

        /// <summary>
        /// Executes query that returns all records.
        /// </summary>
        static IEnumerable<Person> GetAllPersons(IEnumerable<PropertyColumnMapping> mappings)
        {
            string sql = "SELECT * FROM Person;";

            var settings = new SqlCommandSettings(sql, CommandType.Text);

            var executor = new SqlExecutor(cs);

            var persons = executor.GetRecords<Person>(settings, mappings);

            return persons;
        }

        #endregion

        #region How to use specified constructor and property mappings

        /// <summary>
        /// Executes queries and converts records to objects using specified ctor and property mappings.
        /// </summary>
        static void GetDataUsingCtor()
        {
            var propertyMappings = new PropertyColumnMapping[] {
                new PropertyColumnMapping("Name", typeof(string))
            };

            var ctorMappings = new ColumnConstructorParameterMappingCollection<Company>(new Type[] { typeof(int), typeof(string) });
            ctorMappings.Add("CompanyID", 0);
            ctorMappings.Add("RegistryNumber", 1);

            var company = GetSingleCompany(ctorMappings, propertyMappings);

            Console.WriteLine("\nCompany 3 is {0} {1}\n", company.Registry, company.Name);

            company = GetFirstCompany(ctorMappings, propertyMappings);

            Console.WriteLine("1st company is {0} {1}\n", company.Registry, company.Name);

            var companies = GetAllCompanies(ctorMappings, propertyMappings);

            Console.WriteLine("Companies are");

            foreach (var c in companies)
            {
                Console.WriteLine("{0}: {1} {2}", c.ID, c.Registry, c.Name);
            }
        }

        /// <summary>
        /// Executes query that expects only 1 record to be returned.
        /// </summary>
        static Company GetSingleCompany(ColumnConstructorParameterMappingCollection<Company> ctorMappings, IEnumerable<PropertyColumnMapping> propMappings)
        {
            string sql = "SELECT * FROM Company WHERE CompanyID = @id;";

            int id = 3;

            var settings = new SqlCommandSettings(sql, CommandType.Text);
            settings.AddParameter(new SqlParameter("@id", id));

            var executor = new SqlExecutor(cs);

            var company = executor.GetSingleRecord<Company>(settings, ctorMappings, propMappings);

            return company;
        }

        /// <summary>
        /// Executes query that might return multiple records, but only takes 1st one.
        /// </summary>
        static Company GetFirstCompany(ColumnConstructorParameterMappingCollection<Company> ctorMappings, IEnumerable<PropertyColumnMapping> propMappings)
        {
            string sql = "SELECT * FROM Company WHERE RegistryNumber LIKE '788%';";

            var settings = new SqlCommandSettings(sql, CommandType.Text);

            var executor = new SqlExecutor(cs);

            var company = executor.GetFirstRecord<Company>(settings, ctorMappings, propMappings);

            return company;
        }

        /// <summary>
        /// Executes query that might return multiple records, but only takes 1st one.
        /// </summary>
        static IEnumerable<Company> GetAllCompanies(ColumnConstructorParameterMappingCollection<Company> ctorMappings, IEnumerable<PropertyColumnMapping> propMappings)
        {
            string sql = "SELECT * FROM Company;";

            var settings = new SqlCommandSettings(sql, CommandType.Text);

            var executor = new SqlExecutor(cs);

            var companies = executor.GetRecords<Company>(settings, ctorMappings, propMappings);

            return companies;
        }

        #endregion
    }
}
