#region Copyright
//=======================================================================================
// Microsoft Azure Customer Advisory Team  
//
// This sample is supplemental to the technical guidance published on the community
// blog at http://blogs.msdn.com/b/paolos/. 
// 
// Author: Paolo Salvatori
//=======================================================================================
// Copyright © 2015 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
// EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
// MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=======================================================================================
#endregion

#region Using Directives

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Common.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Message = Microsoft.Azure.Devices.Client.Message;

#endregion

namespace Microsoft.AzureCat.Samples.DeviceEmulator
{
    public partial class MainForm : Form
    {
        #region Private Constants
        //***************************
        // Formats
        //***************************
        private const string DateFormat = "<{0,2:00}:{1,2:00}:{2,2:00}> {3}";
        private const string ExceptionFormat = "Exception: {0}";
        private const string InnerExceptionFormat = "InnerException: {0}";
        private const string LogFileNameFormat = "DeviceEmulatorLog-{0}.txt";

        //***************************
        // Constants
        //***************************
        private const string SaveAsTitle = "Save Log As";
        private const string SaveAsExtension = "txt";
        private const string SaveAsFilter = "Text Documents (*.txt)|*.txt";
        private const string Start = "Start";
        private const string Stop = "Stop";
        private const string DeviceName = "name";

        //***************************
        // Configuration Parameters
        //***************************
        private const string ConnectionStringParameter = "connectionString";
        private const string DeviceCountParameter = "deviceCount";
        private const string EventIntervalParameter = "eventInterval";
        private const string MinValueParameter = "minValue";
        private const string MaxValueParameter = "maxValue";
        private const string MinOffsetParameter = "minOffset";
        private const string MaxOffsetParameter = "maxOffset";
        private const string SpikePercentageParameter = "spikePercentage";

        //***************************
        // Configuration Parameters
        //***************************
        private const string DefaultStatus = "Ok";
        private const int DefaultDeviceNumber = 10;
        private const int DefaultMinValue = 20;
        private const int DefaultMaxValue = 50;
        private const int DefaultMinOffset = 20;
        private const int DefaultMaxOffset = 50;
        private const int DefaultSpikePercentage = 10;
        private const int DefaultEventIntervalInMilliseconds = 100;


        //***************************
        // Messages
        //***************************
        private const string ConnectionStringCannotBeNull = "The IoT connection string cannot be null.";
        private const string ConnectionStringIsWrong = "The IoT connection string does not contain the HostName.";
        private const string InitializingDevices = "Initializing devices...";
        private const string DevicesInitialized = "Devices initialized.";
        private const string CreatingDevices = "Creating devices...";
        private const string DevicesCreated = "Devices created.";
        private const string RemovingDevices = "Removing devices...";
        private const string DevicesRemoved = "Devices removed.";
        #endregion

        #region Private Fields
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private string ioTHubUrl;
        private readonly Random random = new Random((int)DateTime.Now.Ticks);
        private readonly List<Device> deviceList = new List<Device>();
        #endregion

        #region Public Constructor
        /// <summary>
        /// Initializes a new instance of the MainForm class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            ConfigureComponent();
            ReadConfiguration();
        }
        #endregion

        #region Public Methods

        public void ConfigureComponent()
        {
            txtConnectionString.AutoSize = false;
            txtConnectionString.Size = new Size(txtConnectionString.Size.Width, 24);
            txtDeviceCount.AutoSize = false;
            txtDeviceCount.Size = new Size(txtDeviceCount.Size.Width, 24);
            txtEventIntervalInMilliseconds.AutoSize = false;
            txtEventIntervalInMilliseconds.Size = new Size(txtEventIntervalInMilliseconds.Size.Width, 24);
            txtMinValue.AutoSize = false;
            txtMinValue.Size = new Size(txtMinValue.Size.Width, 24);
            txtMaxValue.AutoSize = false;
            txtMaxValue.Size = new Size(txtMaxValue.Size.Width, 24);
            txtMinOffset.AutoSize = false;
            txtMinOffset.Size = new Size(txtMinOffset.Size.Width, 24);
            txtMaxOffset.AutoSize = false;
            txtMaxOffset.Size = new Size(txtMinOffset.Size.Width, 24);
        }

