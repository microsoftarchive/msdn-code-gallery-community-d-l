using System.Windows.Media;
using System.Xml.Serialization;

namespace FlashCards.ViewModel
{
    public class MetaData : ViewModelBase
    {
        public MetaData()
        {
            _color = Colors.Black;
        }

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                _colorBrush = null;
                RaisePropertyChanged(@string.of(() => Color));
                RaisePropertyChanged(@string.of(() => ColorBrush));
            }
        }

        [XmlIgnore]
        public Brush ColorBrush
        { 
            get
            {
                if (_colorBrush == null)
                {
                    _colorBrush = new SolidColorBrush(_color);
                }
                return _colorBrush;
            }
            set
            {
                _colorBrush = value;
                RaisePropertyChanged(@string.of(() => ColorBrush));
            }
        }

        [XmlAttribute]
        public string Source
        {
            get
            {
                return _Source;
            }
            set
            {
                _Source = value;
                RaisePropertyChanged(@string.of(() => Source));
            }
        }

        [XmlAttribute]
        public string DisplaySource { get; set; }
        
        private string _Source;
        private Brush _colorBrush;
        private Color _color;
    }
}
