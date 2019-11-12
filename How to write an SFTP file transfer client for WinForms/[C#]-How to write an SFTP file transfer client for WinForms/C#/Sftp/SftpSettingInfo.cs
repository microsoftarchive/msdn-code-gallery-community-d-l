using System;
using System.Collections.Generic;
using System.Text;

namespace ClientSample.Sftp
{
    class SftpSettingInfo
    {
        #region SFTP

        public const string ServerOs = "ServerOs";

        #endregion

        public static void SaveConfig(SettingInfoBase settings)
        {
            #region SFTP
            settings.SaveProperty(ServerOs);
            #endregion
        }

        public static void LoadConfig(SettingInfoBase settings)
        {
            #region SFTP
            settings.LoadProperty(ServerOs, 0);
            #endregion
        }
    }
}
