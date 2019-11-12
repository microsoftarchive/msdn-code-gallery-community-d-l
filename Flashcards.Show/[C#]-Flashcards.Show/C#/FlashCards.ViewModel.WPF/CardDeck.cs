using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Xml;
using System.Xml.Serialization;
using FlashCards.Commands;
#if !SILVERLIGHT
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Diagnostics;
using System.Reflection;
#endif

namespace FlashCards.ViewModel
{
    public class CardDeck : ViewModelBase
    {


        protected override void OnInitialize()
        {
            Count = _cardPairs.Count;

            foreach (CardPair pair in Collection)
            {
                foreach (Decal dec in pair.Card1.Decals)
                {
                    if (dec is ImageDecal || dec is VideoDecal)
                    {
                        dec.MetaData.Source = AddRootPath(dec.MetaData.DisplaySource);
                    }
                }
                foreach (Decal dec in pair.Card2.Decals)
                {
                    if (dec is ImageDecal || dec is VideoDecal)
                    {
                        dec.MetaData.Source = AddRootPath(dec.MetaData.DisplaySource);
                    }
                }
            }

            if (!string.IsNullOrEmpty(DisplayCoverSource))
            {
                CoverImageSource = AddRootPath(DisplayCoverSource);
            }

        }

        public CardDeck()
        {
            _cardPairs = new ObservableCollection<CardPair>();

#if !SILVERLIGHT
            CreateNewCardPair = new DelegateCommand(() =>
            {
                CardPair cp = new CardPair() { IsInEdit = true , Card1 = new Card() , Card2 = new Card() ,ParentDeck = this ,IsSelected = true};
                cp.Initialize();
                _cardPairs.Add(cp);
                SelectedCardPair = cp;
                IsDirty = true;
            });

            EditDeck = new DelegateCommand(() =>
            {
                MainViewModel.Instance.CurrentView = this;
                Taskbar.AddEntryToJumpList(ZipPath, Title);
            });

            CancelCommand = new DelegateCommand(CancelEdit);

            DeleteDeck = new DelegateCommand(DeleteTheDeck);

            SaveDeck = new DelegateCommand(() =>
            { 
                SaveTheDeck();
            });

            ShareDeck = new DelegateCommand(() =>
            {
                if (ShareClicked != null)
                {
                    ShareClicked(this, EventArgs.Empty);
                }
            });
#endif
            ShowHelp = new DelegateCommand(() =>
            {
                MessageBox.Show((string)Application.Current.Resources["Resource_MessageBox_ShowHelp"]);
            });


            LearningGame = new DelegateCommand(() =>
            {
#if !WINDOWS_PHONE
                LearningGameViewModel game = new LearningGameViewModel(this);
                MainViewModel.Instance.CurrentView = game;
#else
                MainViewModel.Instance.GameMode = GameModes.LearningGame;
#endif

#if !SILVERLIGHT
                Taskbar.AddEntryToJumpList(ZipPath, Title);
#endif
                this.IsSelected = false;
            }, () => { return Count > 0; });

            MatchingGame = new DelegateCommand(() =>
            {
#if !WINDOWS_PHONE
                MatchingGameViewModel game = new MatchingGameViewModel(this, true);
                MainViewModel.Instance.CurrentView = game;
#else 
                MainViewModel.Instance.GameMode = GameModes.MatchingGame;
#endif
#if !SILVERLIGHT
                Taskbar.AddEntryToJumpList(ZipPath, Title);
#endif
                this.IsSelected = false;
            }, () => { return Count >= 6; });

            MemoryGame = new DelegateCommand(() =>
            {
#if !WINDOWS_PHONE
                MatchingGameViewModel game = new MatchingGameViewModel(this ,false);
                MainViewModel.Instance.CurrentView = game;
#else
                MainViewModel.Instance.GameMode = GameModes.MemoryGame;
#endif

#if !SILVERLIGHT
                Taskbar.AddEntryToJumpList(ZipPath, Title);
#endif
                this.IsSelected = false;
            }, () => { return Count >= 6; });
        }

        private string AddRootPath(string filename)
        {
            return Path.Combine(RootPath, filename);
        }

#if !SILVERLIGHT

        public event EventHandler ShareClicked;

        private void CancelEdit()
        {
            if (IsDirty || this.IsAnyDecalcDirty())
            {
                TaskDialog dlg = new TaskDialog()
                {
                    Caption = (string)Application.Current.FindResource("Resource_MessageBox_CancelEditCaption1") + Title + (string)Application.Current.FindResource("Resource_MessageBox_CancelEditCaption2"),
                    Text = (string)Application.Current.FindResource("Resource_MessageBox_CancelEditText"),
                    Icon = TaskDialogStandardIcon.Warning,
                    Cancelable = true,
                    StandardButtons = TaskDialogStandardButtons.Yes | TaskDialogStandardButtons.No | TaskDialogStandardButtons.Cancel
                };

                switch (dlg.Show())
                {
                    case TaskDialogResult.Yes:

                        SaveTheDeck();
                        MainViewModel.Instance.CurrentView = MainViewModel.Instance.Decks;
                        break;

                    case TaskDialogResult.No:
                        // reload deck
                        MainViewModel.Instance.LoadUnzippedDeck(ZipPath, RootPath);
                        MainViewModel.Instance.CurrentView = MainViewModel.Instance.Decks;
                        break;

                    case TaskDialogResult.Cancel:

                        break;
                }
            }
            else
            {
                MainViewModel.Instance.CurrentView = MainViewModel.Instance.Decks;
            }

        }
#endif

        private bool IsAnyDecalcDirty()
        {
            return false;
        }

#if !SILVERLIGHT
        private void DeleteTheDeck()
        {
               TaskDialog dlg = new TaskDialog()
                {
                    Caption = (string)Application.Current.FindResource("Resource_MessageBox_DeleteDeckCaption") + " " + Title,
                    Text = (string)Application.Current.FindResource("Resource_MessageBox_DeleteDeckText"),
                    Icon = TaskDialogStandardIcon.Warning,
                    Cancelable = true,
                    StandardButtons = TaskDialogStandardButtons.Yes | TaskDialogStandardButtons.No
                };

               if (dlg.Show() == TaskDialogResult.Yes)
               {
                   this.IsSelected = false;
                   string deckGuid = this.DeckGUID;
                   DispatcherTimer _timer = new DispatcherTimer();

                   _timer.Interval = TimeSpan.FromMilliseconds(MainViewModel.DeleteDelay); //Just waiting to Sync any animation in the View

                   _timer.Tick += new EventHandler(delegate(object s, EventArgs ev)
                   {

                       if (MainViewModel.Instance.Decks.Collection.Contains(this))
                       {
                           MainViewModel.Instance.Decks.Collection.Remove(this);
                       }

                       _timer.Stop();

                   });

                   _timer.Start();

                   Count = _cardPairs.Count;

                   Directory.Delete(Path.GetDirectoryName(RootPath), true);
                   Directory.Delete(Path.GetDirectoryName(ZipPath), true);
                   Taskbar.RemoveEntryFromJumpList(ZipPath);
               }
        }
#endif

#if !SILVERLIGHT
        /// <summary>
        /// Saving to Disk , this fucntion needs to be Async and have a Status Datatrigger for View animation.
        /// </summary>
        private void SaveTheDeck()
        {
            IsBusy = true;

            try
            {
                GenerateRootPath();

                CreatedTime = DateTime.Now;
                CreatedBy = Environment.UserName;

                List<CardPair> _pairs = Collection.ToList();

                foreach (CardPair pair in _pairs)
                {
                    if (pair.IsDeleted)
                    {
                        Collection.Remove(pair);
                        continue;
                    }
                }
                
                foreach (CardPair pair in Collection)
                {
                    CopyResources(pair.Card1);
                    CopyResources(pair.Card2);
                }
           
                string path = RootPath + "\\deck.xml";

   
                File.Delete(path);

                FileStream fs = File.Create(path);

                XmlSerializer SerializerObj = new XmlSerializer(typeof(CardDeck));
                SerializerObj.Serialize(fs, this);

                fs.Close();

                if (!MainViewModel.Instance.Decks.Collection.Contains(this))
                {
                    MainViewModel.Instance.Decks.Collection.Add(this);
                }

                Taskbar.AddEntryToJumpList(ZipPath, Title);

                DeckPackagingHelper.PackageDeck(RootPath, Title);
            }
            catch (Exception e)
            {
                Utils.LogException(MethodBase.GetCurrentMethod(), e);

                //There are some problem Saving the Deck..
                IsBusy = false;
            }

            IsBusy = false;
            IsDirty = false;

            Count = _cardPairs.Count;
        }

        public void SetCover(System.Windows.Media.Visual visualCover)
        {
            GenerateRootPath();

            RenderTargetBitmap bmp = new RenderTargetBitmap(400, 400, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(visualCover);
            PngBitmapEncoder png = new PngBitmapEncoder();
            png.Frames.Add(BitmapFrame.Create(bmp));

            string fileName = Guid.NewGuid().ToString()+".png";
            
            string path = RootPath + "\\" +  fileName;           

            using (Stream stm = File.Create(path))
            {
                png.Save(stm);
            }

            CoverImageSource = path;
            DisplayCoverSource = fileName;
        }

        private void GenerateRootPath()
        {
            if (string.IsNullOrEmpty(RootPath))
            {
                string newGUID = Guid.NewGuid().ToString();
                RootPath = Path.Combine(DeckFileHelper.ApplicationTempPath, newGUID);
                Directory.CreateDirectory(RootPath);
                DeckGUID = newGUID;
            }
        }

        private void CopyResources(Card card)
        {
            foreach (Decal dec in card.Decals)
            {
                if (dec is VideoDecal || dec is ImageDecal)
                {
                    try
                    {
                        string fileName = Path.GetFileName(dec.MetaData.Source);

                        string newFile = Path.Combine(RootPath, fileName);

                        if (dec.MetaData.Source == newFile)
                            continue;

                        if (File.Exists(newFile))
                        {
                            File.Delete(newFile);
                        }

                        File.Copy(dec.MetaData.Source, newFile);

                        dec.MetaData.Source = newFile;
                        dec.MetaData.DisplaySource = fileName;

                    }
                    catch (Exception e)
                    {
                        Utils.LogException(MethodBase.GetCurrentMethod(), e);

                        //There are some problem Saving the Deck..
                        IsBusy = false;
                    }
                }
            }

        }
#endif

        [XmlIgnore]
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    RaisePropertyChanged(@string.of(() => IsSelected));
                }
            }
        }

        [XmlIgnore]
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

        [XmlIgnore]
        public string CoverImageSource
        {
            get
            {
                return _coverImage;
            }
            set
            {
                _coverImage = value;
                RaisePropertyChanged(@string.of(() => CoverImageSource));
            }
        }

        [XmlAttribute]
        public string DisplayCoverSource
        {
            get
            {
                return _displayCoverSource;
            }
            set
            {
                _displayCoverSource = value;
                RaisePropertyChanged(@string.of(() => DisplayCoverSource));
            }
        }

#if !SILVERLIGHT
        [XmlIgnore]
        public bool IsAdmin
        {
            get
            {
                return MainViewModel.Instance.IsAdmin;
            }
        }
#endif

        [XmlAttribute]
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged(@string.of(() => Title));
            }
        }

        [XmlAttribute]
        public string DeckGUID
        {
            get { return _deckGUID; }
            set
            {
                _deckGUID = value;

                RaisePropertyChanged(@string.of(() => DeckGUID));
            }
        }

        [XmlIgnore]
        public bool IsDirty 
        {
            get
            {
                return _isDirty;
            }
            set
            {
                _isDirty = value;
            }
        }

        [XmlAttribute]
        public string CreatedBy
        {
            get { return _createdBy; }
            set
            {
                _createdBy = value;
                RaisePropertyChanged(@string.of(() => CreatedBy));
            }
        }

        [XmlAttribute]
        public DateTime CreatedTime
        {
            get { return _createdTime; }
            set
            {
                _createdTime = value;
                RaisePropertyChanged("CreatedTime");
            }
        }

        [XmlIgnore]
        public CardPair SelectedCardPair
        {
            get { return _selectedCard; }
            set {
                if (value != _selectedCard)
                {
                    if (_selectedCard != null)
                    {
                        _selectedCard.DeActivate();
                        _selectedCard.ActiveCard.IsActive = true;
                    }
                    _selectedCard = value;
                    if (value != null)
                    {
                        _selectedCard.ActiveCard.IsActive = true;
                    }
                    RaisePropertyChanged(@string.of(() => SelectedCardPair));
                }
            }
        }

        [XmlIgnore]
        public string ZipPath
        {
            get { return _zipPath; }
            set { _zipPath = value; }
        }

        [XmlIgnore]
        public string RootPath 
        {
            get { return _rootPath; }
            set { _rootPath = value; }
        }


        [XmlIgnore]
        public int Count
        {
            get { return _count*2; }
            set { 
                _count = value;
                RaisePropertyChanged(@string.of(() => Count)); 
            }
        }

        public ObservableCollection<CardPair> Collection
        {
            get
            {
                return _cardPairs;
            }
        }

        [XmlIgnore]
        public ICommand CreateNewCardPair { get; private set; }

        [XmlIgnore]
        public ICommand SaveDeck { get; private set; }

        [XmlIgnore]
        public ICommand ShareDeck { get; private set; }

        [XmlIgnore]
        public ICommand EditDeck { get; private set; }

        [XmlIgnore]
        public ICommand DeleteDeck { get; private set; }

        [XmlIgnore]
        public ICommand ShowHelp { get; private set; }

        [XmlIgnore]
        public ICommand CancelCommand { get; private set; }

        [XmlIgnore]
        public ICommand LearningGame { get; private set; }

        [XmlIgnore]
        public ICommand MatchingGame { get; private set; }

        [XmlIgnore]
        public ICommand MemoryGame { get; private set; }

        private string _title;
        private string _displayCoverSource;
        private DateTime _createdTime;
        private string _createdBy;
        private ObservableCollection<CardPair> _cardPairs;
        private string _deckGUID = string.Empty;

        private string _zipPath;
        private string _rootPath;
        private string _coverImage;
        private bool _isSelected;
        private bool _isBusy;
        private bool _isDirty;
        private int _count;
        private CardPair _selectedCard;
    }
}
