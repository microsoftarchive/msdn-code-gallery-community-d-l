using System;
using System.Drawing;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ComponentPro.IO;

namespace ClientSample
{
    /// <summary>
    /// Login state.
    /// </summary>
    public enum LoginEnableState
    {
        LoginEnabled,
        LoginDisabled,
        LogoutEnabled,
        LogoutDisabled
    }

    public class ListItemInfo
    {
        public AbstractFileInfo FileInfo;
        public string Permissions;
        public AbstractFileInfo LinkedFile;

        public ListItemInfo()
        {

        }

        public ListItemInfo(AbstractFileInfo info)
        {
            FileInfo = info;
        }
    }

    interface IClientView
    {
        TraceListener GetLogger();
        void EnableView(bool enable);
        void EnableProgress(bool enable);
        void EnableLogin(LoginEnableState enable);
        void ShowError(string message);
        void ShowError(Exception ex);
        void ShowMessage(string message);
        string AskForPassword(string title);
        void AskOverwrite(TransferConfirmEventArgs e);

        void WriteLine(string str, Color color);

        bool AskYesNo(string message);

        void UpdateRemotePath(string path);
        void UpdateLocalPath(string path);

        void ListRemoteFiles(List<ListItemInfo> viewList);
        void ListLocalFiles(List<ListItemInfo> viewList);

        void UpdateProgress(FileSystemProgressEventArgs e, bool smallProgress, bool totalProgress);
        void UpdateStatus(string text);
    }
}
