using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace FileExplorer.Helper
{

    /// <summary>
    ///  Drive changed, add or remove
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void DriverChangedEventhandler(List<string> drives, bool isAdd);

    /// <summary>
    /// use to watch ready drive change
    /// </summary>
    public class DriverWatcher
    {
        /// <summary>
        /// notify drive change
        /// </summary>
        public event DriverChangedEventhandler DriverChanged;

        /// <summary>
        /// current drives
        /// </summary>
        IList<string> oldDrivers;

        /// <summary>
        /// stop scan flag
        /// </summary>
        bool isStopped = false;

        /// <summary>
        /// 
        /// </summary>
        Thread _thread;

        /// <summary>
        ///  start scan
        /// </summary>
        public void Start(IList<string> drivers)
        {
            if (!drivers.IsNullOrEmpty())
            {
                oldDrivers = drivers;
            }
            else
            {
                oldDrivers = GetDriverNames();
            }

            _thread = new Thread(new ThreadStart(Scan));
            _thread.IsBackground = true;
            _thread.Name = "Drive watch  ";
            _thread.Start();
        }

        public static IList<DriveInfo> GetDrivers()
        {
            IList<DriveInfo> drivers = new List<DriveInfo>();
            foreach (var item in DriveInfo.GetDrives().Where(o => o.IsReady))
            {
                try
                {
                    ///If mobile phone is connect, will detect a accessless driver
                    ///this driver is not shown by PC
                    ///so ignore it 
                    long freeSpace = item.AvailableFreeSpace;
                    drivers.Add(item);
                }
                catch (IOException)
                {
                    ///The device is not ready
                }
            }
            return drivers;
        }

        private IList<string> GetDriverNames()
        {
            return GetDrivers().Select(item => item.Name).ToList();
        }

        public void Stop()
        {
            isStopped = true;
        }

        /// <summary>
        /// MS
        /// </summary>
        private const int interval = 2 * 1000;

        void Scan()
        {
            while (!isStopped)
            {
                var newDrivers = GetDriverNames();

                var addedDrive = newDrivers.Except(oldDrivers);

                if (!addedDrive.IsNullOrEmpty() && !DriverChanged.IsNull())
                {
                    DriverChanged(addedDrive.ToList(), true);
                }

                var removeDrive = oldDrivers.Except(newDrivers);
                if (!removeDrive.IsNullOrEmpty() && !DriverChanged.IsNull())
                {
                    DriverChanged(removeDrive.ToList(), false);
                }

                oldDrivers = newDrivers;
                Thread.Sleep(interval);
            }
        }
    }
}
