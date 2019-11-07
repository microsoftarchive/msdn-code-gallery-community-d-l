using System;
namespace com.tp.pattern.strategy
{
    public class MyObject4 : OurMasterClass
    {
        public MyObject4()
        {
            Console.WriteLine("This is object 4.");
            Console.WriteLine("It is using Algorithm2 and Behavior 2.");
            Console.WriteLine("You can achieve same functionality by implementing Algorithm2 and Behavior2.");
            this.setAlgorithm(new Algorithm2());
            this.setBehavior(new Behavior2());
        }
    }
}
