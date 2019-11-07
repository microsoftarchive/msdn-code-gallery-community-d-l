using System;
using ComponentPro.IO;

namespace ClientSample
{
    partial class ClientController
    {
        /// <summary>
        /// Deletes files.
        /// </summary>
        /// <param name="files">Files to delete.</param>
        /// <param name="local">Indicate whether the list contains local files.</param>
        /// <param name="searchCondition">The search condition.</param>
        void DeleteFiles(AbstractFileInfo[] files, bool local, SearchCondition searchCondition)
        {
            if (files == null)
                return;

            if (files.Length == 1)
            {
                // User really wants to do that?
                if (!_view.AskYesNo(string.Format(Messages.MessageDeleteFolder, files[0].FullName)))
                    return;
            }
            else
            {
                // Delete multiple files/folders.
                if (!_view.AskYesNo(string.Format(Messages.MessageDeleteItems, files.Length)))
                    return;
            }

            EnableProgress(true);

            bool showProgress = _settings.Get<bool>(SettingInfo.ShowProgressWhileDeleting);

            if (local)
            {
                try
                {
                    DiskFileSystem.Default.DeleteFiles(_currentLocalDirectory, files, showProgress, RecursionMode.RecurseIntoAllSubFolders, true, searchCondition);
                }
                catch (Exception ex)
                {
                    _view.ShowError(ex);
                }

                EnableProgress(false);
                RefreshLocalList();

                return;
            }
#if Framework4_5 || !ASYNC    
            try
            {
#if Framework4_5
                await _client.DeleteFilesAsync(_currentDirectory, files, _ftpSettings.ShowProgressWhileDeleting, RecursionMode.RecurseIntoAllSubFolders, true, searchCondition);
#else
                _client.DeleteFiles(_currentDirectory, files, _ftpSettings.ShowProgressWhileDeleting, RecursionMode.RecurseIntoAllSubFolders, true, searchCondition);
#endif
            }
            catch (Exception ex)
            {
                if (!HandleException(ex))
                    return;
            }

            EnableProgress(false);
            RefreshRemoteList();

#else
            _client.DeleteFilesAsync(_currentDirectory, files, showProgress, RecursionMode.RecurseIntoAllSubFolders, true, searchCondition);
#endif
        }

        #region Local

        /// <summary>
        /// Deletes local files and/or folders.
        /// </summary>
        public void DoLocalDelete(AbstractFileInfo[] files)
        {
            DeleteFiles(files, true, null);
        }

        #endregion

        #region Remote

        /// <summary>
        /// Deletes remote files and/or folders.
        /// </summary>
        public void DoRemoteDelete(AbstractFileInfo[] files, SearchCondition searchCondition)
        {
            DeleteFiles(files, false, searchCondition);
        }

        #endregion
    }
}
