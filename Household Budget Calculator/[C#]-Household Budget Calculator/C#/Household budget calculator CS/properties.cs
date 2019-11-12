//using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
using System.Globalization;
using System.Drawing.Design;
using Household_budget_calculator_CS.expanding_property_classes;
using Household_budget_calculator_CS.expanding_property_classes.TypeEditors;


namespace Household_budget_calculator_CS
{
    [System.Serializable()]
    public class properties
    {
        public event propertiesChangedEventHandler propertiesChanged;
        public delegate void propertiesChangedEventHandler(propertiesChangedEventArgs e);

        public properties()
        {
            removeEventHandlers();
            addEventHandlers();
        }

        public void addEventHandlers()
        {
            _children.propertiesChanged += expandable_propertiesChanged;
            _finance.propertiesChanged += expandable_propertiesChanged;
            _houseHold.propertiesChanged += expandable_propertiesChanged;
            _insurance.propertiesChanged += expandable_propertiesChanged;
            _leisure.propertiesChanged += expandable_propertiesChanged;
            _otherBills.propertiesChanged += expandable_propertiesChanged;
            _regularBills.propertiesChanged += expandable_propertiesChanged;
            _transport.propertiesChanged += expandable_propertiesChanged;
        }

        public void removeEventHandlers()
        {
            _children.propertiesChanged -= expandable_propertiesChanged;
            _finance.propertiesChanged -= expandable_propertiesChanged;
            _houseHold.propertiesChanged -= expandable_propertiesChanged;
            _insurance.propertiesChanged -= expandable_propertiesChanged;
            _leisure.propertiesChanged -= expandable_propertiesChanged;
            _otherBills.propertiesChanged -= expandable_propertiesChanged;
            _regularBills.propertiesChanged -= expandable_propertiesChanged;
            _transport.propertiesChanged -= expandable_propertiesChanged;
        }

        private decimal _net;
        [CategoryAttribute("(Monthly Income)"), RefreshProperties(RefreshProperties.All), DisplayName("Net monthly pay")]
        public decimal net
        {
            get { return _net; }
            set
            {
                _net = value;
                totalIncome = (net + pension + otherIncome1 + otherIncome2).ToString("c2");
            }
        }

        private decimal _pension;
        [CategoryAttribute("(Monthly Income)"), RefreshProperties(RefreshProperties.All), DisplayName("Pension")]
        public decimal pension
        {
            get { return _pension; }
            set
            {
                _pension = value;
                totalIncome = (net + pension + otherIncome1 + otherIncome2).ToString("c2");
            }
        }

        private decimal _otherIncome1;
        [CategoryAttribute("(Monthly Income)"), RefreshProperties(RefreshProperties.All), DisplayName("Income from Savings + Investments")]
        public decimal otherIncome1
        {
            get { return _otherIncome1; }
            set
            {
                _otherIncome1 = value;
                totalIncome = (net + pension + otherIncome1 + otherIncome2).ToString("c2");
            }
        }

        private decimal _otherIncome2;
        [CategoryAttribute("(Monthly Income)"), RefreshProperties(RefreshProperties.All), DisplayName("Other Income")]
        public decimal otherIncome2
        {
            get { return _otherIncome2; }
            set
            {
                _otherIncome2 = value;
                totalIncome = (net + pension + otherIncome1 + otherIncome2).ToString("c2");
            }
        }

        private string _totalIncome;
        [CategoryAttribute("(Monthly Income)"), RefreshProperties(RefreshProperties.All), ReadOnlyAttribute(true), DisplayName("Total Income"), Editor(typeof(TypeEditor0), typeof(UITypeEditor))]
        public string totalIncome
        {
            get { return _totalIncome; }
            set
            {
                _totalIncome = value;
                decimal decValue = default(decimal);
                decimal.TryParse(value, NumberStyles.Currency, CultureInfo.CurrentCulture, out decValue);
                if (propertiesChanged != null)
                {
                    propertiesChanged(new propertiesChangedEventArgs
                    {
                        propName = "Total Income",
                        newValue = decValue
                    });
                }
            }
        }


        private Household _houseHold = new Household();
        [CategoryAttribute("(Monthly Outgoings)"), DisplayName("Household"), Editor(typeof(TypeEditor3), typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Household houseHold
        {
            get { return _houseHold; }
            set { _houseHold = value; }
        }

        private Transport _transport = new Transport();
        [CategoryAttribute("(Monthly Outgoings)"), DisplayName("Transport"), Editor(typeof(TypeEditor8), typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Transport transport
        {
            get { return _transport; }
            set { _transport = value; }
        }

        private Finance _finance = new Finance();
        [CategoryAttribute("(Monthly Outgoings)"), DisplayName("Finance"), Editor(typeof(TypeEditor2), typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Finance finance
        {
            get { return _finance; }
            set { _finance = value; }
        }

        private Leisure _leisure = new Leisure();
        [CategoryAttribute("(Monthly Outgoings)"), DisplayName("Leisure"), Editor(typeof(TypeEditor5), typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Leisure leisure
        {
            get { return _leisure; }
            set { _leisure = value; }
        }

        private RegularBills _regularBills = new RegularBills();
        [CategoryAttribute("(Monthly Outgoings)"), DisplayName("Regular Bills"), Editor(typeof(TypeEditor7), typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RegularBills regularBills
        {
            get { return _regularBills; }
            set { _regularBills = value; }
        }

        private Insurance _insurance = new Insurance();
        [CategoryAttribute("(Monthly Outgoings)"), DisplayName("Insurance"), Editor(typeof(TypeEditor4), typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Insurance insurance
        {
            get { return _insurance; }
            set { _insurance = value; }
        }

        private Children _children = new Children();
        [CategoryAttribute("(Monthly Outgoings)"), DisplayName("Children"), Editor(typeof(TypeEditor1), typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Children children
        {
            get { return _children; }
            set
            {
                _children = value;
                System.Diagnostics.Debugger.Break();
            }
        }

        private OtherBills _otherBills = new OtherBills();
        [CategoryAttribute("(Monthly Outgoings)"), DisplayName("Other Bills"), Editor(typeof(TypeEditor6), typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public OtherBills otherBills
        {
            get { return _otherBills; }
            set { _otherBills = value; }
        }

        private void expandable_propertiesChanged(propertiesChangedEventArgs e)
        {
            if (propertiesChanged != null)
            {
                propertiesChanged(new propertiesChangedEventArgs
                {
                    propName = e.propName,
                    newValue = e.newValue
                });
            }
        }

    }
}
