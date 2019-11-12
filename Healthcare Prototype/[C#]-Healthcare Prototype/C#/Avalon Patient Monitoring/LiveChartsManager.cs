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
using System.Windows.Documents;
using System.Windows.Media.Animation;

namespace Avalon_Patient_Monitoring
{
    public class LiveChartsManager
    {
        public LiveChartsManager(object fe, ChartsManager cm)
        {
            baseFrameworkElement = fe as FrameworkElement;
            chartsManager = cm;
        }

        #region Public Methods

        public void Load()
        {
            if (baseFrameworkElement == null)
                return;

            ControlTemplate ct;
            ContentControl cc;

            ct = (ControlTemplate)baseFrameworkElement.FindResource("PatientDetailLiveMonitorsTemplate");
            cc = (ContentControl)baseFrameworkElement.FindName("PatientDetailLiveMonitorsContent");
            ListBox listBoxLiveCharts = ct.FindName("LiveChartsListBox", cc) as ListBox;

            ct = (ControlTemplate)baseFrameworkElement.FindResource("PatientDetailSelectorTemplate");
            cc = (ContentControl)baseFrameworkElement.FindName("PatientDetailSelectorContent");
            ListBox listBoxLiveMonitorsSelector = ct.FindName("LiveMonitorsSelectorListBox", cc) as ListBox;

            listBoxLiveMonitorsSelector.MouseMove += new MouseEventHandler(listBoxLiveMonitorsSelector_MouseMove);
            listBoxLiveCharts.MouseMove += new MouseEventHandler(listBoxLiveCharts_MouseMove);


            listBoxLiveCharts.Drop += new DragEventHandler(listBoxLiveCharts_Drop);
            listBoxLiveCharts.KeyUp += new KeyEventHandler(listBoxLiveCharts_KeyUp);
            listBoxLiveCharts.PreviewDragEnter += new DragEventHandler(listBoxLiveCharts_PreviewDragEnter);
            listBoxLiveCharts.PreviewDragOver += new DragEventHandler(listBoxLiveCharts_PreviewDragOver);
            listBoxLiveCharts.PreviewDragLeave += new DragEventHandler(listBoxLiveCharts_PreviewDragLeave);

        }

        public void AddChart(string chart)
        {
            ControlTemplate ct;
            ContentControl cc;

            ct = (ControlTemplate)baseFrameworkElement.FindResource("PatientDetailLiveMonitorsTemplate");
            cc = (ContentControl)baseFrameworkElement.FindName("PatientDetailLiveMonitorsContent");
            ListBox listBoxLiveCharts = ct.FindName("LiveChartsListBox", cc) as ListBox;

            if (listBoxLiveCharts == null)
                return;

            listBoxLiveCharts.SetBinding(ListBox.ItemsSourceProperty, "chart[. = 'empty']");

            string xPath = CreateXPathBinding(chart, listBoxLiveCharts);

            Binding myBinding = new Binding();
            myBinding.Mode = BindingMode.OneTime;
            if ((xPath == null) || (xPath.Length == 0))
                return;

            myBinding.XPath = xPath;
            listBoxLiveCharts.SetBinding(ListBox.ItemsSourceProperty, myBinding);

        }

        #endregion

        #region Events

        void listBoxLiveCharts_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Delete)
                return;

            ListBox lb = sender as ListBox;
            if (lb == null)
                return;

            // Find the chart name from the selected item
            XmlElement xe = lb.SelectedItem as XmlElement;
            if ((xe == null) || (xe.InnerText == null) || (xe.InnerText.Length == 0))
                return;

            Binding myBinding = new Binding();
            myBinding.Mode = BindingMode.OneTime;
            string xPath = RemoveXPathBinding(xe.InnerText, lb);

            if ((xPath == null) || (xPath.Length == 0))
                return;

            myBinding.XPath = xPath;
            lb.SetBinding(ListBox.ItemsSourceProperty, myBinding);
        }

        void listBoxLiveCharts_PreviewDragEnter(object sender, DragEventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (lb == null)
                return;

            // Since Enter\Leave event are fired when the mouse moves over embedded controls, we only want to create an overlay if the mouse was outside the element before the enter event is fired.
            if (_dragEnter == false)
            {
                XmlElement xe = (XmlElement)e.Data.GetData("XmlElement");
                Brush brush = chartsManager.GetChartBrush(xe.InnerText);

                _overlayElement = new RectangleBrushAdorner(lb, brush);
                AdornerLayer layer = AdornerLayer.GetAdornerLayer(lb);
                layer.Add(_overlayElement);

                Point _currentPosition = e.GetPosition(lb);
                _overlayElement.LeftOffset = _currentPosition.X;
                _overlayElement.TopOffset = _currentPosition.Y;

                _dragEnter = true;
            }

            e.Handled = true;
        }
        void listBoxLiveCharts_PreviewDragOver(object sender, DragEventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (lb == null)
                return;

            Point _currentPosition = e.GetPosition(lb);
            _overlayElement.LeftOffset = _currentPosition.X;
            _overlayElement.TopOffset = _currentPosition.Y;

            e.Handled = true;
        }
        void listBoxLiveCharts_PreviewDragLeave(object sender, DragEventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (lb == null)
                return;

            // if we are still inside the Element, we have not left. This can occur when other controls are within the Element. 
            // A leave and enter event is fired when the mouse moves over embedded controls, and we only want to remove the adorner when the mouse is outside the element.
            Point pt = e.GetPosition(lb);
            if ((pt.X > 0) && (pt.Y > 0) && (pt.X < lb.Width) && (pt.Y < lb.Height))
                return;

            _overlayElement.ClearAnimations();
            AdornerLayer.GetAdornerLayer(lb).Remove(_overlayElement);
            _overlayElement = null;
            _dragEnter = false;

            e.Handled = true;
        }


        void listBoxLiveCharts_Drop(object sender, DragEventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (lb == null) 
                return;

            _overlayElement.ClearAnimations();
            AdornerLayer al = AdornerLayer.GetAdornerLayer(lb);
            if (al != null)
            {
                AdornerLayer.GetAdornerLayer(lb).Remove(_overlayElement);
            }

            _overlayElement = null;
            _dragEnter = false;

            XmlElement xe = (XmlElement)e.Data.GetData("XmlElement");

            if (xe == null)
                return;

            //Listbox2ItemSourceBinding.XPath = "chart[. = 'ECGSinusRhythm'] | chart[. = 'Pulse']";
            Binding myBinding = new Binding();
            myBinding.Mode = BindingMode.OneTime;
            string xPath = CreateXPathBinding(xe.InnerText, lb);

            if ((xPath == null) || (xPath.Length == 0))
                return;

            myBinding.XPath = xPath;
            lb.SetBinding(ListBox.ItemsSourceProperty, myBinding);
        }

        void listBoxLiveMonitorsSelector_MouseMove(object sender, MouseEventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (lb == null)
                return;

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                XmlElement xe = lb.SelectedItem as XmlElement;

                // initiate the drag operation
                DataObject dataObject = new DataObject("XmlElement", xe);
                DragDropEffects effects = DragDrop.DoDragDrop(lb, dataObject, DragDropEffects.Copy | DragDropEffects.Move);

                // we're back!
            }
        }

        void listBoxLiveCharts_MouseMove(object sender, MouseEventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (lb == null)
                return;

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                XmlElement xe = lb.SelectedItem as XmlElement;

                // initiate the drag operation
                DataObject dataObject = new DataObject("XmlElement", xe);
                DragDropEffects effects = DragDrop.DoDragDrop(lb, dataObject, DragDropEffects.Copy | DragDropEffects.Move);

                // we're back!
            }
        }

        #endregion

        #region Private Methods

        private string RemoveXPathBinding(string chartName, ListBox lb)
        {
            string xPath = null;

            if (lb == null)
                return xPath;

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" | chart[. = '{0}']", chartName);

            // get the XPath we need to change
            BindingExpression be = lb.GetBindingExpression(ListBox.ItemsSourceProperty);

            if ((be == null) || (be.ParentBinding == null))
                return xPath;

            string xPathOld = be.ParentBinding.XPath;

            if ((xPathOld == null) || (xPathOld.Length == 0))
                return xPathOld;

            // remove the chart from the xPath
            xPath = xPathOld.Replace(sb.ToString(), "");

            return xPath;
        }

        private string CreateXPathBinding(string chartName, ListBox lb)
        {
            string xPath = null;

            if (lb == null)
                return xPath;

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("chart[. = '{0}']", chartName);

            BindingExpression be = lb.GetBindingExpression(ListBox.ItemsSourceProperty);

            if ((be == null) || (be.ParentBinding == null))
                return xPath;

            string xPathOld = be.ParentBinding.XPath;

            // if empty add the item
            if ((xPathOld == null) || (xPathOld.Length == 0))
            {
                xPath = sb.ToString();
                return xPath;
            }

            // if chart name is already in the XPath, don't duplcate
            if (xPathOld.IndexOf(chartName) == -1)
            {
                // Append the new XPath

                xPath = xPathOld;
                xPath += " | ";
                xPath += sb.ToString();
            }

            return xPath;
        }

        #endregion

        #region Globals

        FrameworkElement baseFrameworkElement;
        RectangleBrushAdorner _overlayElement;
        bool _dragEnter = false;
        ChartsManager chartsManager;

        #endregion
    }
}
