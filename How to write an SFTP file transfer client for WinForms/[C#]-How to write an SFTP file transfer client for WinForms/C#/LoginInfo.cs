using System;
using System.Diagnostics;
using ComponentPro.IO;
using ComponentPro.Net;

namespace ClientSample
{
    public class LoginInfo
    {
        public const string LogLevel = "LogLevel";
        public const string ServerName = "ServerName";
        public const string ServerPort = "ServerPort";
        public const string UserName = "Username";
        public const string Password = "Password";
        public const string RemoteDir = "RemoteDir";
        public const string LocalDir = "LocalDir";

        public const string Utf8Encoding = "Utf8Encoding";

        #region Proxy

        public const string ProxyServer = "ProxyServer";
        public const string ProxyPort = "ProxyPort";
        public const string ProxyUser = "ProxyUser";
        public const string ProxyPassword = "ProxyPassword";
        public const string ProxyDomain = "ProxyDomain";
        public const string ProxyType = "ProxyType";
        public const string ProxyHttpAuthnMethod = "ProxyHttpAuthnMethod";

        #endregion

        public const string SyncMethod = "SyncMethod";
        public const string SyncResumability = "SyncResumability";
        public const string SyncDateTime = "SyncDateTime";
        public const string SyncRecursive = "SyncRecursive";
        public const string SyncSearchPattern = "SyncSearchPattern";

        public const string ServerType = "ServerType";

        #region Methods

        public static void SaveConfig(SettingInfoBase settings)
        {
            // Save Login information.
            settings.SaveProperty(ServerName);
            settings.SaveProperty(ServerPort);
            settings.SaveProperty(UserName);
            settings.SaveProperty(Password);
            settings.SaveProperty(RemoteDir);
            settings.SaveProperty(LocalDir);

            settings.SaveProperty(Utf8Encoding);
            
            // Proxy Info.
            settings.SaveProperty(ProxyServer);
            settings.SaveProperty(ProxyPort);
            settings.SaveProperty(ProxyUser);
            settings.SaveProperty(ProxyPassword);
            settings.SaveProperty(ProxyDomain);
            settings.SaveProperty(ProxyType);
            settings.SaveProperty(ProxyHttpAuthnMethod);

            settings.SaveProperty(SyncMethod);
            settings.SaveProperty(SyncResumability);
            settings.SaveProperty(SyncDateTime);
            settings.SaveProperty(SyncRecursive);
            settings.SaveProperty(SyncSearchPattern);

            settings.SaveProperty(LogLevel);

            settings.SaveProperty(ServerType);
        }

        public static void LoadConfig(SettingInfoBase settings)
        {
            // Server and authentication info.
            settings.LoadProperty(ServerName, string.Empty);
            settings.LoadProperty(ServerPort, 21);
            settings.LoadProperty(UserName, string.Empty);
            settings.LoadProperty(Password, string.Empty);
            settings.LoadProperty(RemoteDir, string.Empty);
            settings.LoadProperty(LocalDir, AppDomain.CurrentDomain.BaseDirectory);
            
            settings.LoadProperty(Utf8Encoding, false);

            // Proxy info.
            settings.LoadProperty(ProxyServer, string.Empty);
            settings.LoadProperty(ProxyPort, 1080);
            settings.LoadProperty(ProxyUser, string.Empty);
            settings.LoadProperty(ProxyPassword, string.Empty);
            settings.LoadProperty(ProxyDomain, string.Empty);
            settings.LoadProperty(ProxyType, 0);
            settings.LoadProperty(ProxyHttpAuthnMethod, 0);

            settings.LoadProperty(SyncMethod, 0);
            settings.LoadProperty(SyncResumability, false);
            settings.LoadProperty(SyncDateTime, true);
            settings.LoadProperty(SyncRecursive, (int)RecursionMode.RecurseIntoAllSubFolders);
            settings.LoadProperty(SyncSearchPattern, "*.*");

            settings.LoadProperty(LogLevel, (int)TraceEventType.Information);

            settings.LoadProperty(ServerType, 0);
        }

        #endregion
    }    
}