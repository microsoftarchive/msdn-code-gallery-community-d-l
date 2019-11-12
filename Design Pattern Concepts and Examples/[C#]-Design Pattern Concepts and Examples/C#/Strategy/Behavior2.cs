using System;
namespace com.tp.pattern.strategy
{
    public class Behavior2 : Behavior
    {
        public void ApplyBehavior()
        {
            Console.WriteLine("\tBehavior2:ApplyBehavior()");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("This is one of the implementation of Behavior." + Environment.NewLine + "Think it as, if we are changing the display to Red on White.");
            Console.WriteLine(new String('=', 80));
        }
    }
}
