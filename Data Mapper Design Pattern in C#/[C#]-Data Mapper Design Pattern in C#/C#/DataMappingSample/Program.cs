using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Reflection;

namespace MasaSam.Data.Mapping
{
    class Program
    {
        static void Main(string[] args)
        {
            //// source instance
            Person person = new Person()
            {
                Name = "Mickey Mouse",
                Age = 85,
                EyeColor = "Blue",
                Sex = "Male",
                Company = new Company() 
                {
                    Name = "Disney"
                }
            };

            //// destination instance
            User user;

            //// default map to map between properties with same name
            var map = DataMapper.Resolve<Person, User>();

            //// conversion
            user = DataMapper.Map<Person, User>(person);

            Compare(person, user);

            //// add mapping between properties with different name, but same meaning
            map.Add<Person, User>(p => p.Sex, u => u.Gender);

            //// conversion
            user = DataMapper.Map<Person, User>(person);

            Compare(person, user);

            //// map property to setter method
            map.Add<Person, User>("EyeColor", "SetEyeColor");

            //// conversion
            user = DataMapper.Map<Person, User>(person);

            Compare(person, user);

            //// ignore mapping
            map.Ignore<User>(u => u.Age);

            //// conversion
            user = DataMapper.Map<Person, User>(person);

            Compare(person, user);

            //// unignore
            map.Unignore<User>(u => u.Age);

            user = DataMapper.Map<Person, User>(person);

            Compare(person, user);

            //// complex
            map.Complex<Person, User>(p => p.Company, u => u.Employer);

            user = DataMapper.Map<Person, User>(person);

            Compare(person, user);

            //// remove
            map.Remove("Company");

            user = DataMapper.Map<Person, User>(person);

            Compare(person, user);

            //// performance
            Performance(1000);

            Console.ReadKey();
        }

        static void Compare(Person person, User user)
        {
            Console.WriteLine("\nConversion result:\n");

            Console.WriteLine("P.Name =  {0}, U.Name =  {1}", person.Name, user.Name);
            Console.WriteLine("P.Age  =  {0}, U.Age  =  {1}", person.Age, user.Age);
            Console.WriteLine("P.Sex  =  {0}, U.Sex  =  {1}", person.Sex, user.Gender);
            Console.WriteLine("P.Color = {0}, U.Color = {1}", person.EyeColor, user.EyeColor.Name);
            Console.WriteLine("P.Comp =  {0}, U.Comp  = {1}", person.Company.Name, user.Employer.Name);
        }

        static void Performance(int count)
        {
            var persons = GetPersons(count);

            DataMapper.RemoveMap<Person, User>();

            var map = DataMapper.Resolve<Person, User>();
            map.Add<Person, User>("EyeColor", "SetEyeColor");
            map.Complex<Person, User>(p => p.Company, u => u.Employer);

            var sw = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < count; i++)
            {
                var user = DataMapper.Map<Person, User>(persons[i]);
            }

            sw.Stop();

            Console.WriteLine("\nMapping {0} instances took {1} ms. Average = {2}\n", count, sw.ElapsedMilliseconds, sw.Elapsed.TotalMilliseconds / count);
        }

        static List<Person> GetPersons(int count)
        {
            List<Person> persons = new List<Person>(count);

            for (int i = 0; i < count; i++)
            {
                persons.Add(new Person()
                        {
                            Name = "Donald Duck",
                            Age = i + 1,
                            Sex = "Male",
                            EyeColor = "Red",
                            Company = new Company() { Name = "Disney" }
                        });
            }

            return persons;
        }
    }

    public class Person
    {
        private int value = 16;

        public string Name { get; set; }

        public int Age { get; set; }

        public string Sex { get; set; }

        public string EyeColor { get; set; }

        public Company Company { get; set; }

        public int GetValue()
        {
            return value;
        }
    }

    public class User
    {
        public User()
        {
            this.EyeColor = Color.Transparent;
            this.Gender = Mapping.Gender.Female;
            this.Employer = new Employer() { Name = "" };
        }

        public string Name { get; set; }

        public double Age { get; set; }

        public Gender Gender { get; set; }

        public Employer Employer { get; set; }

        public Color EyeColor
        {
            get;
            private set;
        }

        public void SetEyeColor(Color color)
        {
            this.EyeColor = color;
        }
    }

    public enum Gender
    {
        Male = 0,
        Female = 1
    }

    public class Company
    {
        public string Name { get; set; }
    }

    public class Employer
    {
        public string Name { get; set; }
    }
}
