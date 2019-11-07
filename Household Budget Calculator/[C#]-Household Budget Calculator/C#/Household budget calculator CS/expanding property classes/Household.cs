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
    public class Household
    {
        public event propertiesChangedEventHandler propertiesChanged;
        public delegate void propertiesChangedEventHandler(propertiesChangedEventArgs e);

        private decimal _mortgage;
        [DisplayName("Mortgage/Rent"), RefreshProperties(RefreshProperties.All)]
        public decimal mortgage
        {
            get { return _mortgage; }
            set
            {
                _mortgage = value;
                totalHousehold = mortgage + groceries + clothing + laundry + homehelp;
            }
        }

        private decimal _groceries;
        [DisplayName("Groceries"), RefreshProperties(RefreshProperties.All)]
        public decimal groceries
        {
            get { return _groceries; }
            set
            {
                _groceries = value;
                totalHousehold = mortgage + groceries + clothing + laundry + homehelp;
            }
        }

        private decimal _clothing;
        [DisplayName("Clothing (adult)"), RefreshProperties(RefreshProperties.All)]
        public decimal clothing
        {
            get { return _clothing; }
            set
            {
                _clothing = value;
                totalHousehold = mortgage + groceries + clothing + laundry + homehelp;
            }
        }

        private decimal _laundry;
        [DisplayName("Laundry / Dry Cleaning"), RefreshProperties(RefreshProperties.All)]
        public decimal laundry
        {
            get { return _laundry; }
            set
            {
                _laundry = value;
                totalHousehold = mortgage + groceries + clothing + laundry + homehelp;
            }
        }

        private decimal _homehelp;
        [DisplayName("Home Help"), RefreshProperties(RefreshProperties.All)]
        public decimal homehelp
        {
            get { return _homehelp; }
            set
            {
                _homehelp = value;
                totalHousehold = mortgage + groceries + clothing + laundry + homehelp;
            }
        }

        private decimal _totalHousehold;
        [ReadOnlyAttribute(true), Browsable(false), DisplayName("Total Household Outgoings")]
        public decimal totalHousehold
        {
            get { return _totalHousehold; }
            set
            {
                _totalHousehold = value;
                if (propertiesChanged != null)
                {
                    propertiesChanged(new propertiesChangedEventArgs
                    {
                        propName = "Household",
                        newValue = value
                    });
                }
            }
        }

        public override string ToString()
        {
            return totalHousehold.ToString("c2");
        }


    }
}
