using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.MemoryMappedFiles;
using System.IO;
using MemoryMappedFileManager;

namespace MemoryMappedFileManagerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MemoryMappedFileCommunicator communicator = new MemoryMappedFileCommunicator("MemoryMappedShare", 4096);

            // This process reads data that begins in the position 2000 and writes starting from the position 0.
            communicator.ReadPosition = 2000;
            communicator.WritePosition = 0;

            // Creates an handler for the event that is raised when data are available in the
            // MemoryMappedFile.
            communicator.DataReceived += new EventHandler<MemoryMappedDataReceivedEventArgs>(communicator_DataReceived);
            communicator.StartReader();

            bool quit = false;
            Console.WriteLine("Write messages and press ENTER to send (empty to terminate): ");
            while (!quit)
            {
                string message = Console.ReadLine();
                if (!string.IsNullOrEmpty(message))
                {
                    var data = System.Text.Encoding.UTF8.GetBytes(message);
                    communicator.Write(data);
                }
                else
                {
                    quit = true;
                }
            }

            communicator.Dispose();
            communicator = null;
        }

        private static void communicator_DataReceived(object sender, MemoryMappedDataReceivedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(System.Text.Encoding.UTF8.GetString(e.Data));
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
