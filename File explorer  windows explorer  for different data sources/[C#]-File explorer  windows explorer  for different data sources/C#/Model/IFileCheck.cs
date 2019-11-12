
using System.Collections.Generic;

namespace FileExplorer.Model
{
    interface IFileCheck
    {
        /// <summary>
        /// Checked item not to do the recursive  checked opertion
        /// </summary>
        /// <param name="isChecked"></param>
        void SetChecked(bool? isChecked);

        /// <summary>
        /// Checked the all parent for current item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isChecked"></param>
        void CheckParent(IFile item, bool? isChecked);

        /// <summary>
        /// Set checked by file path
        /// </summary>
        /// <returns></returns>
        // void SetChecked(IList<string> path);
    }

    interface IFolderCheck : IFileCheck
    {   /// <summary>
        /// Checked the all children for current item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isChecked"></param>
        void CheckChildren(IFolder item, bool? isChecked);

        /// <summary>
        /// Get all checked children for current item
        /// </summary>
        /// <returns></returns>
        IEnumerable<IFile> GetCheckedItems(IFolder folder);
    }
}
