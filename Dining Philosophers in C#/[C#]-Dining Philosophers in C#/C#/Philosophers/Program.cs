/*
 * Dining Philosophers sample.
 * 
 * Demonstrates how to use Monitor object (lock) to protect critical section.
 * 
 * Scenario is such that there are 5 philosophers and 5 tools on each side of a philosopher.
 * Each philosopher can only take one tool on the left and one on the right.
 * One of the philosophers must wait for a tool to become available because whoever grabs
 * a tool will hold it until he eats and puts the tool back on the table.
 * 
 * Application of the pattern could be transferring money from account A to account B.
 * Important here is to pass locking objects always in the same (increasing) order.
 * If the order is mixed you would encounter random deadlocks at runtime.
 * 
 */
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiningPhilosophers
{
    /// <summary>
    /// Philoshoper class. 
    /// Represents dinig philosophers.
    /// </summary>
    public sealed class Philoshoper
    {
        /// <summary>
        /// That's where philosophers compete for the available utencils on their left and right in order to eat.
        /// </summary>
        /// <param name="leftChopstick">Utencil on the left of the philosopher.</param>
        /// <param name="rightChopstick">Utencil on the right of the philosopher.</param>
        /// <param name="philosopherNumber">Philosopher number for displaying on the screen.</param>
        /// <param name="leftChopstickNumber">Left utencil number number for displaying on the screen.</param>
        /// <param name="rightChopstickNumber">Right utencil number number for displaying on the screen.</param>
        static public void Eat(object leftChopstick, object rightChopstick, int philosopherNumber, int leftChopstickNumber, int rightChopstickNumber)
        {
            lock (leftChopstick)                // Grab utencil on the left
            {
                Console.WriteLine("   Philosopher {0} picked {1} chopstick.", philosopherNumber, leftChopstickNumber);

                lock (rightChopstick)           // Grab utencil on the right
                {
                    // Eat here
                    Console.WriteLine("   Philosopher {0} picked {1} chopstick.", philosopherNumber, rightChopstickNumber);
                    Console.WriteLine("Philosopher {0} eats.", philosopherNumber);

                    //Task.Delay(5000);
                }

                Console.WriteLine("   Philosopher {0} released {1} chopstick.", philosopherNumber, rightChopstickNumber);
            }

            Console.WriteLine("   Philosopher {0} released {1} chopstick.", philosopherNumber, leftChopstickNumber);
        }
    }

    /// <summary>
    /// Main entry into the sample
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            const int numPhilosophers = 5;

            // 5 utencils on the left and right of each philosopher. Use them to acquire locks.
            var chopsticks = new Dictionary<int, object>(numPhilosophers);

            for (int i = 0; i < numPhilosophers; ++i)
            {
                chopsticks.Add(i, new object());
            }

            // This is where we create philosophers, each of 5 tasks represents one philosopher.
            Task[] tasks = new Task[numPhilosophers];

            tasks[0] = new Task(() => Philoshoper.Eat(chopsticks[0], chopsticks[numPhilosophers - 1], 0 + 1, 1, numPhilosophers));

            for (int i = 1; i < numPhilosophers; ++i)
            {
                int ix = i;
                tasks[ix] = new Task(() => Philoshoper.Eat(chopsticks[ix - 1], chopsticks[ix], ix + 1, ix, ix + 1));
            }

            // May eat!
            Parallel.ForEach(tasks, t =>
            {
                t.Start();
            });

            // Wait for all philosophers to finish their dining
            Task.WaitAll(tasks);

            //Console.WriteLine("\nPress any key to exit.");
            //Console.ReadKey(false);
        }
    }
}

/*
 * Sample output:
 * 
   Philosopher 2 picked 1 chopstick.
   Philosopher 4 picked 3 chopstick.
   Philosopher 3 picked 2 chopstick.
   Philosopher 4 picked 4 chopstick.
Philosopher 4 eats.
   Philosopher 4 released 4 chopstick.
   Philosopher 4 released 3 chopstick.
   Philosopher 3 picked 3 chopstick.
Philosopher 3 eats.
   Philosopher 3 released 3 chopstick.
   Philosopher 3 released 2 chopstick.
   Philosopher 5 picked 4 chopstick.
   Philosopher 5 picked 5 chopstick.
Philosopher 5 eats.
   Philosopher 5 released 5 chopstick.
   Philosopher 5 released 4 chopstick.
   Philosopher 2 picked 2 chopstick.
Philosopher 2 eats.
   Philosopher 2 released 2 chopstick.
   Philosopher 2 released 1 chopstick.
   Philosopher 1 picked 1 chopstick.
   Philosopher 1 picked 5 chopstick.
Philosopher 1 eats.
   Philosopher 1 released 5 chopstick.
   Philosopher 1 released 1 chopstick.
 * 
 * 
 * 
   Philosopher 5 picked 4 chopstick.
   Philosopher 5 picked 5 chopstick.
Philosopher 5 eats.
   Philosopher 5 released 5 chopstick.
   Philosopher 1 picked 1 chopstick.
   Philosopher 3 picked 2 chopstick.
   Philosopher 3 picked 3 chopstick.
Philosopher 3 eats.
   Philosopher 3 released 3 chopstick.
   Philosopher 3 released 2 chopstick.
   Philosopher 4 picked 3 chopstick.
   Philosopher 4 picked 4 chopstick.
Philosopher 4 eats.
   Philosopher 4 released 4 chopstick.
   Philosopher 4 released 3 chopstick.
   Philosopher 5 released 4 chopstick.
   Philosopher 1 picked 5 chopstick.
Philosopher 1 eats.
   Philosopher 1 released 5 chopstick.
   Philosopher 1 released 1 chopstick.
   Philosopher 2 picked 1 chopstick.
   Philosopher 2 picked 2 chopstick.
Philosopher 2 eats.
   Philosopher 2 released 2 chopstick.
   Philosopher 2 released 1 chopstick.
*/
