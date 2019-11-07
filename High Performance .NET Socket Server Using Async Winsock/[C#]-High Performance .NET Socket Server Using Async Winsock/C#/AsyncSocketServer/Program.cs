using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace AsyncSocketServer
{
    /// <summary>
    /// class OSAsyncEventStack
    /// This is a very standard stack implementation.
    /// This one is set up to stack asynchronous socket connections.
    /// It has only two operations: a push onto the stack, and a pop off of it.
    /// </summary>
    sealed class OSAsyncEventStack
    {
        private Stack<SocketAsyncEventArgs> socketstack;

        // This constructor needs to know how many items it will be storing max
        public OSAsyncEventStack(Int32 maxCapacity)
        {
            socketstack = new Stack<SocketAsyncEventArgs>(maxCapacity);
        }

        // Pop an item off of the top of the stack
        public SocketAsyncEventArgs Pop()
        {
            //We are locking the stack, but we could probably use a ConcurrentStack if
            // we wanted to be fancy
            lock (socketstack)
            {
                if (socketstack.Count > 0)
                {
                    return socketstack.Pop();
                }
                else
                {
                    return null;
                }
            }
        }

        // Push an item onto the top of the stack
        public void Push(SocketAsyncEventArgs item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Cannot add null object to socket stack");
            }

            lock (socketstack)
            {
                socketstack.Push(item);
            }
        }
    }


    /// <summary>
    /// class OSUserToken : IDisposable
    /// This class represents the instantiated read socket on the server side.
    /// It is instantiated when a server listener socket accepts a connection.
    /// </summary>
    sealed class OSUserToken : IDisposable
    {
        // This is a ref copy of the socket that owns this token
        private Socket ownersocket;

        // this stringbuilder is used to accumulate data off of the readsocket
        private StringBuilder stringbuilder;

        // This stores the total bytes accumulated so far in the stringbuilder
        private Int32 totalbytecount;

        // We are holding an exception string in here, but not doing anything with it right now.
        public String LastError;

        // The read socket that creates this object sends a copy of its "parent" accept socket in as a reference
        // We also take in a max buffer size for the data to be read off of the read socket
        public OSUserToken(Socket readSocket, Int32 bufferSize)
        {
            ownersocket = readSocket;
            stringbuilder = new StringBuilder(bufferSize);
        }

        // This allows us to refer to the socket that created this token's read socket
        public Socket OwnerSocket
        {
            get
            {
                return ownersocket;
            }
        }

        
        // Do something with the received data, then reset the token for use by another connection.
        // This is called when all of the data have been received for a read socket.
        public void ProcessData(SocketAsyncEventArgs args)
        {
            // Get the last message received from the client, which has been stored in the stringbuilder.
            String received = stringbuilder.ToString();

            //TODO Use message received to perform a specific operation.
            Console.WriteLine("Received: \"{0}\". The server has read {1} bytes.", received, received.Length);

            //TODO: Load up a send buffer to send an ack back to the calling client
            //Byte[] sendBuffer = Encoding.ASCII.GetBytes(received);
            //args.SetBuffer(sendBuffer, 0, sendBuffer.Length);

            // Clear StringBuffer, so it can receive more data from the client.
            stringbuilder.Length = 0;
            totalbytecount = 0;
        }


        // This method gets the data out of the read socket and adds it to the accumulator string builder
        public bool ReadSocketData(SocketAsyncEventArgs readSocket)
        {
            Int32 bytecount = readSocket.BytesTransferred;

            if ((totalbytecount + bytecount) > stringbuilder.Capacity)
            {
                LastError = "Receive Buffer cannot hold the entire message for this connection.";
                return false;
            }
            else
            {
                stringbuilder.Append(Encoding.ASCII.GetString(readSocket.Buffer, readSocket.Offset, bytecount));
                totalbytecount += bytecount;
                return true;
            }
        }

        // This is a standard IDisposable method
        // In this case, disposing of this token closes the accept socket
        public void Dispose()
        {
            try
            {
                ownersocket.Shutdown(SocketShutdown.Both);
            }
            catch
            {
                //Nothing to do here, connection is closed already
            }
            finally
            {
                ownersocket.Close();
            }
        }
    }


    /// <summary>
    /// class OSCore
    /// This is a base class that is used by both clients and servers.
    /// It contains the plumbing to set up a socket connection.
    /// </summary>
    class OSCore
    {
        // This is just some utilities that we use all over
        protected OSUtil os_util;

        // these are the defaults if the user does not provide any parameters
        protected const string DEFAULT_SERVER = "localhost";
        protected const int DEFAULT_PORT = 804;
  
        //  We default to a 256 Byte buffer size
        protected const int DEFAULT_BUFFER_SIZE = 256;

        // This is the connection socket and endpoint information
        protected Socket connectionsocket;
        protected IPEndPoint connectionendpoint;

        // This is some error handling stuff that is not well implemented
        protected string lasterror;
        protected bool exceptionthrown;

        // This is the current buffer size for receive and send
        protected int buffersize;

        
        // We only instantiate the utility class here.
        // We could probably make it static and avoid this.
        public OSCore()
        {
            os_util = new OSUtil();
        }

        // An IPEndPoint contains all of the information about a server or client
        // machine that a socket needs.  Here we create one from information
        // that we send in as parameters
        public IPEndPoint CreateIPEndPoint(string servername, int portnumber)
        {
            try
            {
                // We get the IP address and stuff from DNS (Domain Name Services)
                // I think you can also pass in an IP address, but I would not because
                // that would not be extensible to IPV6 later
                IPHostEntry hostInfo = Dns.GetHostEntry(servername);
                IPAddress serverAddr = hostInfo.AddressList[0];
                return new IPEndPoint(serverAddr, portnumber);
            }
            catch (Exception ex)
            {
                exceptionthrown = true;
                lasterror = ex.ToString();
                return null;
            }
        }


        // This method peels apart the command string to create either a client or server socket,
        // which is not great because it means the method has to know the semantics of the command
        // that is passed to it.  So this needs to be fixed.
        protected bool CreateSocket(string cmdstring)
        {
            exceptionthrown = false;

            if (!string.IsNullOrEmpty(cmdstring))
            {
                // Here is the utility function that actually parses the command string.
                List<string> parameters = os_util.ParseParams(cmdstring);

                // Based on the number of parameters in the command string, we create an IPEndPoint
                // with the appropriate values for server and port number.
                // Implicit in here is the fact that a server always creates on localhost, so the
                // startserver command will contain only one parameter (port number), or none.
                // Like I said, this needs to be refactored to be more generic
                if (parameters.Count < 1)
                {
                    connectionendpoint = CreateIPEndPoint(DEFAULT_SERVER, DEFAULT_PORT);
                }
                else if (parameters.Count == 1)
                {
                    connectionendpoint = CreateIPEndPoint(DEFAULT_SERVER, Convert.ToInt32(parameters[0]));
                }
                else
                {
                    connectionendpoint = CreateIPEndPoint(parameters[0], Convert.ToInt32(parameters[1]));
                }
            }
            else
            {
                connectionendpoint = CreateIPEndPoint(DEFAULT_SERVER, DEFAULT_PORT);
            }

            // If we get here, we try to create the socket using the IPEndpoint information.
            // We are defaulting here to TCP Stream sockets, but you could change this with more parameters.
            if (!exceptionthrown)
            {
                try
                {
                    connectionsocket = new Socket(connectionendpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                }
                catch(Exception ex)
                {
                    exceptionthrown = true;
                    lasterror = ex.ToString();
                    return false;
                }
            }
            return true;
        }

        // This method is a lame way for external classes to get the last error message that was posted
        // from this class.  It is a poor man's exception handler.  Don't do this in production code.
        // Use proper exception handling.
        public string GetLastError()
        {
            return lasterror;
        }
    }


    /// <summary>
    /// class OSServer : OSCore
    /// This is the server class that is derived from OSCore.
    /// It creates a server that listens for client connections, then receives
    /// text data from those clients and writes it to the console screen
    /// </summary>
    class OSServer : OSCore
    {
        // We limit this server client connections for test purposes
        protected const int DEFAULT_MAX_CONNECTIONS = 4;

        // We use a Mutex to block the listener thread so that limited client connections are active
        // on the server.  If you stop the server, the mutex is released. 
        private static Mutex mutex;

        // Here is where we track the number of client connections
        protected int numconnections;

        // Here is where we track the totalbytes read by the server
        protected int totalbytesread;

        // Here is our stack of available accept sockets
        protected OSAsyncEventStack socketpool;


        // Default constructor
        public OSServer()
        {
            exceptionthrown = false;

            // First we set up our mutex and semaphore
            mutex = new Mutex();
            numconnections = 0;

            // Then we create our stack of read sockets
            socketpool = new OSAsyncEventStack(DEFAULT_MAX_CONNECTIONS);

            // Now we create enough read sockets to service the maximum number of clients
            // that we will allow on the server
            // We also assign the event handler for IO Completed to each socket as we create it
            // and set up its buffer to the right size.
            // Then we push it onto our stack to wait for a client connection
            for (Int32 i = 0; i < DEFAULT_MAX_CONNECTIONS; i++)
            {
                SocketAsyncEventArgs item = new SocketAsyncEventArgs();
                item.Completed += new EventHandler<SocketAsyncEventArgs>(OnIOCompleted);
                item.SetBuffer(new Byte[DEFAULT_BUFFER_SIZE], 0, DEFAULT_BUFFER_SIZE);
                socketpool.Push(item);
            }
        }


        // This method is called when there is no more data to read from a connected client
        private void OnIOCompleted(object sender, SocketAsyncEventArgs e)
        {
            // Determine which type of operation just completed and call the associated handler.
            // We are only processing receives right now on this server.
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Receive:
                    this.ProcessReceive(e);
                    break;
                default:
                    throw new ArgumentException("The last operation completed on the socket was not a receive");
            }
        }


        // We call this method once to start the server if it is not started
        public bool Start(string cmdstring)
        {
            exceptionthrown = false;

            // First create a generic socket
            if(CreateSocket(cmdstring))
            {
                try
                {
                    // Now make it a listener socket at the IP address and port that we specified
                    connectionsocket.Bind(connectionendpoint);

                    // Now start listening on the listener socket and wait for asynchronous client connections
                    connectionsocket.Listen(DEFAULT_MAX_CONNECTIONS);
                    StartAcceptAsync(null);
                    mutex.WaitOne();
                    return true;
                }
                catch (Exception ex)
                {
                    exceptionthrown = true;
                    lasterror = ex.ToString();
                    return false;
                }
            }
            else
            {
                lasterror = "Unknown Error in Server Start.";
                return false;
            }
        }

        // This method is called once to stop the server if it is started.
        // We could check for the open socket here
        // to stop some exception noise.
        public void Stop()
        {
            connectionsocket.Close();
            mutex.ReleaseMutex();
        }

 
        // This method implements the asynchronous loop of events
        // that accepts incoming client connections
        public void StartAcceptAsync(SocketAsyncEventArgs acceptEventArg)
        {
            // If there is not an accept socket, create it
            // If there is, reuse it
            if (acceptEventArg == null)
            {
                acceptEventArg = new SocketAsyncEventArgs();
                acceptEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(OnAcceptCompleted);
            }
            else
            {
                acceptEventArg.AcceptSocket = null;
            }

            // this will return true if there is a connection
            // waiting to be processed (IO Pending) 
            bool acceptpending = connectionsocket.AcceptAsync(acceptEventArg);

            // If not, we can go ahead and process the accept.
            // Otherwise, the Completed event we tacked onto the accept socket will do it when it completes
            if (!acceptpending)
            {
                // Process the accept event
                ProcessAccept(acceptEventArg);
            }
        }


        // This method is triggered when the accept socket completes an operation async
        // In the case of our accept socket, we are looking for a client connection to complete
        private void OnAcceptCompleted(object sender, SocketAsyncEventArgs AsyncEventArgs)
        {
            ProcessAccept(AsyncEventArgs);
        }


        // This method is used to process the accept socket connection
        private void ProcessAccept(SocketAsyncEventArgs AsyncEventArgs)
        {
            // First we get the accept socket from the passed in arguments
            Socket acceptsocket = AsyncEventArgs.AcceptSocket;

            // If the accept socket is connected to a client we will process it
            // otherwise nothing happens
            if (acceptsocket.Connected)
            {
                try
                {
                    // Go get a read socket out of the read socket stack
                    SocketAsyncEventArgs readsocket = socketpool.Pop();
  
                    // If we get a socket, use it, otherwise all the sockets in the stack are used up
                    // and we can't accept anymore connections until one frees up
                    if (readsocket != null)
                    {
                        // Create our user object and put the accept socket into it to use later
                        readsocket.UserToken = new OSUserToken(acceptsocket, DEFAULT_BUFFER_SIZE);
                        
                        // We are not using this right now, but it is useful for counting connections
                        Interlocked.Increment(ref numconnections);

                        // Start a receive request and immediately check to see if the receive is already complete
                        // Otherwise OnIOCompleted will get called when the receive is complete
                        bool IOPending = acceptsocket.ReceiveAsync(readsocket);
                        if (!IOPending)
                        {
                            ProcessReceive(readsocket);
                        }
                    }
                    else
                    {
                        acceptsocket.Close();
                        Console.WriteLine("Client connection refused because the maximum number of client connections allowed on the server has been reached.");
                        var ex = new Exception("No more connections can be accepted on the server.");
                        throw ex;
                    }
                }
                catch(Exception ex)
                {
                    exceptionthrown = true;
                    lasterror = ex.ToString();
                }

                // Start the process again to wait for the next connection
                StartAcceptAsync(AsyncEventArgs);
            }
        }


        // This method processes the read socket once it has a transaction
        private void ProcessReceive(SocketAsyncEventArgs readSocket)
        {
            // if BytesTransferred is 0, then the remote end closed the connection
            if (readSocket.BytesTransferred > 0)
            {
                //SocketError.Success indicates that the last operation on the underlying socket succeeded
                if (readSocket.SocketError == SocketError.Success)
                {
                    OSUserToken token = readSocket.UserToken as OSUserToken;
                    if (token.ReadSocketData(readSocket))
                    {
                        Socket readsocket = token.OwnerSocket;

                        // If the read socket is empty, we can do something with the data that we accumulated
                        // from all of the previous read requests on this socket
                        if (readsocket.Available == 0)
                        {
                            token.ProcessData(readSocket);
                        }

                        // Start another receive request and immediately check to see if the receive is already complete
                        // Otherwise OnIOCompleted will get called when the receive is complete
                        // We are basically calling this same method recursively until there is no more data
                        // on the read socket
                        bool IOPending = readsocket.ReceiveAsync(readSocket);
                        if (!IOPending)
                        {
                            ProcessReceive(readSocket);
                        }
                    }
                    else
                    {
                        Console.WriteLine(token.LastError);
                        CloseReadSocket(readSocket);
                    }

                }
                else
                {
                    ProcessError(readSocket);
                }
            }
            else
            {
                CloseReadSocket(readSocket);
            }
        }


        private void ProcessError(SocketAsyncEventArgs readSocket)
        {
            Console.WriteLine(readSocket.SocketError.ToString());
            CloseReadSocket(readSocket);
        }


        // This overload of the close method doesn't require a token
        private void CloseReadSocket(SocketAsyncEventArgs readSocket)
        {
            OSUserToken token = readSocket.UserToken as OSUserToken;
            CloseReadSocket(token, readSocket);
        }


        // This method closes the read socket and gets rid of our user token associated with it
        private void CloseReadSocket(OSUserToken token, SocketAsyncEventArgs readSocket)
        {
            token.Dispose();

            // Decrement the counter keeping track of the total number of clients connected to the server.
            Interlocked.Decrement(ref numconnections);

            // Put the read socket back in the stack to be used again
            socketpool.Push(readSocket);
        }
    }

    /// <summary>
    /// class OSClient : OSCore
    /// This is a naive client class that I added into this project just to test the server.
    /// It does very little error checking and is not suitable for anything but testing.
    /// </summary>
    class OSClient : OSCore
    {

        // This method is used to send a message to the server
        public bool Send(string cmdstring)
        {
            exceptionthrown = false;

             var parameters = os_util.ParseParams(cmdstring);
             if (parameters.Count > 0)
             {
                 try
                 {
                     // We need a connection to the server to send a message
                     if (connectionsocket.Connected)
                     {
                         byte[] byData = System.Text.Encoding.ASCII.GetBytes(parameters[0]);
                         connectionsocket.Send(byData);
                         return true;
                     }
                     else
                     {
                         return false;
                     }
                 }
                 catch (Exception ex)
                 {
                     lasterror = ex.ToString();
                     return false;
                 }
             }
             else
             {
                 lasterror = "No message provided for Send.";
                 return false;
             }
        }


        // This method disconnects us from the server
        public void DisConnect()
        {
            try
            {
                connectionsocket.Close();
            }
            catch
            {
                //nothing to do since connection is already closed
            }
        }


        // This method connects us to the server.
        // Winsock is very optimistic about connecting to the server.
        // It will not tell you, for instance, if the server actually accepted the connection.  It assumes that it did.
        public bool Connect(string cmdstring)
        {
            exceptionthrown = false;

            if (CreateSocket(cmdstring))
            {
                try
                {
                    var parameters = os_util.ParseParams(cmdstring);
                    if (parameters.Count > 1)
                    {
                        // This will succeed as long as some server is listening on this IP and port
                        var connectendpoint = CreateIPEndPoint(parameters[0], Convert.ToInt32(parameters[1]));
                        connectionsocket.Connect(connectionendpoint);
                        return true;
                    }
                    else
                    {
                        lasterror = "Server and Port not specified on client connection.";
                        return false;
                    }
                }
                catch(Exception ex)
                {
                    exceptionthrown = true;
                    lasterror = ex.ToString();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }

    /// <summary>
    /// class OSUtil
    /// This class just does some string tricks for the sample app
    /// It is no big deal.
    /// </summary>
    class OSUtil
    {
        char[] seps;

        // Allowed commands for the console app
        public enum os_cmd
        {
            OS_EXIT,
            OS_STARTSERVER,
            OS_CONNECT,
            OS_SEND,
            OS_DISCONNECT,
            OS_HELP,
            OS_UNDEFINED
        }


        public OSUtil()
        {
            seps = new char[] { ' ' };
        }

        // Parse the parameters from a command string
        public List<string> ParseParams(string commandstring)
        {
            string[] parts = commandstring.Split(seps);
           
            var parameters = new List<string>();

            if (parts.Length > 1)
            {
                for (int i = 1; i < parts.Length; i++)
                {
                    parameters.Add(parts[i]);
                }
            }

            return parameters;
        }

        // Parse a command from a string
        public os_cmd ParseCommand(string commandstring)
        {
            string[] parts = commandstring.Split(seps);

            if (!string.IsNullOrEmpty(parts[0]))
            {
                string cmd = parts[0];

                switch (cmd.ToLower())
                {
                    case "exit":
                        return os_cmd.OS_EXIT;
                        break;
                    case "startserver":
                        return os_cmd.OS_STARTSERVER;
                        break;
                    case "connect":
                        return os_cmd.OS_CONNECT;
                        break;
                    case "disconnect":
                        return os_cmd.OS_DISCONNECT;
                        break;
                    case "send":
                        return os_cmd.OS_SEND;
                        break;
                    case "help":
                        return os_cmd.OS_HELP;
                        break;
                    default:
                        return os_cmd.OS_UNDEFINED;
                        break;
                }
            }

            return os_cmd.OS_UNDEFINED;
        }

    }


    /// <summary>
    /// This is a console app to test the client and server.
    /// It does minimal error handling.
    /// To see the valid commands, start the app and type "help" at the command prompt
    /// </summary>
    class Program
    {
        // We use util, and one server, and one client in this app
        static OSUtil os_util;
        static OSServer os_server;
        static OSClient os_client;


        static void Main(string[] args)
        {
            //application state trackers
            bool shutdown = false;
            bool serverstarted = false;
            bool clientconnected = false;

            os_util = new OSUtil();

            // This is a loop to get commands from the user and execute them
            while (!shutdown)
            {
                string userinput = Console.ReadLine();

                if (!string.IsNullOrEmpty(userinput))
                {
                    switch(os_util.ParseCommand(userinput))
                    {
                        case OSUtil.os_cmd.OS_EXIT:
                            {
                                if (serverstarted)
                                {
                                    os_server.Stop();
                                }
                                shutdown = true;
                                break;
                            }
                        case OSUtil.os_cmd.OS_STARTSERVER:
                            {
                                if (!serverstarted)
                                {
                                    os_server = new OSServer();
                                    bool started = os_server.Start(userinput);
                                    if (!started)
                                    {
                                        Console.WriteLine("Failed to Start Server.");
                                        Console.WriteLine(os_server.GetLastError());
                                    }
                                    else
                                    {
                                        Console.WriteLine("Server started successfully.");
                                        serverstarted = true;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Server is already running.");
                                }
                                break;
                            }
                        case OSUtil.os_cmd.OS_CONNECT:
                            {
                                if (!clientconnected)
                                {
                                    os_client = new OSClient();
                                    bool connected = os_client.Connect(userinput);
                                    if (!connected)
                                    {
                                        Console.WriteLine("Failed to connect Client.");
                                        Console.WriteLine(os_client.GetLastError());
                                    }
                                    else
                                    {
                                        Console.WriteLine("Client might be connected.  It's hard to say.");
                                        clientconnected = true;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Client is already connected");
                                }
                                break;
                            }
                        case OSUtil.os_cmd.OS_DISCONNECT:
                            if (clientconnected)
                            {
                                os_client.DisConnect();
                                clientconnected = false;
                                Console.WriteLine("Client dis-connected from server successfully.");
                            }
                            break;
                        case OSUtil.os_cmd.OS_SEND:
                            {
                                if (clientconnected)
                                {
                                    os_client.Send(userinput);
                                    Console.WriteLine("Message sent from client...");
                                }
                                else
                                {
                                    Console.WriteLine("Send Failed with message:");
                                    Console.WriteLine(os_client.GetLastError());
                                }
                                break;
                            }
                        case OSUtil.os_cmd.OS_HELP:
                            {
                                Console.WriteLine("Available Commands:");
                                Console.WriteLine("startserver <port> = Start the OS Server (Limit 1 per box)");
                                Console.WriteLine("connect <server> <port> = Connect the client to the OS Server");
                                Console.WriteLine("disconnect = Disconnect from the OS Server");
                                Console.WriteLine("send <message> = Send a message to the OS Server");
                                Console.WriteLine("exit = Stop the server and quit the program");
                                break;
                            }
                    }
                }
            }
        }
    }
}
