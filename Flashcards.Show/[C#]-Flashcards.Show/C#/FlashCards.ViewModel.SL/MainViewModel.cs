using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Xml.Serialization;
using System.Windows.Input;
using FlashCards.Commands;
using System.Net;
using System.ComponentModel;
using System.Collections.ObjectModel;
#if !WINDOWS_PHONE
using FlashCards.ViewModel.FlashService;
#else
using System.IO.IsolatedStorage;
using FlashCards.ViewModel.Phone.FlashCardsServiceReference;
using System.Windows.Threading;
#endif

namespace FlashCards.ViewModel
{
    public enum GameModes
    { 
        DownloadDeck,
        GameSelect,
        LearningGame,
        MatchingGame,
        MemoryGame
    }

#if WINDOWS_PHONE
    public class ImageItem
    {
        private string _filename;

        public ImageItem(string filename)
        {
            _filename = filename;
        }

        public string FileName 
        { 
            get 
            { 
                return _filename; 
            } 
        }

        public BitmapImage Source
        {
            get 
            {
                try
                {
                    IsolatedStorageFile isolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication();
                    IsolatedStorageFileStream isolatedStorageFileStream = isolatedStorageFile.OpenFile(Path.Combine(MainViewModel.DecksFolder, _filename), FileMode.Open);

                    StreamResourceInfo streamResourceInfo = new StreamResourceInfo(isolatedStorageFileStream, @"application/zip");

                    Uri uri;
                    StreamResourceInfo xmlSri;
                    XmlSerializer SerializerObj;

                    // get deck.xml
                    uri = new Uri("deck.xml", UriKind.Relative);
                    xmlSri = Application.GetResourceStream(streamResourceInfo, uri);

                    SerializerObj = new XmlSerializer(typeof(CardDeck));
                    CardDeck cDeck = (CardDeck)SerializerObj.Deserialize(xmlSri.Stream);

                    string zippedFileName = cDeck.DisplayCoverSource;

                    uri = new Uri(zippedFileName, UriKind.Relative);
                    xmlSri = Application.GetResourceStream(streamResourceInfo, uri);

                    Stream stream = xmlSri.Stream;

                    BitmapImage bi = new BitmapImage();
                    bi.SetSource(xmlSri.Stream);
                    stream.Close();
                    
                    isolatedStorageFileStream.Close();

                    return bi;
                }
                catch (Exception e)
                {
                    Utils.LogException(MethodBase.GetCurrentMethod(), e);
                    return null;
                }
            }
        }

        public string Name 
        { 
            get 
            { 
                return Path.GetFileNameWithoutExtension(_filename); 
            } 
        }

        public override bool Equals(object obj)
        {
            ImageItem imageItem = obj as ImageItem;
            if (imageItem == null) 
            {
                return false;
            }

            return _filename.Equals(imageItem._filename);
        }

        public override int GetHashCode()
        {
            return _filename.GetHashCode();
        }
    }
#endif

    public class MainViewModel : BaseMainViewModel
    {
        private MainViewModel()
        {
#if !WINDOWS_PHONE
            CancelDownloadCommand = new DelegateCommand(ExecuteCancelDownload);
#else
            Images = new ObservableCollection<ImageItem>();
#endif
        }

        private Dictionary<string, BitmapImage> _imagesDictionary = new Dictionary<string, BitmapImage>();
        public BitmapImage GetImage(string imageName)
        {
            if (_imagesDictionary.ContainsKey(imageName))
            {
                return _imagesDictionary[imageName];
            }

            return null;
        }

        private Dictionary<string, Stream> _videoDictionary = new Dictionary<string, Stream>();
        public Stream GetVideo(string videoName)
        {
            if (_videoDictionary.ContainsKey(videoName))
            {
                return _videoDictionary[videoName];
            }

            return null;
        }

        public void LoadDeckFromZip(Stream zipStreamPackage)
        {
            try
            {
                StreamResourceInfo streamResourceInfo = new StreamResourceInfo(zipStreamPackage, @"application/zip");

                Uri uri;
                StreamResourceInfo xmlSri;
                XmlSerializer SerializerObj;

                // get deck.xml
                uri = new Uri("deck.xml", UriKind.Relative);
                xmlSri = Application.GetResourceStream(streamResourceInfo, uri);

                SerializerObj = new XmlSerializer(typeof(CardDeck));
                CardDeck cDeck = (CardDeck)SerializerObj.Deserialize(xmlSri.Stream);

                // get files list
                uri = new Uri("files.xml", UriKind.Relative);
                xmlSri = Application.GetResourceStream(streamResourceInfo, uri);

                SerializerObj = new XmlSerializer(typeof(string[]));
                string[] fileNames = (string[])SerializerObj.Deserialize(xmlSri.Stream);

                _imagesDictionary.Clear();
                for (int i = 0; i < fileNames.Length; i += 2)
                {
                    string zippedFileName = fileNames[i];
                    string originalFileName = fileNames[i + 1];

                    if (string.Compare(Path.GetExtension(zippedFileName), ".xml", StringComparison.InvariantCultureIgnoreCase) != 0)
                    {
                        try
                        {
                            uri = new Uri(zippedFileName, UriKind.Relative);
                            xmlSri = Application.GetResourceStream(streamResourceInfo, uri);

                            Stream stream = xmlSri.Stream;

                            if (string.Compare(Path.GetExtension(zippedFileName), ".wmv", StringComparison.InvariantCultureIgnoreCase) != 0)
                            {
                                BitmapImage bi = new BitmapImage();
                                bi.SetSource(xmlSri.Stream);
                                _imagesDictionary[originalFileName] = bi;
                                stream.Close();
                            }
                            else
                            {
                                _videoDictionary[originalFileName] = stream;
                            }
                        }
                        catch (Exception e)
                        {
                            Utils.LogException(MethodBase.GetCurrentMethod(), e);
                        }
                    }
                }

                cDeck.RootPath = "";
                cDeck.DeckGUID = "";
                if (cDeck != null)
                {
                    Decks.SelectedDeck = cDeck;
                }

                cDeck.Initialize();
                foreach (CardPair cp in cDeck.Collection)
                {
                    cp.ParentDeck = cDeck;
                    cp.Initialize();
                }
            }
            catch (Exception e)
            {
                Utils.LogException(MethodBase.GetCurrentMethod(), e);
            }
        }

        private readonly string DownloadingDeckString = (string)Application.Current.Resources["Resource_DownloadingDeck"];
        private readonly string DeckNotFoundString = (string)Application.Current.Resources["Resource_DeckNotFound"];
        private readonly string NetworkErrorString = (string)Application.Current.Resources["Resource_NetworkError"];
        private readonly string ServerErrorString = (string)Application.Current.Resources["Resource_ServerError"];
        private readonly string GameLoadingString = (string)Application.Current.Resources["Resource_Game_Loading"];


#if !WINDOWS_PHONE
        public ICommand CancelDownloadCommand { get; private set; }

        private WebClient _webClient;
        private bool _isCanceled = false;
        public void StartLoading(string senderName, string password)
        {
            // get file url from web service
            FlashCardServiceClient flashCardsService = new FlashCardServiceClient();
            flashCardsService.GetFileUriCompleted += (s, args) =>
            {
               
                string fileUri = args.Result;
                Uri uri = new Uri(fileUri, UriKind.RelativeOrAbsolute);

                // Download the zip package.
                _webClient = new WebClient();

                _webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(webClient_OpenReadCompleted);
                _webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
                _webClient.OpenReadAsync(uri);
            };
            flashCardsService.GetFileUriAsync(senderName, password);
        }

        private void ExecuteCancelDownload()
        {
            if (_webClient.IsBusy)
            {
                _isCanceled = true;
                _webClient.CancelAsync();
                MainViewModel.Instance.IsBusy = false;
            }
        }

        private void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            long percent = (e.TotalBytesToReceive != 0) ? (100 * e.BytesReceived) / e.TotalBytesToReceive : 0;
            MainViewModel.Instance.WaitIndicatorText = string.Format(DownloadingDeckString, percent);
        }

        private void webClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if (!_isCanceled)
            {
                Stream zipPackageStream = (Stream)e.Result;
                MainViewModel.Instance.LoadDeckFromZip(zipPackageStream);
                MainViewModel.Instance.IsBusy = false;
            }
            
        }
#else
        public void StartLoading()
        {
            IsBusy = true;
            WaitIndicatorText = string.Format(DownloadingDeckString, 0);
   
            WebClient webClient;
        
            // get file url from web service
            FlashCardServiceClient flashCardsService = new FlashCardServiceClient();
            flashCardsService.GetFileUriCompleted += (s, args) =>
                {
                    if (args.Error == null)
                    {
                        string fileUri = args.Result;
                        if (!string.IsNullOrEmpty(fileUri))
                        {
                            Uri uri = new Uri(fileUri, UriKind.RelativeOrAbsolute);

                            // Download the zip package.
                            webClient = new WebClient();

                            webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(webClient_OpenReadCompleted);
                            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
                            webClient.OpenReadAsync(uri);
                        }
                        else
                        {
                            ReportStatus(DeckNotFoundString);
                        }
                    }
                    else
                    {
                        ReportStatus(NetworkErrorString);
                    }
                };

            flashCardsService.GetFileUriAsync(SenderName, Password);
        }

        private void ReportStatus(string errorStatus)
        {
            WaitIndicatorText = errorStatus;
                            
            DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(3) };
            timer.Tick += (sender, e) =>
            {
                timer.Stop();
                IsBusy = false;

                SenderName = string.Empty;
                Password = string.Empty;
            };
            timer.Start();
        }

        private void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            MainViewModel.Instance.WaitIndicatorText = string.Format(DownloadingDeckString, e.ProgressPercentage);
        }

        private void webClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                MainViewModel.Instance.GameMode = GameModes.GameSelect;
                Stream zipPackageStream = (Stream)e.Result;
                MainViewModel.Instance.LoadDeckFromZip(zipPackageStream);
                SaveStreamToIsolatedStorage(MainViewModel.Instance.Decks.SelectedDeck.Title, zipPackageStream);
                IsBusy = false;
            }
            else
            {
                ReportStatus(ServerErrorString);
            }
        }

        private void SaveStreamToIsolatedStorage(string title, Stream stream)
        {
            IsolatedStorageFile isolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication();

            if (!isolatedStorageFile.DirectoryExists(MainViewModel.DecksFolder))
            {
                isolatedStorageFile.CreateDirectory(MainViewModel.DecksFolder);
            }

            IsolatedStorageFileName = Path.Combine(MainViewModel.DecksFolder, title + MainViewModel.ZippedDeckExtension);
            IsolatedStorageFileStream isolatedStorageFileStream = isolatedStorageFile.CreateFile(IsolatedStorageFileName);

            Utils.CopyStream(stream, isolatedStorageFileStream);

            isolatedStorageFileStream.Close();

            ImageItem newImageItem = new ImageItem(title + MainViewModel.ZippedDeckExtension);
            if (!Images.Contains(newImageItem))
            {
                Images.Add(newImageItem);
            }
        }

        public void LoadDeckFromIsolatedStorage(string filename)
        {
            IsolatedStorageFileName = Path.Combine(MainViewModel.DecksFolder, filename);
            LoadDeckFromIsolatedStorage();
        }

        public void LoadDeckFromIsolatedStorage()
        {
            IsBusy = true;
            ReportStatus(GameLoadingString);

            IsolatedStorageFile isolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream isolatedStorageFileStream = isolatedStorageFile.OpenFile(IsolatedStorageFileName, FileMode.Open);

            MainViewModel.Instance.LoadDeckFromZip(isolatedStorageFileStream);

            isolatedStorageFileStream.Close();
        }

        public void RemoveFromIsolatedStorage(string filename)
        {
            IsolatedStorageFile isolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication();
            isolatedStorageFile.DeleteFile(Path.Combine(MainViewModel.DecksFolder, filename));
        }

        public void LoadSavedDecks()
        {
            IsolatedStorageFile isolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication();

            if (isolatedStorageFile.DirectoryExists(MainViewModel.DecksFolder))
            {
                string[] files = isolatedStorageFile.GetFileNames(Path.Combine(MainViewModel.DecksFolder, "*" + MainViewModel.ZippedDeckExtension));
             
                foreach (string file in files)
                {
                    Images.Add(new ImageItem(file));
                }
            }
        }

