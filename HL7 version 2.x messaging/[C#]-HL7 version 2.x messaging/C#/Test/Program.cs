// ***********************************************************************
// Assembly         : Test
// Author           : SH
// Created          : 07-06-2014
//
// Last Modified By : SH
// Last Modified On : 07-06-2014
// ***********************************************************************
// <copyright file="Program.cs" author="Stefan Heesch">
//     Apache 2.0 license : http://www.apache.org/licenses/LICENSE-2.0.html.
// </copyright>
// <summary>Playing around with basic HL7 message support library</summary>
// ***********************************************************************
using System;
using System.IO;
using HL7Messaging;

namespace Test
{
    class Program
    {
        private static void Main(string[] args)
        {

            string data = File.ReadAllText("demo.hl7");

            var msg = new Message();
            msg.Parse(data);

            Console.WriteLine("Parsed Message     : {0}", msg.MessageType());
            Console.WriteLine("Message Time       : {0}" , msg.MessageDateTime());
            Console.WriteLine("Message Control ID : {0}", msg.MessageControlId());
            Console.WriteLine();
            Console.WriteLine(msg.Serialize());

            Console.ReadLine();

            msg = new Message();

            var msh = new Segment();
            msh.Field(0, "MSH");
            msh.Field(8, "ADT^A01");

            msg.Add(msh);

            var pid = new Segment();
            pid.Field(0, "PID");
            pid.Field(1, "1");
            msg.Add(pid);

            pid = new Segment();
            pid.Field(0, "PID");
            pid.Field(1, "2");
            msg.Add(pid);


            Console.WriteLine(msg.Serialize());
            Console.ReadLine();


            // get first PID segment
            pid = msg.FindSegment("PID");

            // find the PID segment that follows the first one
            var second = msg.FindNextSegment("PID", pid);

        }
    }
}
