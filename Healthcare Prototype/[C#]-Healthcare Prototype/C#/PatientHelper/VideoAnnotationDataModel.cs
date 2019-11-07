using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Controls;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using System.Windows.Ink;

namespace IdentityMine.Avalon.Controls
{
    public class VideoAnnotationData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public VideoAnnotationData()
        {
            _VideoAnnotationItems = new VideoAnnotationItemCollection();
        }

        #region Properties

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public VideoAnnotationItemCollection VideoAnnotationItems
        {
            get { return _VideoAnnotationItems; }
        }
        #endregion

        private void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private string _Name;
        private VideoAnnotationItemCollection _VideoAnnotationItems;
    }

    public class VideoAnnotationItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
                NotifyPropertyChanged("ID");
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                NotifyPropertyChanged("Description");
            }
        }

        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                NotifyPropertyChanged("Title");
            }
        }

        [XmlIgnore]
        public StrokeCollection Strokes
        {
            get { return _Strokes; }
            set
            {
                _Strokes = value;

                StrokesSerialize = ConvertStrokeCollectionToBase64(_Strokes);
                NotifyPropertyChanged("Strokes");
            }
        }

        public string StrokesSerialize
        {
            get { return _StrokesSerialize; }
            set
            {
                _StrokesSerialize = value;

                if (_Strokes == null)
                {
                    _Strokes = ConvertStrokeCollectionFromBase64(_StrokesSerialize);
                    NotifyPropertyChanged("Strokes");
                }

                NotifyPropertyChanged("StrokesSerialize");
            }
        }

        public double PositionLeft
        {
            get { return _PositionLeft; }
            set
            {
                _PositionLeft = value;
                NotifyPropertyChanged("PositionLeft");
            }
        }

        public double PositionTop
        {
            get { return _PositionTop; }
            set
            {
                _PositionTop = value;
                NotifyPropertyChanged("PositionTop");
            }
        }

        [XmlIgnore]
        public TimeSpan InkTimeSpan
        {
            get { return _InkTimeSpan; }
            set
            {
                _InkTimeSpan = value;
                InkTimeSpanSerialize = _InkTimeSpan.ToString();
                NotifyPropertyChanged("InkTimeSpan");
            }
        }

        public string InkTimeSpanSerialize
        {
            get { return _InkTimeSpanSerialize; }
            set
            {
                _InkTimeSpanSerialize = value;

                _InkTimeSpan = TimeSpan.Parse(_InkTimeSpanSerialize);
                NotifyPropertyChanged("InkTimeSpan");

                NotifyPropertyChanged("InkTimeSpanSerialize");
            }
        }

        private void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        #region Private Methods

        private string ConvertStrokeCollectionToBase64(StrokeCollection sc)
        {

            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                sc.Save(ms);
                return System.Convert.ToBase64String(ms.ToArray());
            }

        }

        private StrokeCollection ConvertStrokeCollectionFromBase64(string scArray)
        {

            byte[] b = System.Convert.FromBase64CharArray(scArray.ToCharArray(), 0, scArray.Length);
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(b))
            {
                return new StrokeCollection(ms);
            }

        }
        #endregion


        private string _ID = "Default ID";
        private string _Title = "Default Title";
        private string _description = "Default Description";
        private StrokeCollection _Strokes;
        private TimeSpan _InkTimeSpan;
        private double _PositionLeft;
        private double _PositionTop;
        private string _StrokesSerialize;
        private string _InkTimeSpanSerialize;
    }

    public class VideoAnnotationItemCollection : ObservableCollection<VideoAnnotationItem>
    {
        public new void Add(VideoAnnotationItem item)
        {
            base.Add(item);
        }

        public new void Remove(VideoAnnotationItem item)
        {
            base.Remove(item);
        }
    }

}



