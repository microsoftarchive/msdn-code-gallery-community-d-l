//using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;


namespace Household_budget_calculator_CS
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [System.Serializable()]
    public class Children
    {
        public event propertiesChangedEventHandler propertiesChanged;
        public delegate void propertiesChangedEventHandler(propertiesChangedEventArgs e);

        private decimal _care;
        [DisplayName("Daycare/Nanny"), RefreshProperties(RefreshProperties.All)]
        public decimal care
        {
            get { return _care; }
            set
            {
                _care = value;
                totalChildren = care + schooling + clothing + treats;
            }
        }

        private decimal _schooling;
        [DisplayName("Schooling"), RefreshProperties(RefreshProperties.All)]
        public decimal schooling
        {
            get { return _schooling; }
            set
            {
                _schooling = value;
                totalChildren = care + schooling + clothing + treats;
            }
        }

        private decimal _clothing;
        [DisplayName("Clothing"), RefreshProperties(RefreshProperties.All)]
        public decimal clothing
        {
            get { return _clothing; }
            set
            {
                _clothing = value;
                totalChildren = care + schooling + clothing + treats;
            }
        }

        private decimal _treats;
        [DisplayName("Treats"), RefreshProperties(RefreshProperties.All)]
        public decimal treats
        {
            get { return _treats; }
            set
            {
                _treats = value;
                totalChildren = care + schooling + clothing + treats;
            }
        }

        private decimal _totalChildren;
        [ReadOnlyAttribute(true), Browsable(false), DisplayName("Total Children Outgoings")]
        public decimal totalChildren
        {
            get { return _totalChildren; }
            set
            {
                _totalChildren = value;
                if (propertiesChanged != null)
                {
                    propertiesChanged(new propertiesChangedEventArgs
                    {
                        propName = "Children",
                        newValue = value
                    });
                }
            }
        }

        public override string ToString()
        {
            return totalChildren.ToString("c2");
        }

    }
}
