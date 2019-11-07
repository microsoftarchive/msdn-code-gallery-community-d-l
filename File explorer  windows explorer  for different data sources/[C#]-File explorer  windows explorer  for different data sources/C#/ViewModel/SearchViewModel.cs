using FileExplorer.Helper;
using FileExplorer.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Data;
using System.Windows.Threading;

namespace FileExplorer.ViewModel
{
    enum MediaType
    {
        All,
        Image,
        Music,
        Video,
        Document
    }

    public class SearchViewModel : SortOrderViewModel, ISearch
    {
        #region Properties

        private string searchKeyword = string.Empty;
        public string SearchKeyword
        {
            get { return searchKeyword; }
            set
            {
                if (SetProperty(ref searchKeyword, value, "SearchKeyword", "IsSearchEnabled"))
                {
                    if (this.searchKeyword.IsNullOrEmpty())
                    {
                        this.Cancel();
                        this.IsSearching = false;
                        this.IsChecked = false;
                        this.OnPropertyChanged("IsSearchCompleted");
                    }
                    else
                    {
                        this.IsSearching = true;
                        StartSearchTimer();
                    }
                }
            }
        }

        public bool IsSearchEnabled
        {
            get
            {
                return !SearchKeyword.IsNullOrEmpty();
            }
        }

        public bool IsSearchCompleted
        {
            get
            {
                bool result = IsSearchEnabled && !this.IsSearching;
                return result;
            }
        }

        private string notFoundHint = string.Empty;
        public string NotFoundHint
        {
            get { return notFoundHint; }
            set
            {
                SetProperty(ref notFoundHint, value, "NotFoundHint");
            }
        }

        private bool isSearching = false;
        public bool IsSearching
        {
            get { return isSearching; }
            set
            {
                if (SetProperty(ref isSearching, value, "IsSearching", "IsSearchCompleted"))
                {
                    this.SetSearchHint();
                }
            }
        }

        public int AllCount
        {
            get { return this.Items.Count; }
        }

        private int imageCount = 0;
        public int ImageCount
        {
            get { return imageCount; }
            set
            {
                SetProperty(ref imageCount, value, "ImageCount");
            }
        }

        private int videoCount = 0;
        public int VideoCount
        {
            get { return videoCount; }
            set
            {
                SetProperty(ref videoCount, value, "VideoCount");
            }
        }

        private int musicCount = 0;
        public int MusicCount
        {
            get { return musicCount; }
            set
            {
                SetProperty(ref musicCount, value, "MusicCount");
            }
        }

        private int documentCount = 0;
        public int DocumentCount
        {
            get { return documentCount; }
            set
            {
                SetProperty(ref documentCount, value, "DocumentCount");
            }
        }

        private bool? isChecked = false;
        public bool? IsChecked
        {
            get { return isChecked; }
            set
            {
                if (SetProperty(ref isChecked, value, "IsChecked"))
                {
                    SetIsCheckedAsync();
                }
            }
        }

        protected IFolder RootItem { get; set; }
        protected bool IsCanceled { get; set; }
        private ObservableCollection<IFile> items = new ObservableCollection<IFile>();
        protected ObservableCollection<IFile> Items { get { return items; } }

        #endregion

        public SearchViewModel()
        {
            this.ContentView = CollectionViewSource.GetDefaultView(this.Items);
            this.SetSortOrder(SortPropertyName);
        }

        private void SetSearchHint()
        {
            OnPropertyChanged("AllCount");
            string searchDone = "Search Done";
            if (this.Items.IsNullOrEmpty())
            {
                NotFoundHint = searchDone + " " + "None content";
            }
            else
            {
                NotFoundHint = searchDone + " " + "You can select";
            }
        }

        public void InitialSearch(IFolder rootItem)
        {
            UninitialSearch();
            if (!rootItem.IsNull())
                this.RootItem = rootItem;
        }

        public void UninitialSearch()
        {
            this.SearchKeyword = string.Empty;
            this.Cancel();
            this.IsSearching = false;
            this.IsChecked = false;
            if (!this.RootItem.IsNull())
            {
                this.RootItem = null;
            }
        }

        public IEnumerable<IFile> GetCheckedItems()
        {
            return this.Items.Where(item => item.IsChecked != false);
        }

        private void SetIsCheckedAsync()
        {
            Action action = () =>
            {
                //May be is searching         
                if (this.IsChecked == true || this.IsChecked == false)
                {
                    var temp = this.Items.ToList();
                    foreach (var item in temp)
                    {
                        item.IsChecked = this.IsChecked;
                    }
                }
            };
            action.BeginInvoke((ar) => { action.EndInvoke(ar); }, action);
        }

        #region Timer

        TimeSpan interval = TimeSpan.FromSeconds(1);
        DispatcherTimer timer = null;

        private void StartSearchTimer()
        {
            if (timer.IsNull())
            {
                timer = new DispatcherTimer(interval, DispatcherPriority.Normal, (sender, e) =>
                {
                    if (this.RootItem.IsNull())
                    {
                        this.StopSearchTimer();
                        return;
                    }

                    if (this.SearchKeyword.IsNullOrEmpty())
                    {
                        this.IsSearching = false;
                        this.StopSearchTimer();
                        return;
                    }

                    if (this.RootItem.IsLoading)
                    {
#if DEBUG
                        LogHelper.Debug("--- Searching timer, current folder is loading----");
#endif
                        //this.IsSearching = true;
                        //return;
                    }
                    else
                    {
                        this.Search(this.SearchKeyword);
                        this.StopSearchTimer();
                    }

                }, App.Current.Dispatcher);
            }

            if (!timer.IsEnabled)
            {
                timer.Start();
            }
            this.IsSearching = true;
        }

        private void StopSearchTimer()
        {
            if (!timer.IsNull() && timer.IsEnabled)
            {
                timer.Stop();
            }
        }

        private void RestartSearchTimer()
        {
            this.StopSearchTimer();
            this.Cancel();
            this.StartSearchTimer();
        }

        #endregion

        #region ISearch

        public void Cancel()
        {
            this.IsCanceled = true;
            this.oldKeyword = string.Empty;
            this.regPattern = string.Empty;
            this.Items.Clear();
            this.searchStateList.Clear();
            this.MusicCount = 0;
            this.VideoCount = 0;
            this.ImageCount = 0;
            this.DocumentCount = 0;
        }

        string oldKeyword = string.Empty;
        string regPattern = string.Empty;

        public void Search(string newKeyword)
        {
            this.Cancel();
            if (RootItem.IsNull() || oldKeyword == newKeyword)
            {
                this.IsSearching = false;
                return;
            }

            this.IsCanceled = false;
            if (newKeyword.IsNullOrEmpty())
            {
                this.oldKeyword = newKeyword;
                this.IsSearching = false;
                return;
            }

            oldKeyword = newKeyword;
            regPattern = GetRegexPattern(newKeyword);
            SearchFolder(RootItem);
        }

        object lockObj = new object();
        IList<IFolder> searchStateList = new List<IFolder>();

        private void SearchFolder(IFolder searchFolder)
        {
            if (searchFolder.IsNull() || regPattern.IsNullOrEmpty())
            {
                return;
            }

            lock (lockObj)
            {
                if (!searchStateList.Contains(searchFolder))
                {
                    searchStateList.Add(searchFolder);
                    IsSearching = true;
                }
            }

            if (Thread.CurrentThread.IsBackground || Thread.CurrentThread.IsThreadPoolThread)
            {
                AutoResetEvent autoEvent = new AutoResetEvent(false);
                searchFolder.GetChildrenAsync((items) =>
                {
                    SearchCallback(searchFolder, items, regPattern);
                    autoEvent.Set();
                });
#if DEBUG
                LogHelper.DebugFormat("->^^^^^^ Current searching folder:{0}", searchFolder.FullPath);
#endif
                autoEvent.WaitOne();
            }
            else
            {
                searchFolder.GetChildrenAsync((items) =>
                {
                    SearchCallback(searchFolder, items, regPattern);
                });
            }
        }

        private void SearchCallback(IFolder searchFolder, IEnumerable<IFile> subItems, string regPattern)
        {
            if (subItems.IsNullOrEmpty() || this.IsCanceled)
            {
                if (!searchFolder.IsLoading)
                {
                    lock (lockObj)
                    {
                        searchStateList.Remove(searchFolder);
                        if (searchStateList.IsNullOrEmpty())
                        {
                            this.IsSearching = false;
                        }
                    }
                }
                return;
            }

            IEnumerable<IFile> tempList = subItems.Where(item => SearchIsMatch(item, this.regPattern));
            try
            {
                ///list cleared by other thread
                foreach (var item in subItems.Where(item => item.IsFolder))
                {
                    IFolder folder = item as IFolder;
                    SearchFolder(folder);
                }
            }
            catch (InvalidOperationException)
            {
            }

            if (!tempList.IsNullOrEmpty() && !this.IsCanceled)
            {
                this.AddItemsByChunk(tempList, this.Items);
            }

            if (!searchFolder.IsLoading)
            {
                lock (lockObj)
                {
                    searchStateList.Remove(searchFolder);
                    if (searchStateList.IsNullOrEmpty())
                    {
                        this.IsSearching = false;
                    }
                }
            }
        }

        protected const int chunk = 50;
        protected bool AddItemsByChunk<T>(IEnumerable<T> source, IList destination) where T : IFile
        {
            if (source.IsNullOrEmpty() || destination.IsNull())
            {
                return true;
            }

            int index = 0;
            int getCount = chunk;
            while (getCount > 0)
            {
                var chunkItems = source.Skip(index++ * chunk).Take(chunk);
                getCount = chunkItems.Count();
                if (IsCanceled)
                {
                    return false;
                }

                if (getCount == 0)
                {
                    break;
                }

                RunOnUIThread(() =>
                {
                    foreach (var item in chunkItems)
                    {
                        if (IsCanceled)
                        {
                            return;
                        }

                        IFile file = item.Clone() as IFile;
                        if (!file.IsNull())
                        {
                            if (this.IsChecked == true || this.IsChecked == false)
                            {
                                file.IsChecked = this.IsChecked;
                            }
                            destination.Add(file);
                            CheckMediaType(file);
                        }
                    }
                    SetSearchHint();
                });
            }
            return true;
        }

        private bool SearchIsMatch(IFile file, string pattern)
        {
            bool result = false;
            if (file.IsNull() || file.Name.IsNullOrEmpty())
            {
                return result;
            }
            result = pattern.IsNullOrEmpty() ||
                     Regex.IsMatch(file.Name, pattern, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
            return result;
        }

        private string GetRegexPattern(string keyword)
        {
            string pattern = keyword;
            if (pattern.IsNullOrEmpty())
            {
                return pattern;
            }

            string[] reserverChars = { @"\", "/", "^", "$", "[", "]", "{", "}", ".", "+" };
            foreach (var item in reserverChars)
            {
                if (pattern.Contains(item))
                {
                    pattern = pattern.Replace(item, @"\" + item);
                }
            }

            IDictionary<string, string> wildCharsDic = new Dictionary<string, string>() { { "*", ".*" }, { "?", ".?" } };
            const string regStartPattern = "^";
            const string regEndPattern = "$";
            foreach (var key in wildCharsDic.Keys)
            {
                if (pattern.StartsWith(key))
                {
                    pattern = string.Format("{0}{1}", pattern.Replace(key, wildCharsDic[key]), regEndPattern);
                }
                else if (pattern.EndsWith(key))
                {
                    pattern = string.Format("{0}{1}", regStartPattern, pattern.Replace(key, wildCharsDic[key]));
                }
                else if (pattern.Contains(key))
                {
                    pattern = pattern.Replace(key, wildCharsDic[key]);
                }
            }

            return pattern;
        }

        #endregion

        #region Media type count

        readonly IList<string> defaultMusicExtension = new List<string>(FileExtension.GetAudioExtensions());
        readonly IList<string> defaultVideoExtension = new List<string>(FileExtension.GetVideoExtensions());
        readonly IList<string> defaultPhotoExtension = new List<string>(FileExtension.GetImageExtensions());

        private void CheckMediaType(IFile file)
        {
            if (file.IsNull())
            {
                return;
            }

            string ext = file.Extension.ToUpper();
            if (defaultPhotoExtension.Contains(ext))
            {
                ImageCount++;
            }
            else if (defaultVideoExtension.Contains(ext))
            {
                VideoCount++;
            }
            else if (defaultMusicExtension.Contains(ext))
            {
                MusicCount++;
            }
            else
            {
                DocumentCount++;
            }
        }

        internal void AddFilter(MediaType mediaType)
        {
            this.ContentView.Filter = null;
            switch (mediaType)
            {
                case MediaType.Image:
                    RunOnUIThreadAsync(() =>
                    {
                        this.ContentView.Filter = (item) =>
                        {
                            IFile file = item as IFile;
                            bool result = !file.IsNull() && defaultPhotoExtension.Contains(file.Extension.ToUpper());
                            return result;
                        };
                    });
                    break;

                case MediaType.Music:
                    RunOnUIThreadAsync(() =>
                    {
                        this.ContentView.Filter = (item) =>
                      {
                          IFile file = item as IFile;
                          bool result = !file.IsNull() && defaultMusicExtension.Contains(file.Extension.ToUpper());
                          return result;
                      };
                    });
                    break;

                case MediaType.Video:
                    RunOnUIThreadAsync(() =>
                      {
                          this.ContentView.Filter = (item) =>
                              {
                                  IFile file = item as IFile;
                                  bool result = !file.IsNull() && defaultVideoExtension.Contains(file.Extension.ToUpper());
                                  return result;
                              };
                      });
                    break;

                case MediaType.Document:
                    RunOnUIThreadAsync(() =>
                        {
                            this.ContentView.Filter = (item) =>
                             {
                                 IFile file = item as IFile;
                                 bool result = !file.IsNull() &&
                                                !defaultPhotoExtension.Contains(file.Extension.ToUpper()) &&
                                                !defaultMusicExtension.Contains(file.Extension.ToUpper()) &&
                                                !defaultVideoExtension.Contains(file.Extension.ToUpper());
                                 return result;
                             };
                        });
                    break;

                default:
                    break;
            }
        }

        #endregion

    }
}
