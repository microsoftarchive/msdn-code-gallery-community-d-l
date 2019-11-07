using FileExplorer.Helper;
using System.IO;

namespace FileExplorer.Model
{
    public class LocalFile : FileBase
    {
        public LocalFile(string path, IFolder parent)
            : base(path, parent)
        {
            FileInfo fileInfo = null;
            try
            {
                fileInfo = new FileInfo(this.FullPath);
            }
            catch (IOException ex)
            {
                LogHelper.Debug("Local folder constructor:{0}", ex);
            }

            if (fileInfo.IsNull())
            {
                return;
            }
            this.Name = fileInfo.Name;
            this.Extension = fileInfo.Extension;
            this.Size = fileInfo.Length;
            this.LastModifyTime = fileInfo.LastWriteTime;
            this.fileAttr = fileInfo.Attributes;
            ///Pre-load network driver icon 
            ///else will block UI
            var icon = this.Icon;
        }

        public override object Clone()
        {
            LocalFile file = new LocalFile(this.FullPath, this.Parent);
            CloneMembers(file);
            return file;
        }
    }
}
