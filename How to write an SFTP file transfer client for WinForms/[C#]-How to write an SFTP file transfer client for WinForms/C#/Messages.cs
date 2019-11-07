namespace ClientSample
{
    static class Messages
    {
        public const string InvalidSourceDestDir = "Destination directory cannot be the current directory.";
        public const string OverwriteFileConfirm = "Are you sure you want to overwrite file: {0}\r\n{1} Bytes, {2}\r\n\r\nWith file: {3}\r\n{4} Bytes, {5}?";
        public const string FileExists = "File or directory may already exist";
        public const string MessageTitle = "SFTP Client Demo";
        public const string InvalidTimeout = "Invalid timeout, it must be greater than or equal to 1";
        public const string InvalidPermissions = "Invalid permission (must be between 0 -> 0x777)";
        public const string TotalSize = "Total size: {0}";
        public const string TimeDiff = "The time difference between the client and server: {0}";
        public const string ConnectionHasNotBeenEstablished = "Connection has not been established";
        public const string RemoteFileSizeIsEqualToLocalFileSize = "Remote file size is equal to the local file size";
        public const string RemoteFileSizeIsGreaterThanLocalFileSize = "Remote file size is greater than the local file size";
        public const string RemoteFileSizeIsLessThanLocalFileSize = "Remote file size is less than the local file size";
        public const string InvalidDestDir = "Destination directory does not exist or no permission";
        public const string MessageDeleteFile = "Are you sure you want to delete file '{0}'?";
        public const string MessageDeleteItems = "Are you sure you want to delete {0} item(s)?";
        public const string MessageDeleteFolder = "Are you sure you want to delete entire folder '{0}'?";
        public const string NoPassword = "Password has not been provided\r\nThe connection will be closed";
        public const string PasswordCannotBeEmpty = "Password cannot be empty";
        public const string UserNameCannotBeEmpty = "User name cannot be empty";
        public const string HostNameCannotBeEmpty = "Host name cannot be empty";
        public const string InvalidPort = "Invalid port number";
        public const string SiteConfigFileNotFound = "FtpSites.xml not found";
        public const string FolderNameCannotBeEmpty = "Folder name cannot be empty";
        public const string InvalidCharacters = "Character '/' or '\\' should not be entered";
        public const string SyncConfirm = "Files and subfolders in folder '{0}' may be lost.\r\nAre you sure you want to synchronize folder '{0}' with folder '{1}'?";
    }
}