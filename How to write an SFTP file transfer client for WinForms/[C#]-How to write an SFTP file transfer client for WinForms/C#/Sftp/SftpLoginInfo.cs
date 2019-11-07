namespace ClientSample.Sftp
{
    class SftpLoginInfo
    {
        public const string PrivateKey = "PrivateKey";
        public const string EnableCompression = "EnableCompression";

        public static void SaveConfig(SettingInfoBase settings)
        {
            settings.SaveProperty(PrivateKey);
            settings.SaveProperty(EnableCompression);
        }

        public static void LoadConfig(SettingInfoBase settings)
        {
            settings.LoadProperty(PrivateKey, string.Empty);
            settings.LoadProperty(EnableCompression, false);
        }
    }
}