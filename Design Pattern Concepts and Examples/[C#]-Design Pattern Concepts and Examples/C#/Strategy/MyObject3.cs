using System;
namespace com.tp.pattern.strategy
{
    public class MyObject3 : OurMasterClass
    {
        public MyObject3()
        {
            Console.WriteLine("This is object 3.");
            Console.WriteLine("It is using Algorithm2 and Behavior 1.");
            Console.WriteLine("You can achieve same functionality by implementing Algorithm2 and Behavior1.");
            this.setAlgorithm(new Algorithm2());
            this.setBehavior(new Behavior1());
        }
    }
}
