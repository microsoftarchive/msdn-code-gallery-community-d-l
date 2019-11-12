//using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;

namespace Household_budget_calculator_CS.expanding_property_classes
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [System.Serializable()]
    public class Leisure
    {
        public event propertiesChangedEventHandler propertiesChanged;
        public delegate void propertiesChangedEventHandler(propertiesChangedEventArgs e);

        private decimal _eatingOut;
        [DisplayName("Eating Out"), RefreshProperties(RefreshProperties.All)]
        public decimal eatingOut
        {
            get { return _eatingOut; }
            set
            {
                _eatingOut = value;
                totalLeisure = eatingOut + cinema + holidays + sports + cigarettesAndAlcohol;
            }
        }

        private decimal _cinema;
        [DisplayName("Cinema"), RefreshProperties(RefreshProperties.All)]
        public decimal cinema
        {
            get { return _cinema; }
            set
            {
                _cinema = value;
                totalLeisure = eatingOut + cinema + holidays + sports + cigarettesAndAlcohol;
            }
        }

        private decimal _holidays;
        [DisplayName("Holidays"), RefreshProperties(RefreshProperties.All)]
        public decimal holidays
        {
            get { return _holidays; }
            set
            {
                _holidays = value;
                totalLeisure = eatingOut + cinema + holidays + sports + cigarettesAndAlcohol;
            }
        }

        private decimal _sports;
        [DisplayName("Sports"), RefreshProperties(RefreshProperties.All)]
        public decimal sports
        {
            get { return _sports; }
            set
            {
                _sports = value;
                totalLeisure = eatingOut + cinema + holidays + sports + cigarettesAndAlcohol;
            }
        }

        private decimal _cigarettesAndAlcohol;
        [DisplayName("Cigarettes/Alcohol"), RefreshProperties(RefreshProperties.All)]
        public decimal cigarettesAndAlcohol
        {
            get { return _cigarettesAndAlcohol; }
            set
            {
                _cigarettesAndAlcohol = value;
                totalLeisure = eatingOut + cinema + holidays + sports + cigarettesAndAlcohol;
            }
        }

        private decimal _totalLeisure;
        [ReadOnlyAttribute(true), Browsable(false), DisplayName("Total Leisure Outgoings")]
        public decimal totalLeisure
        {
            get { return _totalLeisure; }
            set
            {
                _totalLeisure = value;
                if (propertiesChanged != null)
                {
                    propertiesChanged(new propertiesChangedEventArgs
                    {
                        propName = "Leisure",
                        newValue = value
                    });
                }
            }
        }

        public override string ToString()
        {
            return totalLeisure.ToString("c2");
        }


    }
}
