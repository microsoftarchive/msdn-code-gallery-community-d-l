//-----------------------------------------------------------------------------
// File: Program.h
//
// Desc: Dining Philosophers sample.
//		 
//		 Demonstrates how to use Monitor object (lock) to protect critical section.
//		 
//		 Scenario is such that there are 5 philosophers and 5 tools on each side of a philosopher.
//		 Each philosopher can only take one tool on the left and one on the right.
//		 One of the philosophers must wait for a tool to become available because whoever grabs
//		 a tool will hold it until he eats and puts the tool back on the table.
//		 
//		 Application of the pattern could be transferring money from account A to account B.
//		 Important here is to pass locking objects always in the same (increasing) order.
//		 If the order is mixed you would encounter random deadlocks at runtime.
//
//-----------------------------------------------------------------------------

#include <algorithm>
#include <chrono>
#include <iostream>
#include <memory>
#include <mutex>
#include <string>
#include <thread>
#include <vector>

using std::cout;
using std::endl;
using std::adopt_lock;
using std::for_each;
using std::lock;
using std::mem_fn;
using std::move;
using std::to_string;
using std::exception;
using std::lock_guard;
using std::mutex;
using std::string;
using std::thread;
using std::unique_ptr;
using std::vector;

class Chopstick
{
public:
	Chopstick(){};
	mutex m;
};

int main()
{
	auto eat = [](Chopstick* leftChopstick, Chopstick* rightChopstick, int philosopherNumber, int leftChopstickNumber, int rightChopstickNumber)
	{
		if (leftChopstick == rightChopstick)
			throw exception("Left and right chopsticks should not be the same!");

		lock(leftChopstick->m, rightChopstick->m);				// ensures there are no deadlocks

		lock_guard<mutex> a(leftChopstick->m, adopt_lock);
		string sl = "   Philosopher " + to_string(philosopherNumber) + " picked " + to_string(leftChopstickNumber) + " chopstick.\n";
		cout << sl.c_str();

		lock_guard<mutex> b(rightChopstick->m, adopt_lock);					
		string sr = "   Philosopher " + to_string(philosopherNumber) + " picked " + to_string(rightChopstickNumber) + " chopstick.\n";
		cout << sr.c_str();

		string pe = "Philosopher " + to_string(philosopherNumber) + " eats.\n";
		cout << pe;

		//std::chrono::milliseconds timeout(500);
		//std::this_thread::sleep_for(timeout);
	};

	static const int numPhilosophers = 5;

    // 5 utencils on the left and right of each philosopher. Use them to acquire locks.
	vector< unique_ptr<Chopstick> > chopsticks(numPhilosophers);

	for (int i = 0; i < numPhilosophers; ++i)
	{
		auto c1 = unique_ptr<Chopstick>(new Chopstick());
		chopsticks[i] = move(c1);
	}

	// This is where we create philosophers, each of 5 tasks represents one philosopher.
	vector<thread> tasks(numPhilosophers);

	tasks[0] = thread(eat, 
			chopsticks[0].get(),						// left chopstick:  #1
			chopsticks[numPhilosophers - 1].get(),		// right chopstick: #5
			0 + 1,										// philosopher number
			1,
			numPhilosophers
		);

	for (int i = 1; i < numPhilosophers; ++i)
	{
		tasks[i] = (thread(eat, 
				chopsticks[i - 1].get(),				// left chopstick
				chopsticks[i].get(),					// right chopstick
				i + 1,									// philosopher number
				i,
				i + 1
				)
			);
	}

	// May eat!
	for_each(tasks.begin(), tasks.end(), mem_fn(&thread::join));

	return 0;
}
/*
   Philosopher 1 picked 1 chopstick.
   Philosopher 3 picked 2 chopstick.
   Philosopher 1 picked 5 chopstick.
   Philosopher 3 picked 3 chopstick.
Philosopher 1 eats.
Philosopher 3 eats.
   Philosopher 5 picked 4 chopstick.
   Philosopher 2 picked 1 chopstick.
   Philosopher 2 picked 2 chopstick.
   Philosopher 5 picked 5 chopstick.
Philosopher 2 eats.
Philosopher 5 eats.
   Philosopher 4 picked 3 chopstick.
   Philosopher 4 picked 4 chopstick.
Philosopher 4 eats.
*/