/*
   Copyright 2013 Christoph Gattnar

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

	   http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System.IO;

namespace FileShortcutHelper
{
	public static class ShortcutHelper
	{
		public static bool IsShortcut(string path)
		{
			if(!File.Exists(path))
			{
				return false;
			}

			string directory = Path.GetDirectoryName(path);
			string file = Path.GetFileName(path);

			Shell32.Shell shell = new Shell32.Shell();
			Shell32.Folder folder = shell.NameSpace(directory);
			Shell32.FolderItem folderItem = folder.ParseName(file);

			if(folderItem != null)
			{
				return folderItem.IsLink;
			}

			return false;
		}

		public static string ResolveShortcut(string path)
		{
			if(IsShortcut(path))
			{
				string directory = Path.GetDirectoryName(path);
				string file = Path.GetFileName(path);

				Shell32.Shell shell = new Shell32.Shell();
				Shell32.Folder folder = shell.NameSpace(directory);
				Shell32.FolderItem folderItem = folder.ParseName(file);

				Shell32.ShellLinkObject link = (Shell32.ShellLinkObject)folderItem.GetLink;
				return link.Path;
			}
			return string.Empty;
		}
	}
}
