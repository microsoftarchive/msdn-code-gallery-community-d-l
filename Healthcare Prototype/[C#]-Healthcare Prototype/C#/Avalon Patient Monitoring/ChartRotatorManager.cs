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
    public class ChartRotatorManager
    {
        public ChartRotatorManager(object fe, ChartsManager cm)
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

            ct = (ControlTemplate)baseFrameworkElement.FindResource("PatientDetailWorkspaceTemplate");
            cc = (ContentControl)baseFrameworkElement.FindName("PatientDetailWorkspaceContent");
            IdentityMine.Avalon.Controls.ChartRotator chartRotator = (IdentityMine.Avalon.Controls.ChartRotator)ct.FindName("ChartRotator3D", cc);

            chartRotator.Drop += new DragEventHandler(chartRotator_Drop);
            chartRotator.PreviewDragEnter += new DragEventHandler(chartRotator_PreviewDragEnter);
            chartRotator.PreviewDragOver += new DragEventHandler(chartRotator_PreviewDragOver);
            chartRotator.PreviewDragLeave += new DragEventHandler(chartRotator_PreviewDragLeave);
        }

        #endregion

        #region Events

       
        void chartRotator_PreviewDragEnter(object sender, DragEventArgs e)
        {
            IdentityMine.Avalon.Controls.ChartRotator cr = sender as IdentityMine.Avalon.Controls.ChartRotator;
            if (cr == null)
                return;

            // Since Enter\Leave event are fired when the mouse moves over embedded controls, we only want to create an overlay if the mouse was outside the element before the enter event is fired.
            if (_dragEnter == false)
            {
                XmlElement xe = (XmlElement)e.Data.GetData("XmlElement");
                Brush brush = chartsManager.GetChartBrush(xe.InnerText);

                _overlayElement = new RectangleBrushAdorner(cr, brush);
                AdornerLayer layer = AdornerLayer.GetAdornerLayer(cr);
                layer.Add(_overlayElement);

                Point _currentPosition = e.GetPosition(cr);
                _overlayElement.LeftOffset = _currentPosition.X;
                _overlayElement.TopOffset = _currentPosition.Y;

                _dragEnter = true;
            }

            e.Handled = true;
        }
        void chartRotator_PreviewDragOver(object sender, DragEventArgs e)
        {
            IdentityMine.Avalon.Controls.ChartRotator cr = sender as IdentityMine.Avalon.Controls.ChartRotator;
            if (cr == null)
                return;

            Point _currentPosition = e.GetPosition(cr);
            _overlayElement.LeftOffset = _currentPosition.X;
            _overlayElement.TopOffset = _currentPosition.Y;

            e.Handled = true;
        }
        void chartRotator_PreviewDragLeave(object sender, DragEventArgs e)
        {
            IdentityMine.Avalon.Controls.ChartRotator cr = sender as IdentityMine.Avalon.Controls.ChartRotator;
            if (cr == null)
                return;

            // if we are still inside the Element, we have not left. This can occur when other controls are within the Element. 
            // A leave and enter event is fired when the mouse moves over embedded controls, and we only want to remove the adorner when the mouse is outside the element.
            Point pt = e.GetPosition(cr);
            if ((pt.X > 0) && (pt.Y > 0) && (pt.X < cr.Width) && (pt.Y < cr.Height))
                return;

            _overlayElement.ClearAnimations();
            AdornerLayer.GetAdornerLayer(cr).Remove(_overlayElement);
            _overlayElement = null;
            _dragEnter = false;

            e.Handled = true;
        }


        void chartRotator_Drop(object sender, DragEventArgs e)
        {
            IdentityMine.Avalon.Controls.ChartRotator cr = sender as IdentityMine.Avalon.Controls.ChartRotator;
            if (cr == null)
                return;

            _overlayElement.ClearAnimations();
            AdornerLayer.GetAdornerLayer(cr).Remove(_overlayElement);
            _overlayElement = null;
            _dragEnter = false;

            XmlElement xe = (XmlElement)e.Data.GetData("XmlElement");

            if (xe == null)
                return;

            Brush vb = chartsManager.GetChartBrush (xe.InnerText);
            cr.AddVisual(vb as VisualBrush);
           
        }

        #endregion

        #region Private Methods


        #endregion

        #region Globals

        FrameworkElement baseFrameworkElement;
        RectangleBrushAdorner _overlayElement;
        bool _dragEnter = false;
        ChartsManager chartsManager;
       

        #endregion
    }

}
