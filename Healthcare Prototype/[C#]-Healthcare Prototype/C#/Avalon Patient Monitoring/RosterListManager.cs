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

    public enum RosterListStyles
    {
        RosterListItem,
        SmallRosterListItem,
        TextRosterListItem
    }

    #endregion

    public class RosterListManager
    {
        public RosterListManager(object fe)
        {
            baseFrameworkElement = fe as FrameworkElement;

            if (baseFrameworkElement == null)
                return;
        }

        #region Public Methods

        public void Load()
        {
            if (baseFrameworkElement == null)
                return;

            ControlTemplate ct = (ControlTemplate)baseFrameworkElement.FindResource("PatientRosterStyleSelectorTemplate");
            ContentControl cc = (ContentControl)baseFrameworkElement.FindName("PatientRosterStyleSelectorContent");
            ComboBox comboBox = ct.FindName("PatientRosterSelectorComboBox", cc) as ComboBox;
            comboBox.SelectionChanged += new SelectionChangedEventHandler(PatientRosterSelectorComboBox_SelectionChanged);
        }

        #endregion

        #region Events

        void PatientRosterSelectorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if ((cb == null) || (baseFrameworkElement == null))
                return;

            string listItemStyleKey = "RosterListItem";

            switch (cb.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    listItemStyleKey = "SmallRosterListItem";
                    break;
                case 2:
                    listItemStyleKey = "TextRosterListItem";
                    break;
            }

            Style listItemStyle = Application.Current.FindResource(listItemStyleKey) as Style;
            if (listItemStyle != null)
            {
                ListBox lb = (ListBox) baseFrameworkElement.FindName("PatientRosterList");

                if (lb != null)
                    lb.ItemContainerStyle = listItemStyle;
            }

        }

        #endregion

        #region Private Methods



        #endregion

        #region Globals

        FrameworkElement baseFrameworkElement;

        #endregion
    }
}
