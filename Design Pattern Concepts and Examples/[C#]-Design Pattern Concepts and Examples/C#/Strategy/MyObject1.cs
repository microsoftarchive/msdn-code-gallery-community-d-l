using System;
namespace com.tp.pattern.strategy
{
    public class MyObject1:OurMasterClass
    {
        public MyObject1()
        {
            Console.WriteLine("This is object 1.");
            Console.WriteLine("It is using Algorithm1 and Behavior 1.");
            Console.WriteLine("You can achieve same functionality by implementing Algorithm1 and Behavior1.");
            this.setAlgorithm(new Algorithm1());
            this.setBehavior(new Behavior1());
        }
    }
}
