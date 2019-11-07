using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace FlashCards.ViewModel
{
    public class VideoDecal : Decal
    {
        public VideoDecal()
        {
            MetaData = new VideoMetaData();

            Stretch = System.Windows.Media.Stretch.Uniform;
        }

        [XmlIgnore]
        public VideoControlDecal VideoControl { get; set; }

        public TimeSpan Position
        {
            get
            {
                return _position;
            }
            set
            {
                if (_position != value)
                {
                    _position = value;
                    RaisePropertyChanged(@string.of(() => Position));
                }
            }
        }

        private TimeSpan _position;
    }
}
