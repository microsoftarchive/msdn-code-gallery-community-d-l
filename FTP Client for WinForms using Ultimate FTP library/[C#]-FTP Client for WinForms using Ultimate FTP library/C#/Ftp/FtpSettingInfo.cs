using System;
using System.Collections.Generic;
using System.Text;

namespace ClientSample.Ftp
{
    class FtpSettingInfo
    {
        public const string SmartPath = "SmartPath";
        public const string SendAbortSignals = "SendAbortSignals";
        public const string SendAborCommand = "SendAborCommand";
        public const string ChangeDirBeforeListing = "ChangeDirBeforeListing";
        public const string ChangeDirBeforeTransfer = "ChangeDirBeforeTransfer";
        public const string Compress = "Compress";

        public static void SaveConfig(SettingInfoBase settings)
        {
            #region Ftp
            settings.SaveProperty(SendAbortSignals);
            settings.SaveProperty(SendAborCommand);
            settings.SaveProperty(ChangeDirBeforeListing);
            settings.SaveProperty(ChangeDirBeforeTransfer);
            settings.SaveProperty(SmartPath);
            settings.SaveProperty(Compress);
            #endregion
        }

        public static void LoadConfig(SettingInfoBase settings)
        {
            #region FTP
            settings.LoadProperty(SendAbortSignals, true);
            settings.LoadProperty(SendAborCommand, 0);
            settings.LoadProperty(ChangeDirBeforeListing, true);
            settings.LoadProperty(ChangeDirBeforeTransfer, false);
            settings.LoadProperty(SmartPath, false);
            settings.LoadProperty(Compress, false);
            #endregion
        }
    }
}
