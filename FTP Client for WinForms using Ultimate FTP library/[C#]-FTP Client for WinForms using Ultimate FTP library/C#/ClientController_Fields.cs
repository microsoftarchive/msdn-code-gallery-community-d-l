using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ClientSample
{
    partial class ClientController
    {
        private bool _reconnecting; // Indicates whether the connection is closed unexpectedly and the app is about to reconnect.

        private ConnectionState _state; // The connection state.
        private ServerProtocol _serverType;

        private string _currentDirectory;
        string _currentLocalDirectory;
        private bool _aborting;

        public string CurrentLocalDirectory
        {
            get { return _currentLocalDirectory; }
        }

        public string CurrentRemoteDirectory
        {
            get { return _currentDirectory; }
        }
    }
}
