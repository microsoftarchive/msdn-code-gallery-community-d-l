using com.tp.pattern;
using System;
using com.tp.pattern.strategy;
using com.tp.pattern.observer;
namespace DesignPatterns
{
    class Program
    {
        private static Pattern DP;
        static void Main(string[] args)
        {
            DisplayPatterns(false);
            String MainInput = Console.ReadKey().KeyChar.ToString();
            Console.WriteLine();
            while (MainInput.ToUpper() != "X")
            {
                Boolean ValidInput = false;
                switch (MainInput.ToUpper())
                {
                    case "1":
                        ValidInput = true;
                        DP = new StrategyPattern();
                        break;
                    case "2":
                        ValidInput = true;
                        DP = new ObserverPattern();
                        break;
                    case "B":
                        if(DP!=null)
                            ValidInput=true;
                        break;
                }
                if(ValidInput)
                {
                    DisplayMenu();
                    String DPInput = Console.ReadKey().KeyChar.ToString();
                    Console.WriteLine();
                    while(DPInput.ToUpper()!="X"){
                        Boolean ValidChoice = false;
                        switch (DPInput.ToUpper())
                        {
                            case "4":
                                ValidChoice = true;
                                DP.Help();
                                break;
                            case "2":
                                ValidChoice = true;
                                DP.Implementation();
                                break;
                            case "1":
                                ValidChoice = true;
                                DP.ProblemStatement();
                                break;
                            case "3":
                                ValidChoice = true;
                                DP.Process();
                                break;
                        }
                        if (ValidChoice && DPInput.ToUpper()!="X")
                        {
                            Console.ReadKey().KeyChar.ToString();
                            Console.WriteLine();
                        }
                        DisplayMenu();
                        if (!ValidChoice)
                            Console.WriteLine("Invalid Choice. Try Again.");
                        DPInput = Console.ReadKey().KeyChar.ToString();
                        Console.WriteLine();
                    }
                }
                if (DP == null)
                    DisplayPatterns(false);
                else 
                    DisplayPatterns(true);
                if (!ValidInput && MainInput.ToUpper()!="X")
                {
                    if (MainInput.ToUpper() != "X")
                        Console.WriteLine("Invalid Option.");
                }
                MainInput = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();
            }
        }

        public static void DisplayPatterns(Boolean showBack)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine(Environment.NewLine + "\tWe will learn about different design patterns here." + Environment.NewLine + Environment.NewLine);
            Console.WriteLine("\t\tSelect your Design Pattern : " + Environment.NewLine);
            Console.WriteLine("\t\t\t 1\tStrategy Pattern");
            Console.WriteLine("\t\t\t 2\tObserver Pattern");

            Console.WriteLine();
            if (showBack)
                Console.WriteLine("\t\t\t B\tBack to : "+DP.DisplayName());
            Console.WriteLine("\t\t\t X\tExit");
            Console.Write("\t\t\t");
        }

        public static void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine(Environment.NewLine + "\tChoose Action to perform :" + Environment.NewLine + Environment.NewLine);
            Console.WriteLine("\t\t"+DP.DisplayName());
            Console.WriteLine("\t\t\t1\tProblem Statement");
            Console.WriteLine("\t\t\t2\tImplementation");
            Console.WriteLine("\t\t\t3\tProcess");
            Console.WriteLine("\t\t\t4\tHelp");
            Console.WriteLine("\t\t\tX\tExit");
            Console.Write(Environment.NewLine+"\t\t\t");
        }
    }
}
