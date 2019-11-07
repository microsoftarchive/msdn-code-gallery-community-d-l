using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace IdentityMine.Avalon.PatientSimulator
{
    public class Waveform
    {
        public string Name;
        public string Data;

        [XmlIgnore]
        public int DataIndex = 0;

        [XmlIgnore]
        public double[] DataPoints;
    }

    [XmlRootAttribute("Root", Namespace = "http://www.identitymine.com", IsNullable = false)]
    public class WaveformData
    {
        public Waveform[] Waveforms;
    }

    public class PatientVitals
    {
        private readonly char[] COMMA_SEPARATOR = new char[] { ',' };
        private Dictionary<string, Waveform> _waveforms = new Dictionary<string,Waveform>();
        private string _filename;

        public PatientVitals(string filename)
        {
            string fileFullName = AppDomain.CurrentDomain.BaseDirectory + filename;
            this.ReadWaveformData(_filename = fileFullName);
        }

        public void CreateWaveformData(string filename)
        {
            // Creates an instance of the XmlSerializer class;
            // specifies the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(WaveformData));
            TextWriter writer = new StreamWriter(filename);
            WaveformData wfd = new WaveformData();

            // Creates an address to ship and bill to.
            Waveform wf = new Waveform();
            wf.Name = "ECG";
            wf.Data = "0.0,1.0,5.0,0.0,3.0,1.0,5.0,5.0,0.0,1.0";

            wfd.Waveforms = new Waveform[] { wf };
           
            // Serializes the waveform data, and closes the TextWriter.
            serializer.Serialize(writer, wfd);
            writer.Close();
        }

        public void ReadWaveformData(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(WaveformData));

            serializer.UnknownNode += new XmlNodeEventHandler(SerializationHelper.UnknownNode);
            serializer.UnknownAttribute += new XmlAttributeEventHandler(SerializationHelper.UnknownAttribute);
         
            FileStream fs = new FileStream(filename, FileMode.Open);

            WaveformData wfd = (WaveformData)serializer.Deserialize(fs);

            // populate our waveform dictionary
            foreach (Waveform wf in wfd.Waveforms)
            {
                string[] data = wf.Data.Split(COMMA_SEPARATOR);
                wf.DataPoints = Array.CreateInstance(typeof(Double), data.Length) as double[];

                int size = 0;
                double result;
                foreach (string point in data)
                {
                    if (Double.TryParse(point, out result))
                        wf.DataPoints[size++] = result;
                }
                
                _waveforms.Add(wf.Name, wf);
            }
        }

        public double GetWaveformData(string waveformName)
        {
            double nextValue = 0.0d;

            Waveform wf = _waveforms[waveformName];
            if (wf != null)
            {
                nextValue = wf.DataPoints[wf.DataIndex++];

                wf.DataIndex = wf.DataIndex % wf.DataPoints.Length;
            }

            return nextValue;
        }
    }
}
