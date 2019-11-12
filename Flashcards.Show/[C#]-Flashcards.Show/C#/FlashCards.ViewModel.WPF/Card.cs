using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using System.Xml.Serialization;
#if !SILVERLIGHT
using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.WindowsAPICodePack.Shell;
using FlashCards.Commands;
#endif

namespace FlashCards.ViewModel
{
    [XmlInclude(typeof(ImageDecal))]
    [XmlInclude(typeof(InfoLinkDecal))]
    [XmlInclude(typeof(TextDecal))]
    [XmlInclude(typeof(TextToSpeechDecal))]
    [XmlInclude(typeof(VideoControlDecal))]
    [XmlInclude(typeof(VideoDecal))]
    [XmlInclude(typeof(AudioMetaData))]
    [XmlInclude(typeof(ImageMetaData))]
    [XmlInclude(typeof(InfoLinkMetaData))]
    [XmlInclude(typeof(TextMetaData))]
    [XmlInclude(typeof(VideoMetaData))]
    public class Card : ViewModelBase
    {
        public Card()
        {
            _isTextPresent = -1;
            _isImagePresent = -1;
            _isVideoPresent = -1;
            _isAudioPresent = -1;
            _isUrlPresent = -1;

            MetaData = new MetaData();

            MetaData.Color = Colors.White;

            _decals = new ObservableCollection<Decal>();

#if !SILVERLIGHT
            AddText = new DelegateCommand(() =>
            {
                TextDecal decal = new TextDecal();
                AddDecal(decal);

                decal.DelaySelect(true);
            }, CanAddText);

            AddImage = new DelegateCommand<string>((path) =>
            {
                ImageDecal Idecal = new ImageDecal();

                CommonOpenFileDialog cfd = new CommonOpenFileDialog((string)Application.Current.FindResource("Resource_SaveDialogTitle_AddImage"));
             
                cfd.EnsureReadOnly = true;

                // Set the initial location as the path of the library
                cfd.InitialDirectoryShellContainer = KnownFolders.PicturesLibrary as ShellContainer;

                if (cfd.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    // Get the selection from the user.
                    ShellObject so = cfd.FileAsShellObject;
                    if(so.ParsingName != null)
                    {
                        ((ImageMetaData)Idecal.MetaData).Source = so.ParsingName;                    
                        AddDecal(Idecal);

                        Idecal.DelaySelect(true);
                    }
                }

            }, CanAddImage);

            AddVideo = new DelegateCommand<string>((path) =>
            {

                CommonOpenFileDialog cfd = new CommonOpenFileDialog((string)Application.Current.FindResource("Resource_SaveDialogTitle_AddVideo"));

                cfd.EnsureReadOnly = true;

                // Set the initial location as the path of the library
                cfd.InitialDirectoryShellContainer = KnownFolders.VideosLibrary as ShellContainer;

                if (cfd.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    // Get the selection from the user.
                    ShellObject so = cfd.FileAsShellObject;
                    if (so.ParsingName != null)
                    {
                        VideoDecal Idecal = new VideoDecal();
                        ((VideoMetaData)Idecal.MetaData).Source = so.ParsingName;
                        AddDecal(Idecal);

                        VideoControlDecal control = new VideoControlDecal(Idecal);

                        Idecal.VideoControl = control;
                        AddDecal(control);

                        Idecal.DelaySelect(true);
                    }
                }

            }, CanAddVideo);

            AddAudio = new DelegateCommand(() =>
            {
                TextToSpeechDecal decal = new TextToSpeechDecal();
                AddDecal(decal);
                decal.DelaySelect(true);
            }, CanAddAudio);

            AddUrl = new DelegateCommand(() =>
            {
                InfoLinkDecal decal = new InfoLinkDecal();
                AddDecal(decal);
                decal.DelaySelect(true);
            }, CanAddUrl);

            RemoveDecal = new DelegateCommand<Decal>((decal) =>
            {
                if (decal == null)
                    decal = SelectedDecal;

                if (decal != null)
                {
                    decal.UnInitialize();
                    DeleteDecal(decal);
                }
            });
#endif
        }

        protected override void OnInitialize()
        {
            foreach (Decal decal in _decals)
            {
                if (decal is TextDecal)
                {
                    _isTextPresent = _decals.Count;
                }
                if (decal is ImageDecal)
                {
                    _isImagePresent = 0;
                }
                if (decal is VideoDecal)
                {
                    _isVideoPresent = 0;
                }
                if (decal is TextToSpeechDecal)
                {
                    _isAudioPresent = _decals.Count;
                }
                if (decal is InfoLinkDecal)
                {
                    _isUrlPresent = _decals.Count;
                }

                if (decal is VideoControlDecal)
                {
                    foreach (Decal d in _decals)
                    {
                        if (d is VideoDecal)
                        {
                            ((VideoControlDecal)decal).VideoDecal = (VideoDecal)d;
                            ((VideoDecal)d).VideoControl = (VideoControlDecal)decal;
                            break;
                        }
                    }
                }

            }
        }

        #region Commands

        [XmlIgnore]
        public ICommand AddText { get; private set; }

        [XmlIgnore]
        public ICommand AddImage { get; private set; }

        [XmlIgnore]
        public ICommand AddVideo { get; private set; }

        [XmlIgnore]
        public ICommand AddAudio { get; private set; }

        [XmlIgnore]
        public ICommand AddUrl { get; private set; }

        [XmlIgnore]
        public ICommand RemoveDecal { get; private set; }

        #endregion

        [XmlIgnore]
        public CardPair ParentCardPair { get; set; }

        public MetaData MetaData { get; set; }

        [XmlIgnore]
        public Decal SelectedDecal
        {
            get
            {
                foreach (Decal d in _decals)
                {
                    if (d.IsSelected)
                        return d;      
                }

                return null;
            }
        }

        [XmlIgnore]
        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    RaisePropertyChanged(@string.of(() => IsActive));
                }

                if(!value)
                   DeSelectAll();
            }
        }
        
        public ObservableCollection<Decal> Decals
        {
            get { return _decals; }
        }

        public void DeSelectAll()
        {
            foreach (Decal d in _decals)
            {
                d.IsSelected = false;
            }

        }

        public void UnInitializeAllDecals()
        {
            foreach (Decal d in _decals)
            {
                d.UnInitialize();
            }

        }

        public bool AddDecal(Decal decal)
        { 
            //Check if the Decal is allowed to add here.

            int count = _decals.Count;


            if (decal is TextDecal)
            {
                _decals.Insert(count,decal);
                _isTextPresent = _decals.Count;
            }
            if (decal is ImageDecal)
            {
                _decals.Insert(0, decal);
                _isImagePresent = 0;
            }
            if (decal is VideoDecal)
            {
                _decals.Insert(0, decal);
                _isVideoPresent = 0;
            }
            if (decal is TextToSpeechDecal)
            {
                _decals.Insert(count, decal);
                _isAudioPresent = _decals.Count;
            }
            if (decal is InfoLinkDecal)
            {
                _decals.Insert(count, decal);
                _isUrlPresent = _decals.Count;
            }
            if (decal is VideoControlDecal)
            {
                _decals.Insert(count, decal);
            }

            return true;
        }

        public void DeleteDecal(Decal decal)
        {
            _decals.Remove(decal);

            if (decal is TextDecal)
            {
                _isTextPresent = -1;
            }
            if (decal is ImageDecal)
            {
                _isImagePresent = -1;
            }
            if (decal is VideoDecal)
            {
                _decals.Remove(((VideoDecal)decal).VideoControl);
                _isVideoPresent = -1;
            }
            if (decal is TextToSpeechDecal)
            {
                _isAudioPresent = -1;
            }
            if (decal is InfoLinkDecal)
            {
                _isUrlPresent = -1;
            }
        }

        public bool IsPair(Card card)
        {
            return (ParentCardPair.Card1 == card || ParentCardPair.Card2 == card) ;
        }

        public bool CanAddText()
        {
            return _isTextPresent == -1;
        }

        public bool CanDeleteDecal()
        {
            return SelectedDecal != null;
        }

        public bool CanAddImage(string path)
        {
            return _isImagePresent == -1 && _isVideoPresent == -1;
        }
        public bool CanAddVideo(string path)
        {
            return _isVideoPresent == -1 && _isAudioPresent == -1 && _isImagePresent == -1;
        }
        public bool CanAddAudio()
        {
            return _isAudioPresent == -1 && _isVideoPresent == -1;
        }
        public bool CanAddUrl()
        {
            return _isUrlPresent == -1;
        }

        private int _isTextPresent;
        private int _isImagePresent;
        private int _isVideoPresent;
        private int _isAudioPresent;
        private int _isUrlPresent;

        private bool _isActive;

        private ObservableCollection<Decal> _decals;
    }
}
