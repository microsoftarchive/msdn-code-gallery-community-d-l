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
    public class RegularBills
    {
        public event propertiesChangedEventHandler propertiesChanged;
        public delegate void propertiesChangedEventHandler(propertiesChangedEventArgs e);

        private decimal _councilTax;
        [DisplayName("Council Tax"), RefreshProperties(RefreshProperties.All)]
        public decimal councilTax
        {
            get { return _councilTax; }
            set
            {
                _councilTax = value;
                totalRegularBills = councilTax + amenities + communications;
            }
        }

        private decimal _amenities;
        [DisplayName("Gas/Electricity/Water"), RefreshProperties(RefreshProperties.All)]
        public decimal amenities
        {
            get { return _amenities; }
            set
            {
                _amenities = value;
                totalRegularBills = councilTax + amenities + communications;
            }
        }

        private decimal _communications;
        [DisplayName("Phone/Television"), RefreshProperties(RefreshProperties.All)]
        public decimal communications
        {
            get { return _communications; }
            set
            {
                _communications = value;
                totalRegularBills = councilTax + amenities + communications;
            }
        }

        private decimal _totalRegularBills;
        [ReadOnlyAttribute(true), Browsable(false), DisplayName("Total Regular Bills Outgoings")]
        public decimal totalRegularBills
        {
            get { return _totalRegularBills; }
            set
            {
                _totalRegularBills = value;
                if (propertiesChanged != null)
                {
                    propertiesChanged(new propertiesChangedEventArgs
                    {
                        propName = "Regular Bills",
                        newValue = value
                    });
                }
            }
        }

        public override string ToString()
        {
            return totalRegularBills.ToString("c2");
        }

    }
}
