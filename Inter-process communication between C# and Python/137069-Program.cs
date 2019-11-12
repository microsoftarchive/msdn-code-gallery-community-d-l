using System;
using System.IO;
using System.Diagnostics;

namespace CallPython
{
    /// <summary>
    /// Used to show simple C# and Python interprocess communication
    /// Author      : Ozcan ILIKHAN
    /// Created     : 02/26/2015
    /// Last Update : 04/30/2015
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // full path of python interpreter
            string python = @"C:\Continuum\Anaconda\python.exe";
            
            // python app to call
            string myPythonApp = "sum.py";

            // dummy parameters to send Python script
            int x = 2;
            int y = 5;

            // Create new process start info
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(python);

            // make sure we can read the output from stdout
            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardOutput = true;

            // start python app with 3 arguments 
            // 1st arguments is pointer to itself, 2nd and 3rd are actual arguments we want to send
            myProcessStartInfo.Arguments = myPythonApp + " " + x + " " + y;

            Process myProcess = new Process();
            // assign start information to the process
            myProcess.StartInfo = myProcessStartInfo;

            Console.WriteLine("Calling Python script with arguments {0} and {1}", x,y);
            // start the process
            myProcess.Start();

            // Read the standard output of the app we called. 
            // in order to avoid deadlock we will read output first and then wait for process terminate:
            StreamReader myStreamReader = myProcess.StandardOutput;
            string myString = myStreamReader.ReadLine();
            
            /*if you need to read multiple lines, you might use:
                string myString = myStreamReader.ReadToEnd() */          

            // wait exit signal from the app we called and then close it.
            myProcess.WaitForExit();
            myProcess.Close();

            // write the output we got from python app
            Console.WriteLine("Value received from script: " + myString);
            
        }
    }
}
