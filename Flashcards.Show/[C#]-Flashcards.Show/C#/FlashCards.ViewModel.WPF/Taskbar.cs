using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAPICodePack.Taskbar;
using System.IO;
using System.Xml.Linq;
using System.Reflection;
using Microsoft.WindowsAPICodePack.Shell;
using System.Windows;

namespace FlashCards.ViewModel
{
    public static class Taskbar
    {
        public const string AdminArgument = "Admin";
        public const string GameArgument = "Game";
        public const string CreateNewCardDeckArgument = "CreateNewCardDeck";

        public const string RecentAdminJumpList = "RecentAdminJumpList.xml";
        public const string RecentGameJumpList = "RecentGameJumpList.xml";

        private static readonly string ExePath = Assembly.GetEntryAssembly().Location;
        private static readonly string GameIconPath = ExePath;
        private static readonly string AdminIconPath = Path.Combine(Path.GetDirectoryName(ExePath), @"adminicon.ico");

        private static bool _isAdmin;
        private static bool _jumpListFileLoaded = false;
        private static JumpList _jumpList;
        private static Dictionary<string, string> _recentJumpList = new Dictionary<string, string>();

        /// <summary>
        /// Inits the jump list.
        /// </summary>
        /// <param name="isAdmin">if set to <c>true</c> [is admin].</param>
        public static void InitJumpList(bool isAdmin)
        {
            _isAdmin = isAdmin;

            LoadDataFromXml();
            RefreshJumpListFromData();
        }

        /// <summary>
        /// Refreshes the jump list from data.
        /// </summary>
        private static void RefreshJumpListFromData()
        {
            try
            {
                if (TaskbarManager.IsPlatformSupported)
                {
                    JumpListCustomCategory customCategory = new JumpListCustomCategory("Recent");
                    _jumpList = JumpList.CreateJumpList();

                    for (int count = _recentJumpList.Count - 1; count >= 0; count--)
                    {
                        JumpListLink jumpListLink = new JumpListLink(ExePath, _recentJumpList.ElementAt(count).Value);
                        jumpListLink.Title = _recentJumpList.ElementAt(count).Value;
                        if (_isAdmin)
                        {
                            jumpListLink.Arguments = AdminArgument + " " + _recentJumpList.ElementAt(count).Key;
                            jumpListLink.IconReference = new IconReference(AdminIconPath, 0);
                        }
                        else
                        {
                            jumpListLink.Arguments = GameArgument + " " + _recentJumpList.ElementAt(count).Key;
                            jumpListLink.IconReference = new IconReference(GameIconPath, 0);
                        }
                        customCategory.AddJumpListItems(jumpListLink);
                    }

                    _jumpList.AddCustomCategories(customCategory);

                    if (_isAdmin)
                    {
                        // create new deck CMD
                        _jumpList.AddUserTasks(new JumpListLink(ExePath, (string)Application.Current.FindResource("Resource_JumpList_Task_CreateNewCardDeck"))
                        {
                            Title = (string)Application.Current.FindResource("Resource_JumpList_Task_CreateNewCardDeck"),
                            Arguments = CreateNewCardDeckArgument,
                            IconReference = new IconReference(AdminIconPath, 0)
                        });
                    }
                    else //user, add task to launch the Admin
                    {
                        // Start Admin instance
                        _jumpList.AddUserTasks(new JumpListLink(ExePath, (string)Application.Current.FindResource("Resource_JumpList_Task_StartAdmin"))
                        {
                            Title = (string)Application.Current.FindResource("Resource_JumpList_Task_StartAdmin"),
                            Arguments = AdminArgument,
                            IconReference = new IconReference(AdminIconPath, 0)
                        });
                    }

                    _jumpList.Refresh();
                }
            }
            catch (Exception e)
            {
                Utils.LogException(MethodBase.GetCurrentMethod(), e);
            }
        }

        /// <summary>
        /// Adds the entry to jump list.
        /// </summary>
        /// <param name="zipPath">The zip path.</param>
        /// <param name="deckTitle">The deck title.</param>
        public static void AddEntryToJumpList(string zipPath, string deckTitle)
        {
            if (string.IsNullOrEmpty(zipPath)) return;
            if (string.IsNullOrEmpty(deckTitle)) return;

            MainViewModel.Instance.DeckTitle = deckTitle;
            MainViewModel.Instance.SelectedZipPath = zipPath;

            bool listHasChanged = false;

            if (_recentJumpList.ContainsKey(zipPath))
            {
                if (_recentJumpList.ElementAt(0).Key != zipPath)
                {
                    _recentJumpList.Remove(zipPath);
                    Dictionary<string, string> temp = new Dictionary<string, string>();
                    foreach (var pair in _recentJumpList)
                    {
                        temp.Add(pair.Key, pair.Value);
                    }
                    _recentJumpList = temp;
                    _recentJumpList.Add(zipPath, deckTitle);
                    listHasChanged = true;
                }
            }
            else if (_recentJumpList.Count > 4)
            {
                _recentJumpList.Remove(_recentJumpList.ElementAt(0).Key);
                Dictionary<string, string> temp = new Dictionary<string, string>();
                foreach (var pair in _recentJumpList)
                {
                    temp.Add(pair.Key, pair.Value);
                }
                _recentJumpList = temp;
                _recentJumpList.Add(zipPath, deckTitle);
                listHasChanged = true;
            }
            else
            {
                _recentJumpList.Add(zipPath, deckTitle);
                listHasChanged = true;
            }

            if (listHasChanged)
            {
                //Save Jumplist to a XML
                SaveDataToXml();
                RefreshJumpListFromData();
            }
        }

        /// <summary>
        /// Removes the entry from jump list.
        /// </summary>
        /// <param name="zipPath">The zip path.</param>
        public static void RemoveEntryFromJumpList(string zipPath)
        {
            if (_recentJumpList.Count > 0)
            {
                if (_recentJumpList.ContainsKey(zipPath))
                {
                    _recentJumpList.Remove(zipPath);
                    Dictionary<string, string> temp = new Dictionary<string, string>();
                    foreach (var pair in _recentJumpList)
                    {
                        temp.Add(pair.Key, pair.Value);
                    }
                    _recentJumpList = temp;

                    RefreshJumpListFromData();
                    SaveDataToXml();
                }
            }
        }

        /// <summary>
        /// Gets the recent jump list file.
        /// </summary>
        /// <returns></returns>
        private static string GetRecentJumpListFile()
        {
            string recentJumpListFile = _isAdmin ? RecentAdminJumpList : RecentGameJumpList;

            return Path.Combine(DeckFileHelper.ZippedDecksPath, recentJumpListFile);
        }

        /// <summary>
        /// Loads the data from XML.
        /// </summary>
        private static void LoadDataFromXml()
        {
            try
            {
                string recentJumpListFile = GetRecentJumpListFile();

                if (File.Exists(recentJumpListFile) && !_jumpListFileLoaded)
                {
                    XElement jumpListXML = XElement.Load(recentJumpListFile);
                    IEnumerable<XElement> list = jumpListXML.Elements("JumpList");
                    _recentJumpList = list.ToDictionary(
                        element => element.Value,
                        element => element.Attribute("Title").Value
                        );

                    _jumpListFileLoaded = true;
                }
            }
            catch (Exception e)
            {
                Utils.LogException(MethodBase.GetCurrentMethod(), e);
            }
        }

        /// <summary>
        /// Saves the data to XML.
        /// </summary>
        private static void SaveDataToXml()
        {
            try
            {
                string recentJumpListFile = GetRecentJumpListFile();

                if (_recentJumpList.Count > 0)
                {
                    XElement jumpListXML = new XElement("RecentJumpLists");
                    foreach (var pair in _recentJumpList)
                    {
                        XElement list = new XElement("JumpList", pair.Key);
                        list.SetAttributeValue("Title", pair.Value);
                        jumpListXML.Add(list);
                    }
                    XDocument Xmldocument = new XDocument(jumpListXML);
                    Xmldocument.Save(recentJumpListFile);
                }
            }
            catch (Exception e)
            {
                Utils.LogException(MethodBase.GetCurrentMethod(), e);
            }
        }

        /// <summary>
        /// Updates the task bar status.
        /// </summary>
        /// <param name="currentValue">The current value.</param>
        /// <param name="MaxValue">The max value.</param>
        public static void UpdateTaskBarStatus(int currentValue, int MaxValue)
        {
            try
            {
                if (TaskbarManager.IsPlatformSupported)
                {
                    if (currentValue == MaxValue)
                    {
                        TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate);
                    }

                    if (currentValue == 0)
                    {
                        TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
                    }
                    else
                    {
                        TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
                        TaskbarManager.Instance.SetProgressValue(currentValue, MaxValue);
                    }
                }
            }
            catch (Exception e)
            {
                Utils.LogException(MethodBase.GetCurrentMethod(), e);
            }
        }
    }
}
