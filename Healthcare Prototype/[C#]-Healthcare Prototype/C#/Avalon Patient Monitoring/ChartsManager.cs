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
using IdentityMine.Avalon.PatientSimulator;
using IdentityMine.Avalon.Controls;

namespace Avalon_Patient_Monitoring
{
    #region Public Enums

    public enum Charts
    {
        ECGSinusRhythm,
        ECGJunctionalTachy,
        ECGAcceleratedIVR,
        Pulse,
        O2Saturation
    }

    #endregion

    public class ChartsManager
    {
        public ChartsManager(object fe)
        {
            baseFrameworkElement = fe as FrameworkElement;

            if (baseFrameworkElement == null)
                return;


            // setup the dataobjects
            for (int i = 1; i <= 5; i++)
                series[i - 1] = (ObjectDataProvider)baseFrameworkElement.FindResource(String.Format("Series{0}DSO", i.ToString()));

            // create Chart Visuals
            _chartVisuals = (ChartVisuals)baseFrameworkElement.FindResource("ChartVisuals");

            CreateChartVisual("ECGSinusRhythm", "ECGSinusRhythmChartVisualBrush");
            CreateChartVisual("ECGJunctionalTachy", "ECGJunctionalTachyChartVisualBrush");
            CreateChartVisual("ECGAcceleratedIVR", "ECGAcceleratedIVRChartVisualBrush");
            CreateChartVisual("Pulse", "PulseChartVisualBrush");
            CreateChartVisual("O2Saturation", "O2SaturationChartVisualBrush");
        }

        #region Events

        #region Chart Events

        void OnECGSinusRhythmChartEnded(object sender, EventArgs e)
        {
            seriesItems[0].AddValue(patientVitals.GetWaveformData("ECGSinusRhythm"));
        }

        void OnECGJunctionalTachyChartEnded(object sender, EventArgs e)
        {
            seriesItems[1].AddValue(patientVitals.GetWaveformData("ECGJunctionalTachy"));
        }

        void OnECGAcceleratedIVRChartEnded(object sender, EventArgs e)
        {
            seriesItems[2].AddValue(patientVitals.GetWaveformData("ECGAcceleratedIVR"));
        }

        void OnPulseChartEnded(object sender, EventArgs e)
        {
            seriesItems[3].AddValue(patientVitals.GetWaveformData("Pulse"));
        }

        void OnO2SaturationChartEnded(object sender, EventArgs e)
        {
            seriesItems[4].AddValue(patientVitals.GetWaveformData("O2Saturation"));
        }

        #endregion

        #endregion

        #region Public Methods

        public void Load()
        {
            if (baseFrameworkElement == null)
                return;

            patientVitals = new PatientVitals("WaveformData.xml");

            // get series data

            for (int i = 0; i < series.Length; i++)
                seriesItems[i] = (SeriesDataItems)series[i].Data;

            seriesItems[0].AddValue(patientVitals.GetWaveformData("ECGSinusRhythm"));
            seriesItems[1].AddValue(patientVitals.GetWaveformData("ECGJunctionalTachy"));
            seriesItems[2].AddValue(patientVitals.GetWaveformData("ECGAcceleratedIVR"));
            seriesItems[3].AddValue(patientVitals.GetWaveformData("Pulse"));
            seriesItems[4].AddValue(patientVitals.GetWaveformData("O2Saturation"));
        }

        public Brush GetChartBrush(string chart)
        {
            if ((chart == null) || (chart.Length == 0))
                return null;

            VisualBrush vb = _chartVisuals[chart];
            return vb;
        }

        #endregion

        #region Private Methods

        private void CreateChartVisual(string id, string resource)
        {
            if ((_chartVisuals == null) || (baseFrameworkElement == null))
                return;

            VisualBrush vb = (VisualBrush)baseFrameworkElement.FindResource(resource);
            Chart chart = Chart.FindChart(vb.Visual) as Chart;

            if (chart == null)
                return;

            switch (id)
            {
                case "ECGSinusRhythm":
                    chart.UpdateIntervalEnded += new Chart.UpdateIntervalEndedEventHandler(OnECGSinusRhythmChartEnded);
                    break;
                case "ECGJunctionalTachy":
                    chart.UpdateIntervalEnded += new Chart.UpdateIntervalEndedEventHandler(OnECGJunctionalTachyChartEnded);
                    break;
                case "ECGAcceleratedIVR":
                    chart.UpdateIntervalEnded += new Chart.UpdateIntervalEndedEventHandler(OnECGAcceleratedIVRChartEnded);
                    break;
                case "Pulse":
                    chart.UpdateIntervalEnded += new Chart.UpdateIntervalEndedEventHandler(OnPulseChartEnded);
                    break;
                case "O2Saturation":
                    chart.UpdateIntervalEnded += new Chart.UpdateIntervalEndedEventHandler(OnO2SaturationChartEnded);
                    break;
            }

            _chartVisuals.Add(id, vb);
        }

        #endregion

        #region Globals

        FrameworkElement baseFrameworkElement;
        private Dictionary<string, VisualBrush> _chartVisuals;
        PatientVitals patientVitals;
        private SeriesDataItems[] seriesItems = new SeriesDataItems[5];
        private ObjectDataProvider[] series = new ObjectDataProvider[5];

        #endregion
    }
}
