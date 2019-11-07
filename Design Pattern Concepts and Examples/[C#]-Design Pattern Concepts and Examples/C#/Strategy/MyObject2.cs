using System;
namespace com.tp.pattern.strategy
{
    public class MyObject2 : OurMasterClass
    {
        public MyObject2()
        {
            Console.WriteLine("This is object 2.");
            Console.WriteLine("It is using Algorithm1 and Behavior 2.");
            Console.WriteLine("You can achieve same functionality by implementing Algorithm1 and Behavior2.");
            this.setAlgorithm(new Algorithm1());
            this.setBehavior(new Behavior2());
        }
    }
}
