using System;
using System.Collections.Generic;
using System.Text;
using ComponentPro.IO;

namespace ClientSample
{
    partial class ClientController
    {
        public bool DoRemoteRename(string name, string newname)
        {
            _view.EnableView(false);
            try
            {
                _client.Rename(name, newname);
            }
            catch (Exception ex)
            {
                if (!HandleException(ex))
                    return false;

                return false;
            }
            finally
            {
                _view.EnableView(true);
            }

            return true;
        }

        public void DoRemoteMove(AbstractFileInfo[] fileList, string destDir, string fileMasks)
        {
            if (fileList == null)
                return;

            // Enable progress bar, Abort button, and disable other controls.
            EnableProgress(true);

            TransferOptions opt = new TransferOptions(true, RecursionMode.RecurseIntoAllSubFolders, true, string.IsNullOrEmpty(fileMasks) ? (SearchCondition)null : new NameSearchCondition(fileMasks),
                FileExistsResolveAction.Confirm, SymlinksResolveAction.Confirm);

#if Framework4_5 || !ASYNC
            try
            {   
#if !ASYNC
                await client.MoveFilesAsync(_currentDirectory, fileList, _moveToFolder, opt);
#else
                client.MoveFiles(_currentDirectory, fileList, _moveToFolder, opt);
#endif

            }
            catch (Exception exc)
            {
                if (!HandleException(exc))
                    return;
            }

            EnableProgress(false);

            // Refresh the remote list view.
            RefreshRemoteList();
#else
            _client.MoveFilesAsync(_currentDirectory, fileList, destDir, opt);
#endif
        }
    }
}
