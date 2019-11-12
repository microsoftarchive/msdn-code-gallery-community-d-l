using System.Xml.Serialization;

namespace FlashCards.ViewModel
{
    public class InfoLinkMetaData : MetaData
    {
        [XmlAttribute]
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                RaisePropertyChanged(@string.of(() => Title));
            }
        }

        private string _title;
    }
}
