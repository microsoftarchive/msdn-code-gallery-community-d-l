// ***********************************************************************
// Assembly         : Server
// Author           : SH
// Created          : 07-06-2014
//
// Last Modified By : SH
// Last Modified On : 07-06-2014
// ***********************************************************************
// <copyright file="Program.cs" author="Stefan Heesch">
//     Apache 2.0 license : http://www.apache.org/licenses/LICENSE-2.0.html.
// </copyright>
// <summary>Simple HL7 version 2.x server, sending auto ACKs </summary>
// ***********************************************************************
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using HL7Messaging;


namespace Server
{
    class Program
    {
        private static readonly byte[] Localhost = {127, 0, 0, 1};
        private const int Port = 8888;


        static void Main(string[] args)
        {
            var address = new IPAddress( Localhost );
            var endPoint = new IPEndPoint(address, Port);

            var listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listener.Bind(endPoint);
                listener.Listen(3);

                String data = "";

                while (true)
                {
                    Console.WriteLine("Listening on sport {0}", endPoint);

                    
                    byte[] buffer = new byte[4096];
                    
                    // handle incoming connection ...
                    var handler = listener.Accept();
                    Console.WriteLine("Handling incoming connection ...");
                    while (true)
                    {
                        int count = handler.Receive(buffer);
                        data += Encoding.UTF8.GetString(buffer, 0, count);

                        // Find start of MLLP frame, a VT character ...
                        int start = data.IndexOf((char) 0x0B);
                        if (start >= 0)
                        {
                            // Now look for the end of the frame, a FS character
                            int end = data.IndexOf((char) 0x1C);
                            if (end > start)
                            {
                                string temp = data.Substring(start + 1, end - start);

                                // handle message
                                string response = HandleMessage(temp);

                                // Send response
                                handler.Send(Encoding.UTF8.GetBytes(response));
                                break;
                            }
                        }
                    }

                    // close connection
                    handler.Shutdown( SocketShutdown.Both);
                    handler.Close();

                    Console.WriteLine("Connection closed.");

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: {0}", e.Message);
            }
            Console.WriteLine("Terminating - press ENTER");
            Console.ReadLine();
        }


        private static string HandleMessage(string data)
        {
            Console.WriteLine("Received message");

            var msg = new Message();
            msg.Parse(data);

            Console.WriteLine("Parsed message     : {0}", msg.MessageType() );
            Console.WriteLine("Message timestamp  : {0}", msg.MessageDateTime() );
            Console.WriteLine("Message control id : {0}", msg.MessageControlId());


            // *********************************************************************
            // Here you could do something usefull with the received message ;-)
            // *********************************************************************


            // todo 


            // Create a response message
            //
            var response = new Message();

            var msh = new Segment("MSH");
            msh.Field(2, "^~\\&");
            msh.Field(7, DateTime.Now.ToString("yyyyMMddhhmmsszzz"));
            msh.Field(9, "ACK");
            msh.Field(10, Guid.NewGuid().ToString() );
            msh.Field(11, "P");
            msh.Field(12, "2.5.1");
            response.Add(msh);

            var msa = new Segment("MSA");
            msa.Field(1, "AA");
            msa.Field(2, msg.MessageControlId());
            response.Add(msa);


            // Put response message into an MLLP frame ( <VT> data <FS><CR> )
            //
            var frame = new StringBuilder();
            frame.Append((char) 0x0B);
            frame.Append(response.Serialize());
            frame.Append( (char) 0x1C);
            frame.Append( (char) 0x0D);

            return frame.ToString();
        }
    }
}
