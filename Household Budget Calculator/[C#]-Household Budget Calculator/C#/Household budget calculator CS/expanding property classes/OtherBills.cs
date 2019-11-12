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
    public class OtherBills
    {
        public event propertiesChangedEventHandler propertiesChanged;
        public delegate void propertiesChangedEventHandler(propertiesChangedEventArgs e);

        private decimal _cc;
        [DisplayName("Credit Cards"), RefreshProperties(RefreshProperties.All)]
        public decimal cc
        {
            get { return _cc; }
            set
            {
                _cc = value;
                totalOtherBills = cc + loans + maintenance + opticalAndDental + miscellaneous;
            }
        }

        private decimal _loans;
        [DisplayName("Loan Repayments"), RefreshProperties(RefreshProperties.All)]
        public decimal loans
        {
            get { return _loans; }
            set
            {
                _loans = value;
                totalOtherBills = cc + loans + maintenance + opticalAndDental + miscellaneous;
            }
        }

        private decimal _maintenance;
        [DisplayName("Maintenance"), RefreshProperties(RefreshProperties.All)]
        public decimal maintenance
        {
            get { return _maintenance; }
            set
            {
                _maintenance = value;
                totalOtherBills = cc + loans + maintenance + opticalAndDental + miscellaneous;
            }
        }

        private decimal _opticalAndDental;
        [DisplayName("Optical/Dental Costs"), RefreshProperties(RefreshProperties.All)]
        public decimal opticalAndDental
        {
            get { return _opticalAndDental; }
            set
            {
                _opticalAndDental = value;
                totalOtherBills = cc + loans + maintenance + opticalAndDental + miscellaneous;
            }
        }

        private decimal _miscellaneous;
        [DisplayName("Miscellaneous"), RefreshProperties(RefreshProperties.All)]
        public decimal miscellaneous
        {
            get { return _miscellaneous; }
            set
            {
                _miscellaneous = value;
                totalOtherBills = cc + loans + maintenance + opticalAndDental + miscellaneous;
            }
        }

        private decimal _totalOtherBills;
        [ReadOnlyAttribute(true), Browsable(false), DisplayName("Total Other Bills Outgoings")]
        public decimal totalOtherBills
        {
            get { return _totalOtherBills; }
            set
            {
                _totalOtherBills = value;
                if (propertiesChanged != null)
                {
                    propertiesChanged(new propertiesChangedEventArgs
                    {
                        propName = "Other Bills",
                        newValue = value
                    });
                }
            }
        }

        public override string ToString()
        {
            return totalOtherBills.ToString("c2");
        }

    }
}
