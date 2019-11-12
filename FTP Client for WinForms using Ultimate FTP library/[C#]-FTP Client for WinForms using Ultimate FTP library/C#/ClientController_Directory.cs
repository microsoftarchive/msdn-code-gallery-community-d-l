using System;
using System.Collections.Generic;
using System.Text;
using ClientSample.Ftp;
using ComponentPro.IO;
using ComponentPro.Net;

namespace ClientSample
{
    partial class ClientController
    {
        public bool DoRemoteMakeDir(string name)
        {
            _view.EnableView(false);

            try
            {
                // Create a new directory.
                _client.CreateDirectory(name);
            }
            catch (Exception exc)
            {
                if (!HandleException(exc))
                    return false;
            }

            // Refresh the remote list view.
            RefreshRemoteList();
            _view.EnableView(true);

            return true;
        }

        public void GetItemsSize(AbstractFileInfo[] files)
        {
            long total = 0;
            try
            {
                for (int i = 0; i < files.Length; i++)
                {
                    AbstractFileInfo f = files[i];
                    if (f.IsDirectory)
                        total += _client.GetDirectorySize(f.FullName, true);
                    else
                        total += f.Length;
                }

                _view.ShowMessage(string.Format("Total size: {0}", Util.FormatSize(total)));
            }
            catch (Exception exc)
            {
                HandleException(exc);
            }
        }
              

#if FTP
        public void DoRemoteSetFilePermissions(AbstractFileInfo[] files, string permissions, bool recursive)
        {
            ((ClientSample.Ftp.FtpClientPlugin)_clientPlugin).DoSetFilePermissions(files, permissions, recursive);
        }
#endif


#if SFTP
        public void DoRemoteSetFileAttributes(AbstractFileInfo[] files, SftpFileAttributes attr, bool recursive)
        {
            ((ClientSample.Sftp.SftpClientPlugin)_clientPlugin).DoSetFileAttributes(files, attr, recursive);
        }
#endif
    }
}
