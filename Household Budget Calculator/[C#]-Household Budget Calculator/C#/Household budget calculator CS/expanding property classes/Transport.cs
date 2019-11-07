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
    public class Transport
    {
        public event propertiesChangedEventHandler propertiesChanged;
        public delegate void propertiesChangedEventHandler(propertiesChangedEventArgs e);

        private decimal _petrol;
        [DisplayName("Petrol"), RefreshProperties(RefreshProperties.All)]
        public decimal petrol
        {
            get { return _petrol; }
            set
            {
                _petrol = value;
                totalTransport = petrol + commuting + carCosts;
            }
        }

        private decimal _commuting;
        [DisplayName("Commuting"), RefreshProperties(RefreshProperties.All)]
        public decimal commuting
        {
            get { return _commuting; }
            set
            {
                _commuting = value;
                totalTransport = petrol + commuting + carCosts;
            }
        }

        private decimal _carCosts;
        [DisplayName("Car Costs"), RefreshProperties(RefreshProperties.All)]
        public decimal carCosts
        {
            get { return _carCosts; }
            set
            {
                _carCosts = value;
                totalTransport = petrol + commuting + carCosts;
            }
        }

        private decimal _totalTransport;
        [ReadOnlyAttribute(true), Browsable(false), DisplayName("Total Transport Outgoings")]
        public decimal totalTransport
        {
            get { return _totalTransport; }
            set
            {
                _totalTransport = value;
                if (propertiesChanged != null)
                {
                    propertiesChanged(new propertiesChangedEventArgs
                    {
                        propName = "Transport",
                        newValue = value
                    });
                }
            }
        }

        public override string ToString()
        {
            return totalTransport.ToString("c2");
        }
    }
}
