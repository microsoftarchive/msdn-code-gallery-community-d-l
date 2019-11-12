using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml.Serialization;

namespace FlashCards.ViewModel
{
    public abstract class Decal : ViewModelBase
    {
        public Decal()
        {
            _size = 1.0;
            _center = new Point(0.5, 0.5);
            _pinPoint = new Point(0.5, 0.5);
            _canResize = true;
            _canMove = true;
        }

        public MetaData MetaData { get; set; }

        [XmlAttribute]
        public double Orientation
        {
            get
            {
                return _orientation;
            }
            set
            {
                if (_orientation != value)
                {
                    _orientation = value;
                    RaisePropertyChanged(@string.of(() => Orientation));
                }
            }
        }

        [XmlAttribute]
        public double Size
        {
            get { return _size; }
            set
            {
                if (_size != value)
                {
                    _size = value;
                    RaisePropertyChanged(@string.of(() => Size));
                }
            }
        }

        [XmlIgnore]
        public double MaxSize
        {
            get
            {
                return _maxsize;
            }
            set
            {
                if (_maxsize != value)
                {
                    _maxsize = value;
                    RaisePropertyChanged(@string.of(() => MaxSize));
                }

            }
        }

        [XmlIgnore]
        public double MinSize
        {
            get
            {
                return _minsize;
            }
            set
            {
                if (_minsize != value)
                {
                    _minsize = value;
                    RaisePropertyChanged(@string.of(() => MinSize));
                }

            }
        }

        public Point Center
        {
            get
            {
                return _center;
            }
            set
            {
                if (_center != value)
                {
                    _center = value;
                    RaisePropertyChanged(@string.of(() => Center));
                }
            }
        }

        [XmlIgnore]
        public Point PinPoint
        {
            get
            {
                return _pinPoint;
            }
            set
            {
                if (_pinPoint != value)
                {
                    _pinPoint = value;
                    RaisePropertyChanged(@string.of(() => PinPoint));
                }
            }
        }

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


                    if (value)
                        OnSelected();
                    else
                        OnUnSelected();

                    RaisePropertyChanged(@string.of(() => IsSelected));
                }
            }
        }

        [XmlIgnore]
        public bool CanResize
        {
            get
            {
                return _canResize;
            }
            set
            {
                if (_canResize != value)
                {
                    _canResize = value;
                    RaisePropertyChanged(@string.of(() => CanResize));
                }
            }
        }

        [XmlIgnore]
        public bool CanMove
        {
            get
            {
                return _canMove;
            }
            set
            {
                if (_canMove != value)
                {
                    _canMove = value;
                    RaisePropertyChanged(@string.of(() => CanMove));
                }
            }
        }

        [XmlIgnore]
        public Stretch Stretch
        {
            get
            {
                return _stretch;
            }
            set
            {
                if (_stretch != value)
                {
                    _stretch = value;
                    RaisePropertyChanged(@string.of(() => Stretch));
                }
            }
        }

#if SILVERLIGHT
        [XmlIgnore]
        public bool IsImageDecal
        {
            get
            {
                return this is ImageDecal;
            }
        }

        [XmlIgnore]
        public bool IsTextDecal
        {
            get
            {
                return this is TextDecal;
            }
        }

        [XmlIgnore]
        public bool IsInfoLinkDecal
        {
            get
            {
                return this is InfoLinkDecal;
            }
        }

        [XmlIgnore]
        public bool IsVideoControlDecal
        {
            get
            {
                return this is VideoControlDecal;
            }
        }

        [XmlIgnore]
        public bool IsVideoDecal
        {
            get
            {
                return this is VideoDecal;
            }
        }

#endif

        protected virtual void OnSelected()
        {

        }

        protected virtual void OnUnSelected()
        {

        }

        internal void DelaySelect(bool value)
        {
            DispatcherTimer _timer = new DispatcherTimer();

            _timer.Interval = TimeSpan.FromMilliseconds(50); //Just waiting to Sync any animation in the View

            _timer.Tick += new EventHandler(delegate(object s, EventArgs ev)
            {
                IsSelected = value;
                _timer.Stop();

            });

            _timer.Start();
        }

        private double _orientation;
        private double _size;
        private double _minsize;
        private double _maxsize;
        private bool _isSelected;
        private bool _canResize;
        private bool _canMove;
        private Point _pinPoint;
        private Stretch _stretch;
        private Point _center;
    }
}