        public void HandleException(Exception ex)
        {
            if (string.IsNullOrEmpty(ex?.Message))
            {
                return;
            }
            WriteToLog(string.Format(CultureInfo.CurrentCulture, ExceptionFormat, ex.Message));
            if (!string.IsNullOrEmpty(ex.InnerException?.Message))
            {
                WriteToLog(string.Format(CultureInfo.CurrentCulture, InnerExceptionFormat, ex.InnerException.Message));
            }
        }
        #endregion

        #region Private Methods
        public static bool IsJson(string item)
        {
            if (item == null)
            {
                throw new ArgumentException("The item argument cannot be null.");
            }
            try
            {
                var obj = JToken.Parse(item);
                return obj != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string IndentJson(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return null;
            }
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }

        private void ReadConfiguration()
        {
            try
            {
                txtConnectionString.Text = ConfigurationManager.AppSettings[ConnectionStringParameter];
                
                int value;
                var setting = ConfigurationManager.AppSettings[DeviceCountParameter];
                txtDeviceCount.Text = int.TryParse(setting, out value) ? 
                                       value.ToString(CultureInfo.InvariantCulture) : 
                                       DefaultDeviceNumber.ToString(CultureInfo.InvariantCulture);
                setting = ConfigurationManager.AppSettings[EventIntervalParameter];
                txtEventIntervalInMilliseconds.Text = int.TryParse(setting, out value) ?
                                       value.ToString(CultureInfo.InvariantCulture) :
                                       DefaultEventIntervalInMilliseconds.ToString(CultureInfo.InvariantCulture);
                setting = ConfigurationManager.AppSettings[MinValueParameter];
                txtMinValue.Text = int.TryParse(setting, out value) ?
                                       value.ToString(CultureInfo.InvariantCulture) :
                                       DefaultMinValue.ToString(CultureInfo.InvariantCulture);
                setting = ConfigurationManager.AppSettings[MaxValueParameter];
                txtMaxValue.Text = int.TryParse(setting, out value) ?
                                       value.ToString(CultureInfo.InvariantCulture) :
                                       DefaultMaxValue.ToString(CultureInfo.InvariantCulture);
                setting = ConfigurationManager.AppSettings[MinOffsetParameter];
                txtMinOffset.Text = int.TryParse(setting, out value) ?
                                       value.ToString(CultureInfo.InvariantCulture) :
                                       DefaultMinOffset.ToString(CultureInfo.InvariantCulture);
                setting = ConfigurationManager.AppSettings[MaxOffsetParameter];
                txtMaxOffset.Text = int.TryParse(setting, out value) ?
                                       value.ToString(CultureInfo.InvariantCulture) :
                                       DefaultMaxOffset.ToString(CultureInfo.InvariantCulture);
                setting = ConfigurationManager.AppSettings[SpikePercentageParameter];
                trackbarSpikePercentage.Value = int.TryParse(setting, out value)
                                                ? value
                                                : DefaultSpikePercentage;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void WriteToLog(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(InternalWriteToLog), message);
            }
            else
            {
                InternalWriteToLog(message);
            }
        }

        private void InternalWriteToLog(string message)
        {
            lock (this)
            {
                if (string.IsNullOrEmpty(message))
                {
                    return;
                }
                var lines = message.Split('\n');
                var now = DateTime.Now;
                var space = new string(' ', 19);

                for (var i = 0; i < lines.Length; i++)
                {
                    if (i == 0)
                    {
                        var line = string.Format(DateFormat,
                                                 now.Hour,
                                                 now.Minute,
                                                 now.Second,
                                                 lines[i]);
                        lstLog.Items.Add(line);
                    }
                    else
                    {
                        lstLog.Items.Add(space + lines[i]);
                    }
                }
                lstLog.SelectedIndex = lstLog.Items.Count - 1;
                lstLog.SelectedIndex = -1;
            }
        }

        #endregion

        #region Event Handlers

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstLog.Items.Clear();
        }

