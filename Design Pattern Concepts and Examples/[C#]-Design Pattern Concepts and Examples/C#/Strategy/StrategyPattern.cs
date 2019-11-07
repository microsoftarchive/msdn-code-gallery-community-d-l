using System;
namespace com.tp.pattern.strategy
{
    public class StrategyPattern:Pattern
    {

        public void ProblemStatement()
        {
            Console.WriteLine("We have some behaviors(say verb) of an object(say noun). We can have multiple objects derived from object, and they can behave in their own way or some may behave same as well."+Environment.NewLine+Environment.NewLine+"Since the behavior is must for them so we can create interface for the behavior and implement them in individual type. But it will lead to code duplicacy. So how we do it.");
        }

        public void Help()
        {
            Console.WriteLine("Algorithm\tIt is an interface for a behavior of sorting.");
            Console.WriteLine("Behavior\tIt is yet another interface for a behavior of display settings.");
            Console.WriteLine();
            Console.WriteLine("Algorithm1\tImplements Algorithm. Sorting using MERGE SORT.");
            Console.WriteLine("Algorithm2\tImplements Algorithm. Sorting using BUBBLE SORT.");
            Console.WriteLine();
            Console.WriteLine("Behavior1\tDisplay Setting with GREEN on BLACK.");
            Console.WriteLine("Behavior2\tDisplay Setting with RED on WHITE.");
            Console.WriteLine();
            Console.WriteLine("OurMasterClass\tAn abstract class(our noun) for which we have created behaviors.");
            Console.WriteLine("MyObject1\tOurMasterClass extended with Algorithm1 and Behavior1.");
            Console.WriteLine("MyObject2\tOurMasterClass extended with Algorithm1 and Behavior2.");
            Console.WriteLine("MyObject3\tOurMasterClass extended with Algorithm2 and Behavior1.");
            Console.WriteLine("MyObject4\tOurMasterClass extended with Algorithm2 and Behavior2.");
            Console.WriteLine();
        }

        public void Process()
        {
            Console.WriteLine("Creating 4 different objects.");

            Console.WriteLine();
            OurMasterClass C1 = new MyObject1();
            Console.WriteLine("C1 Created.");
            Console.WriteLine();
            OurMasterClass C2 = new MyObject2();
            Console.WriteLine("C2 Created.");
            Console.WriteLine();
            OurMasterClass C3 = new MyObject3();
            Console.WriteLine("C3 Created.");
            Console.WriteLine();
            OurMasterClass C4 = new MyObject4();
            Console.WriteLine("C4 Created.");
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine("Calling PerformAlgorithm on C1.");
            C1.PerformAlgorithm();
            Console.WriteLine("Calling PerformAlgorithm on C2.");
            C2.PerformAlgorithm();
            Console.WriteLine("Calling PerformAlgorithm on C3.");
            C3.PerformAlgorithm();
            Console.WriteLine("Calling PerformAlgorithm on C4.");
            C4.PerformAlgorithm();

            Console.ReadKey();
            Console.WriteLine("Calling ChangeBehavior on C1.");
            C1.ChangeBehavior();
            Console.ReadKey();
            Console.WriteLine("Calling ChangeBehavior on C2.");
            C2.ChangeBehavior();
            Console.ReadKey();
            Console.WriteLine("Calling ChangeBehavior on C3.");
            C3.ChangeBehavior();
            Console.ReadKey();
            Console.WriteLine("Calling ChangeBehavior on C4.");
            C4.ChangeBehavior();
            Console.ReadKey();

            Console.WriteLine("Now changing Algorithm of C1 at runtime.");
            C1.setAlgorithm(new Algorithm2());
            Console.WriteLine("Calling PerformAlgorithm on C1.");
            C1.PerformAlgorithm();

            Console.WriteLine("Now changing Behavior of C2 at runtime.");
            C2.setBehavior(new Behavior1());
            Console.WriteLine("Calling ChangeBehavior on C2.");
            C2.ChangeBehavior();
        }

        public void Implementation()
        {
            Console.WriteLine("We create interface for Behaviors/Verb and create individual implementation in classes. So we have one class for each kind of Behavior implementation. We then have behavior interfaces as instance variable in the main class and their value set in derived classes."+Environment.NewLine+Environment.NewLine+"This way we have behavior implementation for individual object and without any code duplicacy. Also we can add more implementation or change an object's behavior in future without effecting existing code.");
        }

        public String DisplayName()
        {
            return "Strategy Pattern";
        }
    }
}
