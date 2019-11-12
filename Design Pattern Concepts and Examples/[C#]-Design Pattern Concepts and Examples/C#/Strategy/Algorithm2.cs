using System;
namespace com.tp.pattern.strategy
{
    public class Algorithm2 : Algorithm
    {
        public void SomeProcess()
        {
            Console.WriteLine("\tAlgorithm2:SomeProcess()");
            Console.WriteLine("This is one of the implementation of Algorithm." + Environment.NewLine + "Think it as, if we are sorting the array/data using BUBBLE SORT.");
            Console.WriteLine(new String('=', 80));
        }
    }
}
