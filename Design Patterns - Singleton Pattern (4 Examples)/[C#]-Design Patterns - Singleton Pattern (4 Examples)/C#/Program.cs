using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingletonPatternDemo
{
    // Example 1:
    class Emp
    {
        public int No { get; set; }
        public string Name { get; set; }
        public string Sal { get; set; }

        // Private static object can access only inside the Emp class.
        private static Emp emp;

        // Private empty constructor to restrict end use to deny creating the object.
        private Emp()
        {
        }

        // A public method to access outside of the class to create an object.
        public static Emp CreateObject()
        {
            // If the object is null for first time instantiate it once.
            if (emp == null)
            {
                emp = new Emp();
            }

            // Return the emp object, when user request for create an instance.
            return emp;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Emp emp1 = Emp.CreateObject();
            emp1.No = 10;
            emp1.Name = "Sai";
            emp1.Sal = "10000";
            Console.WriteLine("Employee 1 Details:\n No: " + emp1.No + "\n Name: " + emp1.Name + "\n Sal: " + emp1.Sal);

            Emp emp2 = Emp.CreateObject();
            emp2.Name = "Sri";
            Console.WriteLine("Employee 2 Details:\n No: " + emp2.No + "\n Name: " + emp2.Name + "\n Sal: " + emp2.Sal);

            Emp emp3 = Emp.CreateObject();
            emp1.Sal = "5000";
            Console.WriteLine("Employee 2 Details:\n No: " + emp3.No + "\n Name: " + emp3.Name + "\n Sal: " + emp3.Sal);
            Console.ReadLine();
        }
    }
    // Example 2:
    public class Singleton
    {
        // Private static object can access only inside the Emp class.
        private static Singleton instance;

        // Private empty constructor to restrict end use to deny creating the object.
        private Singleton()
        {
        }

        // A public property to access outside of the class to create an object.
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }

    // Example 3:
    public sealed class SealedSingleton
    {
        private static readonly SealedSingleton instance = new SealedSingleton();

        private SealedSingleton()
        {
        }

        public static SealedSingleton Instance
        {
            get
            {
                return instance;
            }
        }
    }
    // Example 4:
    public sealed class MultiTrreadSingleton
    {
        private static volatile MultiTrreadSingleton instance;
        private static object syncRoot = new Object();

        private MultiTrreadSingleton()
        {
        }

        public static MultiTrreadSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new MultiTrreadSingleton();
                        }
                    }
                }
                return instance;
            }
        }
    }

}