        /// <summary>
        /// Saves the log to a text file
        /// </summary>
        /// <param name="sender">MainForm object</param>
        /// <param name="e">System.EventArgs parameter</param>
        private void saveLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstLog.Items.Count <= 0)
                {
                    return;
                }
                saveFileDialog.Title = SaveAsTitle;
                saveFileDialog.DefaultExt = SaveAsExtension;
                saveFileDialog.Filter = SaveAsFilter;
                saveFileDialog.FileName = string.Format(LogFileNameFormat, DateTime.Now.ToString(CultureInfo.CurrentUICulture).Replace('/', '-').Replace(':', '-'));
                if (saveFileDialog.ShowDialog() != DialogResult.OK || 
                    string.IsNullOrEmpty(saveFileDialog.FileName))
                {
                    return;
                }
                using (var writer = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (var t in lstLog.Items)
                    {
                        writer.WriteLine(t as string);
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void logWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer.Panel2Collapsed = !((ToolStripMenuItem)sender).Checked;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AboutForm();
            form.ShowDialog();
        }

        private void lstLog_Leave(object sender, EventArgs e)
        {
            lstLog.SelectedIndex = -1;
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            var control = sender as Control;
            if (control != null)
            {
                control.ForeColor = Color.White;
            }
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            var control = sender as Control;
            if (control != null)
            {
                control.ForeColor = SystemColors.ControlText;
            }
        }
        
        // ReSharper disable once FunctionComplexityOverflow
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            var width = (mainHeaderPanel.Size.Width - 80)/2;
            var halfWidth = (width - 16)/2;

            txtMinOffset.Size = new Size(halfWidth, txtMinOffset.Size.Height);
            txtMaxOffset.Size = new Size(halfWidth, txtMaxOffset.Size.Height);
            txtDeviceCount.Size = new Size(halfWidth, txtDeviceCount.Size.Height);
            txtEventIntervalInMilliseconds.Size = new Size(halfWidth, txtEventIntervalInMilliseconds.Size.Height);
            txtMinValue.Size = new Size(halfWidth, txtMinValue.Size.Height);
            txtMaxValue.Size = new Size(halfWidth, txtMaxValue.Size.Height);
            trackbarSpikePercentage.Size = new Size(width, trackbarSpikePercentage.Size.Height);

            txtMaxValue.Location = new Point(32 + halfWidth, txtMaxValue.Location.Y);
            txtMinOffset.Location = new Point(32 + width, txtMaxOffset.Location.Y);
            txtMaxOffset.Location = new Point(48 + + width + halfWidth, txtMaxOffset.Location.Y);
            txtEventIntervalInMilliseconds.Location = new Point(32 + halfWidth, txtEventIntervalInMilliseconds.Location.Y);
            trackbarSpikePercentage.Location = new Point(32 + width, trackbarSpikePercentage.Location.Y);

            lblMaxValue.Location = new Point(32 + halfWidth, lblMaxValue.Location.Y);
            lblMinOffset.Location = new Point(32 + width, lblMaxOffset.Location.Y);
            lblMaxOffset.Location = new Point(48 + +width + halfWidth, lblMaxOffset.Location.Y);
            lblEventIntervalInMilliseconds.Location = new Point(32 + halfWidth, lblEventIntervalInMilliseconds.Location.Y);
            lblSpikePercentage.Location = new Point(32 + width, lblSpikePercentage.Location.Y);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            txtConnectionString.SelectionLength = 0;
        }

        // ReSharper disable once FunctionComplexityOverflow
        private async void btnStart_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (string.Compare(btnStart.Text, Start, StringComparison.OrdinalIgnoreCase) == 0)
            {
                try
                {
                    // Validate parameters
                    if (!ValidateParameters())
                    {
                        return;
                    }
                    // Change button text
                    btnStart.Text = Stop;

                    // Create cancellation token source
                    cancellationTokenSource = new CancellationTokenSource();
                    
                    // Initialize Devices
                    if (deviceList.Count != txtDeviceCount.IntegerValue)
                    {
                        await InitializeDevicesAsync();
                    }
                    
                    // Start Devices
                    StartDevices();
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    
                    // Change button text
                    btnStart.Text = Start;
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            else
            {
                try
                {
                    // Stop Devices
                    StopDevices();

                    // Change button text
                    btnStart.Text = Start;
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private async void btnCreateDevices_Click(object sender, EventArgs e)
        {
            await CreateDevicesAsync();
        }

        private async void btnRemoveDevices_Click(object sender, EventArgs e)
        {
            await RemoveDevicesAsync();
        }

        private bool ValidateParameters()
        {
            if (string.IsNullOrWhiteSpace(txtConnectionString.Text))
            {
                WriteToLog(ConnectionStringCannotBeNull);
                return false;
            }
            var match = Regex.Match(txtConnectionString.Text, @"HostName=([A-Za-z0-9_.-]+)", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                ioTHubUrl = match.Groups[1].Value;
            }
            else
            {
                WriteToLog(ConnectionStringIsWrong);
                return false;
            }
            return true;
        }

        private int GetValue(int minValue,
                             int maxValue,
                             int minOffset, 
                             int maxOffset, 
                             int spikePercentage)
        {
            var value = random.Next(0, 100);
            if (value >= spikePercentage)
            {
                return random.Next(minValue, maxValue + 1);
            }
            var sign = random.Next(0, 2);
            var offset = random.Next(minOffset, maxOffset + 1);
            offset = sign == 0 ? -offset : offset;
            return random.Next(minValue, maxValue + 1) + offset;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstLog.Items.Clear();
        }

        private void StartDevices()
        {
            const string status = DefaultStatus;
            var eventInterval = txtEventIntervalInMilliseconds.IntegerValue;
            var minValue = txtMinValue.IntegerValue;
            var maxValue = txtMaxValue.IntegerValue;
            var minOffset = txtMinOffset.IntegerValue;
            var maxOffset = txtMaxOffset.IntegerValue;
            var spikePercentage = trackbarSpikePercentage.Value;
            var cancellationToken = cancellationTokenSource.Token;

            // Create one task for each device
            for (var i = 0; i < txtDeviceCount.IntegerValue; i++)
            {
                var deviceId = i;
                #pragma warning disable 4014
                Task.Run(async () =>
                {
                    var deviceName = $"device{deviceId:000}";
                    var deviceClient = DeviceClient.Create(ioTHubUrl,
                        new DeviceAuthenticationWithRegistrySymmetricKey(deviceList[deviceId].Id, 
                                                                         deviceList[deviceId].Authentication.SymmetricKey.PrimaryKey));
                    WriteToLog($"DeviceClient [{deviceName}] successfully created.");
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        // Create random value
                        var value = GetValue(minValue, maxValue, minOffset, maxOffset, spikePercentage);
                        var timestamp = DateTime.Now;

                        // Create EventData object with the payload serialized in JSON format 
                        var payload = new Payload
                        {
                            DeviceId = deviceId,
                            Name = deviceName,
                            Status = status,
                            Value = value,
                            Timestamp = timestamp
                        };
                        var json = JsonConvert.SerializeObject(payload);
                        using (var message = new Message(Encoding.UTF8.GetBytes(json)))
                        {
                            // Create custom properties
                            message.Properties.Add(DeviceName, deviceName);

                            // Send the event to the event hub
                            await deviceClient.SendEventAsync(message);
                            WriteToLog($"[Event] DeviceId=[{payload.DeviceId:000}] " +
                                       $"Value=[{payload.Value:000}] " +
                                       $"Timestamp=[{payload.Timestamp}]");
                        }

                        // Wait for the event time interval
                        Thread.Sleep(eventInterval);
                    }
                },
                cancellationToken).ContinueWith(t =>
                {
                    if (t.IsFaulted && t.Exception != null)
                    {
                        HandleException(t.Exception);
                    }
                }, cancellationToken);
            }
        }

        private void StopDevices()
        {
            cancellationTokenSource?.Cancel();
        }

        public static string Combine(string uri1, string uri2)
        {
            uri1 = uri1.TrimEnd('/');
            uri2 = uri2.TrimStart('/');
            return $"{uri1}/{uri2}";
        }

        private void UpdateProgressBar(int value)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int>(InternalUpdateProgressBar), value);
            }
            else
            {
                InternalUpdateProgressBar(value);
            }
        }

        private void InternalUpdateProgressBar(int value)
        {
            toolStripProgressBar.Value = value;
        }

        private async Task InitializeDevicesAsync()
        {
            // Clear device list
            deviceList.Clear();

            // Create device identity registry manager from the connection string
            var registryManager = RegistryManager.CreateFromConnectionString(txtConnectionString.Text);
            toolStripProgressBar.Minimum = 0;
            toolStripProgressBar.Maximum = txtDeviceCount.IntegerValue;
            toolStripProgressBar.Value = 0;
            var added = 0;

            WriteToLog(InitializingDevices);
            var taskList = new List<Task>();
            for (var i = 1; i <= txtDeviceCount.IntegerValue; i++)
            {
                Device device;
                var deviceId = $"device{i:000}";
                taskList.Add(Task.Run(async () =>
                {
                    // if the device already exists in the device identity registry, retrieve it
                    device = await registryManager.GetDeviceAsync(deviceId);
                    if (device == null)
                    {
                        // try to create the device in the device identity registry
                        device = await registryManager.AddDeviceAsync(new Device(deviceId));
                        WriteToLog($"Device [{deviceId}] successfully created in the device identity registry with key [{device.Authentication.SymmetricKey.PrimaryKey}]");
                    }
                    else
                    {
                        WriteToLog($"Device [{deviceId}] already exists in the device identity registry with key [{device.Authentication.SymmetricKey.PrimaryKey}]");
                    }
                    UpdateProgressBar(++added);
                    deviceList.Add(device);
                }, cancellationTokenSource.Token));
                await Task.WhenAll(taskList);
            }
            if (!cancellationTokenSource.Token.IsCancellationRequested)
            {
                WriteToLog(DevicesInitialized);
            }
        }

        private async Task CreateDevicesAsync()
        {
            try
            {
                // Clear device list
                deviceList.Clear();

                // Create device identity registry manager from the connection string
                cancellationTokenSource = new CancellationTokenSource();
                var cancellationToken = cancellationTokenSource.Token;
                var registryManager = RegistryManager.CreateFromConnectionString(txtConnectionString.Text);
                toolStripProgressBar.Minimum = 0;
                toolStripProgressBar.Maximum = txtDeviceCount.IntegerValue;
                toolStripProgressBar.Value = 0;
                var added = 0;

                WriteToLog(CreatingDevices);
                var taskList = new List<Task>();
                for (var i = 1; i <= txtDeviceCount.IntegerValue; i++)
                {
                    Device device;
                    var deviceId = $"device{i:000}";
                    taskList.Add(Task.Run(async () =>
                    {
                        try
                        {
                            device = await registryManager.AddDeviceAsync(new Device(deviceId), cancellationToken);
                            WriteToLog(
                                $"Device [{deviceId}] successfully created in the device identity registry with key [{device.Authentication.SymmetricKey.PrimaryKey}]");
                        }
                        catch (DeviceAlreadyExistsException)
                        {
                            // if the device already exists in the device identity registry, retrieve it
                            device = await registryManager.GetDeviceAsync(deviceId, cancellationToken);
                            WriteToLog(
                                $"Device [{deviceId}] already exists in the device identity registry with key [{device.Authentication.SymmetricKey.PrimaryKey}]");
                        }
                        UpdateProgressBar(++added);
                        deviceList.Add(device);
                    }, cancellationToken).ContinueWith(t =>
                    {
                        if (t.IsFaulted && t.Exception != null)
                        {
                            HandleException(t.Exception);
                        }
                    }, cancellationToken));
                    await Task.WhenAll(taskList);
                }
                if (!cancellationToken.IsCancellationRequested)
                {
                    WriteToLog(DevicesCreated);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private async Task RemoveDevicesAsync()
        {
            try
            {
                // Create device identity registry manager from the connection string
                cancellationTokenSource = new CancellationTokenSource();
                var cancellationToken = cancellationTokenSource.Token;
                var registryManager = RegistryManager.CreateFromConnectionString(txtConnectionString.Text);
                toolStripProgressBar.Minimum = 0;
                toolStripProgressBar.Maximum = txtDeviceCount.IntegerValue;
                toolStripProgressBar.Value = 0;
                var removed = 0;
                var taskList = new List<Task>();

                WriteToLog(RemovingDevices);
                for (var i = 1; i <= txtDeviceCount.IntegerValue; i++)
                {
                    var deviceId = $"device{i:000}";
                    taskList.Add(Task.Run(async () =>
                    {
                        try
                        {
                            await registryManager.RemoveDeviceAsync(deviceId, cancellationToken);
                            WriteToLog($"Device [{deviceId}] successfully removed from the device identity registry.");
                        }
                        catch (DeviceNotFoundException)
                        {
                            WriteToLog($"Device [{deviceId}] does not exist in the device identity registry.");
                        }
                        UpdateProgressBar(++removed);
                    }, cancellationToken).ContinueWith(t =>
                    {
                        if (t.IsFaulted && t.Exception != null)
                        {
                            HandleException(t.Exception);
                        }
                    }, cancellationToken));  
                }
                await Task.WhenAll(taskList);
                if (!cancellationToken.IsCancellationRequested)
                {
                    WriteToLog(DevicesRemoved);
                }
            }
            catch (AggregateException ex)
            {
                if (ex.InnerExceptions != null && ex.InnerExceptions.Any())
                {
                    foreach (var exception in ex.InnerExceptions)
                    {
                        HandleException(exception);
                    }
                }

                // Change button text
                btnStart.Text = Start;
            }
            catch (Exception ex)
            {
                HandleException(ex);

                // Change button text
                btnStart.Text = Start;
            }
        }
        #endregion
    }
}
