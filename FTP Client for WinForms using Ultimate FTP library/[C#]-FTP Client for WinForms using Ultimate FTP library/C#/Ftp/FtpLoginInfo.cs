using System;
using System.Collections.Generic;
using System.Text;

namespace ClientSample.Ftp
{
    class FtpLoginInfo
    {
        public const string PasvMode = "PasvMode";
        public const string SecurityMode = "SecMode";
        public const string Certificate = "Cert";
        public const string ClearCommandChannel = "ccc";

        public static void SaveConfig(SettingInfoBase settings)
        {
            settings.SaveProperty(PasvMode);
            settings.SaveProperty(Certificate);
            settings.SaveProperty(SecurityMode);
            settings.SaveProperty(ClearCommandChannel);
        }

        public static void LoadConfig(SettingInfoBase settings)
        {
            settings.LoadProperty(PasvMode, true);
            settings.LoadProperty(Certificate, string.Empty);
            settings.LoadProperty(SecurityMode, 0);
            settings.LoadProperty(ClearCommandChannel, false);
        }
    }
}
