using System;
namespace com.tp.pattern.strategy
{
    public class Behavior1:Behavior
    {
        public void ApplyBehavior()
        {
            Console.WriteLine("\tBehavior1:ApplyBehavior()");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("This is one of the implementation of Behavior." + Environment.NewLine + "Think it as, if we are changing the display to Green on Black.");
            Console.WriteLine(new String('=', 80));
        }
    }
}
