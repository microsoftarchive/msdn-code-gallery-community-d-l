// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReceiverBluetoothService.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   The Receiver bluetooth service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using InTheHand.Net.Sockets;

namespace BluetoothSample.Services
{
    /// <summary>
    /// The Receiver bluetooth service.
    /// </summary>
    public class ReceiverBluetoothService : ObservableObject, IDisposable, IReceiverBluetoothService
    {
        private readonly Guid _serviceClassId;
        private Action<string> _responseAction;
        private BluetoothListener _listener;
        private CancellationTokenSource _cancelSource;
        private bool _wasStarted;
        private string _status;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiverBluetoothService" /> class.
        /// </summary>
        public ReceiverBluetoothService()
        {
           _serviceClassId = new Guid("9bde4762-89a6-418e-bacf-fcd82f1e0677");
        }

        /// <summary>
        /// Gets or sets a value indicating whether was started.
        /// </summary>
        /// <value>
        /// The was started.
        /// </value>
        public bool WasStarted
        {
            get { return _wasStarted; }
            set { Set(() => WasStarted, ref _wasStarted, value); }
        }
        
        /// <summary>
        /// Starts the listening from Senders.
        /// </summary>
        /// <param name="reportAction">
        /// The report Action.
        /// </param>
        public void Start(Action<string> reportAction)
        {
            WasStarted = true;
            _responseAction = reportAction;
            if (_cancelSource != null && _listener != null)
            {
                Dispose(true);
            }
            _listener = new BluetoothListener(_serviceClassId)
            {
                ServiceName = "MyService"
            };
            _listener.Start();

            _cancelSource = new CancellationTokenSource();

            Task.Run(() => Listener(_cancelSource));
        }

        /// <summary>
        /// Stops the listening from Senders.
        /// </summary>
        public void Stop()
        {
            WasStarted = false;
            _cancelSource.Cancel();
        }

        /// <summary>
        /// Listeners the accept bluetooth client.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        private void Listener(CancellationTokenSource token)
        {
            try
            {
                while (true)
                {
                    using (var client = _listener.AcceptBluetoothClient())
                    {
                        if (token.IsCancellationRequested)
                        {
                            return;
                        }

                        using (var streamReader = new StreamReader(client.GetStream()))
                        {
                            try
                            {
                                var content = streamReader.ReadToEnd();
                                if (!string.IsNullOrEmpty(content))
                                {
                                    _responseAction(content);
                                }
                            }
                            catch (IOException)
                            {
                                client.Close();
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
               // todo handle the exception
               // for the sample it will be ignored
            }
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_cancelSource != null)
                {
                    _listener.Stop();
                    _listener = null;
                    _cancelSource.Dispose();
                    _cancelSource = null;
                }
            }
        }
    }
}
