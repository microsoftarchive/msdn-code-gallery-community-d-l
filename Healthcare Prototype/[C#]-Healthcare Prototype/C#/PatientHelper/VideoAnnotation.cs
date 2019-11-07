using System;
using System.ComponentModel;
using System.Windows.Data;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Threading;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Ink;

namespace IdentityMine.Avalon.Controls
{
    public class VideoAnnotation
    {
        public VideoAnnotation()
        {
        }

        #region EventHandlers

        public delegate void SelectedEventHandler(object sender, EventArgs e);

        public event SelectedEventHandler CheckoutDetachComplete;
        protected virtual void OnCheckoutDetachComplete(object o, EventArgs e)
        {
            if (CheckoutDetachComplete != null)
                CheckoutDetachComplete(o, e);
        }

        #endregion

        #region Properties

        #region Data

        VideoAnnotationData _Data;
        public VideoAnnotationData Data
        {
            get { return _Data; }
            set { _Data = value; }
        }

        #endregion Data

        #endregion Properties

        #region Public

        public void Add(StrokeCollection strokes, string id, string text, TimeSpan time, Point pt)
        {
            if ((strokes == null) || (Data == null) || (id == null) || (id.Length == 0) || (time == null) || (pt == null))
                return;

            AddItem(Data.VideoAnnotationItems, strokes, id, text, time, pt);
        }

        public void Remove(string id)
        {
            if ((id == null) || (id.Length == 0) || (Data == null))
                return;

            RemoveItem(Data.VideoAnnotationItems, id);
        }

        public VideoAnnotationItem FindAnnotation(TimeSpan time)
        {
            if ((time == null) || (Data == null))
                return null;

            VideoAnnotationItem sci = FindVideoAnnotationItemTimeSpan(Data.VideoAnnotationItems, time);
            return sci;
        }

        public void CheckOut()
        {
        }

        public void ExportToFile(string xmlFile)
        {
            if ((xmlFile == null) || (xmlFile.Length == 0))
                return;

            try
            {
                if (File.Exists(xmlFile) == true)
                    File.Delete(xmlFile);

                Stream fs = new FileStream(xmlFile, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
                XmlTextWriter writer = new XmlTextWriter(fs, Encoding.UTF8);

                // Make the XML output pretty
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();

                //writer.WriteFromObject(Data);
                (new XmlSerializer(typeof(VideoAnnotationData))).Serialize(writer, Data);

                writer.Flush();
                writer.Close();
                fs.Close();
            }
            catch (System.IO.IOException)
            {

            }
            catch (System.Security.SecurityException)
            {

            }
        }

        public void ImportFromFile(string xmlFile)
        {
            if ((xmlFile == null) || (xmlFile.Length == 0))
                return;

            if (File.Exists(xmlFile) == false)
                return;

            try
            {
                Stream fs = new FileStream(xmlFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                XmlTextReader reader = new XmlTextReader(fs);
                reader.WhitespaceHandling = WhitespaceHandling.Significant;

                reader.Read(); // advance to <xml> tag
                reader.Read(); // advance to <VideoAnnotationData> tag

                //writer.WriteFromObject(Data);
                Data = (new XmlSerializer(typeof(VideoAnnotationData))).Deserialize(reader) as VideoAnnotationData;

                reader.Close();
                fs.Close();
            }
            catch (System.IO.IOException)
            {

            }
            catch (System.Security.SecurityException)
            {

            }
        }

        #endregion Public

        #region Private

        private void AddItem(VideoAnnotationItemCollection scic, StrokeCollection strokes, string id, string text, TimeSpan time, Point pt)
        {
            VideoAnnotationItem sci = new VideoAnnotationItem();

            sci.ID = id;
            sci.Title = id;
            sci.Description = text;
            sci.Strokes = strokes;
            sci.InkTimeSpan = time;
            sci.PositionLeft = pt.X;
            sci.PositionTop = pt.Y;

            scic.Add(sci);
        }

        private void RemoveItem(VideoAnnotationItemCollection scic, string id)
        {
            if ((id == null) || (Data == null))
                return;

            VideoAnnotationItem sci = FindVideoAnnotationItem(scic, id);

            if (sci != null)
            {
                scic.Remove(sci);
            }
        }

        private VideoAnnotationItem FindVideoAnnotationItem(VideoAnnotationItemCollection scic, string id)
        {
            VideoAnnotationItem sciRet = null;

            foreach (VideoAnnotationItem sci in scic)
            {
                if (sci.ID == id)
                {
                    sciRet = sci;
                    break;
                }
            }

            return sciRet;
        }

        private VideoAnnotationItem FindVideoAnnotationItemTimeSpan(VideoAnnotationItemCollection scic, TimeSpan time)
        {
            VideoAnnotationItem sciRet = null;

            foreach (VideoAnnotationItem sci in scic)
            {
                if ((int)sci.InkTimeSpan.TotalSeconds == (int)time.TotalSeconds)
                {
                    sciRet = sci;
                    break;
                }
            }

            return sciRet;
        }

        #endregion Private
    }
}
