using System.ComponentModel;
using System.Windows.Input;
using System.Xml.Serialization;
using FlashCards.Commands;

namespace FlashCards.ViewModel
{
    public class VideoControlDecal : Decal
    {
        public VideoControlDecal()
        {
            CanResize = false;
            Stretch = System.Windows.Media.Stretch.None;
            Center = new System.Windows.Point(0.5, 1);
            PinPoint = new System.Windows.Point(0.5, 1);
            CanMove = false;

            Play = new DelegateCommand(() =>
            {
                IsPlay = !IsPlay;
            });
        }

        public VideoControlDecal(VideoDecal video)
        {
            CanResize = false;
            Stretch = System.Windows.Media.Stretch.None;
            Center = new System.Windows.Point(0.5,1);
            PinPoint = new System.Windows.Point(0.5,1);
            CanMove = false;

            VideoDecal = video;

            Play = new DelegateCommand(() =>
            {
                IsPlay = !IsPlay;
            });
        }

        [XmlIgnore]
        public bool IsPlay
        {
            get
            {
                return _isPlay;
            }
            set
            {
                if (_isPlay != value)
                {
                    _isPlay = value;
                    RaisePropertyChanged(@string.of(() => IsPlay));
                }
            }
        }

        [XmlIgnore]
        public ICommand Play { get; private set; }

        [XmlIgnore]
        public VideoDecal VideoDecal
        {
            get
            {
                return _videoDecal;
            }
            set
            {
                if (_videoDecal != value)
                {
                    _videoDecal = value;
                    RaisePropertyChanged(@string.of(() => VideoDecal));
                }
            }
        }

        private bool _isPlay;
        private VideoDecal _videoDecal;
    }
}
