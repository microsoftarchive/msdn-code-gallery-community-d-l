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
    public class Finance
    {
        public event propertiesChangedEventHandler propertiesChanged;
        public delegate void propertiesChangedEventHandler(propertiesChangedEventArgs e);

        private decimal _pension;
        [DisplayName("Pension"), RefreshProperties(RefreshProperties.All)]
        public decimal pension
        {
            get { return _pension; }
            set
            {
                _pension = value;
                totalFinance = pension + savings;
            }
        }

        private decimal _savings;
        [DisplayName("Regular Savings"), RefreshProperties(RefreshProperties.All)]
        public decimal savings
        {
            get { return _savings; }
            set
            {
                _savings = value;
                totalFinance = pension + savings;
            }
        }

        private decimal _totalFinance;
        [ReadOnlyAttribute(true), Browsable(false), DisplayName("Total Finance Outgoings")]
        public decimal totalFinance
        {
            get { return _totalFinance; }
            set
            {
                _totalFinance = value;
                if (propertiesChanged != null)
                {
                    propertiesChanged(new propertiesChangedEventArgs
                    {
                        propName = "Finance",
                        newValue = value
                    });
                }
            }
        }

        public override string ToString()
        {
            return totalFinance.ToString("c2");
        }

    }
}