#endif

        #region IsBusy

        private bool _isBusy;
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    RaisePropertyChanged(@string.of(() => IsBusy));
                }
            }
        }

        #endregion

        #region WaitIndicatorText

        private string _waitIndicatorText;
        public string WaitIndicatorText
        {
            get
            {
                return _waitIndicatorText;
            }
            set
            {
                if (_waitIndicatorText != value)
                {
                    _waitIndicatorText = value;
                    RaisePropertyChanged(@string.of(() => WaitIndicatorText));
                }
            }
        }

        #endregion

        #region IsolatedStorageFileName

        private string _isolatedStorageFileName;
        public string IsolatedStorageFileName
        {
            get
            {
                return _isolatedStorageFileName;
            }
            set
            {
                if (_isolatedStorageFileName != value)
                {
                    _isolatedStorageFileName = value;
                    RaisePropertyChanged(@string.of(() => IsolatedStorageFileName));
                    RaisePropertyChanged(@string.of(() => HasDeckFile));
                    Decks.HasDeckFile = HasDeckFile;
                }
            }
        }

        public bool HasDeckFile
        {
            get
            {
                return !string.IsNullOrEmpty(IsolatedStorageFileName); 
            }
        }

        #endregion

        #region GameMode

        private GameModes _gameMode;
        public GameModes GameMode
        {
            get
            {
                return _gameMode;
            }
            set
            {
                if (_gameMode != value)
                {
                    _gameMode = value;
                    RaisePropertyChanged(@string.of(() => GameMode));
                }
            }
        }

        #endregion

        #region SenderName

        private string _senderName;
        public string SenderName
        {
            get
            {
                return _senderName;
            }
            set
            {
                if (_senderName != value)
                {
                    _senderName = value;
                    RaisePropertyChanged(@string.of(() => SenderName));
                }
            }
        }

        #endregion

        #region Password

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    RaisePropertyChanged(@string.of(() => Password));
                }
            }
        }


        #endregion

        #region SavedDecks

        private string _savedDecks;
        public string SavedDecks
        {
            get
            {
                return _savedDecks;
            }
            set
            {
                if (_savedDecks != value)
                {
                    _savedDecks = value;
                    RaisePropertyChanged(@string.of(() => SavedDecks));
                }
            }
        }


        #endregion

#if WINDOWS_PHONE
        #region Images

        private ObservableCollection<ImageItem> _images;
        public ObservableCollection<ImageItem> Images
        {
            get
            {
                return _images;
            }
            set
            {
                if (_images != value)
                {
                    _images = value;
                    RaisePropertyChanged(@string.of(() => Images));
                }
            }
        }

        #endregion
#endif

        public static MainViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MainViewModel()
                    {
                        Decks = new DecksCollection()
                    };

#if WINDOWS_PHONE
                    _instance.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(_instance_PropertyChanged);
#else
                    _instance.CurrentView = _instance.Decks;
#endif

                }

                return _instance;
            }
        }

#if WINDOWS_PHONE

        private static void _instance_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "GameMode")
            {
                return;
            }

            Microsoft.Phone.Controls.PhoneApplicationFrame phoneApplicationFrame = (Application.Current.RootVisual as Microsoft.Phone.Controls.PhoneApplicationFrame);

            switch (MainViewModel.Instance.GameMode)
            {
                case GameModes.DownloadDeck:
                    if (phoneApplicationFrame.Source.ToString() != "/Views/DownloadPage.xaml")
                    {
                        phoneApplicationFrame.Navigate(new Uri("/Views/DownloadPage.xaml", UriKind.Relative));
                    }
                    break;

                case GameModes.GameSelect:
                    if (phoneApplicationFrame.Source.ToString() != "/Views/SelectGamePage.xaml")
                    {
                        phoneApplicationFrame.Navigate(new Uri("/Views/SelectGamePage.xaml", UriKind.Relative));
                    }
                    break;

                case GameModes.LearningGame:
                    if (phoneApplicationFrame.Source.ToString() != "/Views/LearningPage.xaml")
                    {
                        phoneApplicationFrame.Navigate(new Uri("/Views/LearningPage.xaml", UriKind.Relative));
                    }
                    break;

                case GameModes.MatchingGame:
                    if (phoneApplicationFrame.Source.ToString() != "/Views/MatchingPage.xaml")
                    {
                        phoneApplicationFrame.Navigate(new Uri("/Views/MatchingPage.xaml", UriKind.Relative));
                    }
                    break;

                case GameModes.MemoryGame:
                    if (phoneApplicationFrame.Source.ToString() != "/Views/MatchingPage.xaml")
                    {
                        phoneApplicationFrame.Navigate(new Uri("/Views/MatchingPage.xaml", UriKind.Relative));
                    }
                    break;
            }
        }
#endif

        private static MainViewModel _instance;
    }
}
