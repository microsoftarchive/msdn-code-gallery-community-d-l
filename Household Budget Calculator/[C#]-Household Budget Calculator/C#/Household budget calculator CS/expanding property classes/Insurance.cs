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
    public class Insurance
    {
        public event propertiesChangedEventHandler propertiesChanged;
        public delegate void propertiesChangedEventHandler(propertiesChangedEventArgs e);

        private decimal _life;
        [DisplayName("Life + Protection"), RefreshProperties(RefreshProperties.All)]
        public decimal life
        {
            get { return _life; }
            set
            {
                _life = value;
                totalInsurance = life + motor + medical;
            }
        }

        private decimal _motor;
        [DisplayName("Motor + Home"), RefreshProperties(RefreshProperties.All)]
        public decimal motor
        {
            get { return _motor; }
            set
            {
                _motor = value;
                totalInsurance = life + motor + medical;
            }
        }

        private decimal _medical;
        [DisplayName("Medical"), RefreshProperties(RefreshProperties.All)]
        public decimal medical
        {
            get { return _medical; }
            set
            {
                _medical = value;
                totalInsurance = life + motor + medical;
            }
        }

        private decimal _totalInsurance;
        [ReadOnlyAttribute(true), Browsable(false), DisplayName("Total Insurance Outgoings")]
        public decimal totalInsurance
        {
            get { return _totalInsurance; }
            set
            {
                _totalInsurance = value;
                if (propertiesChanged != null)
                {
                    propertiesChanged(new propertiesChangedEventArgs
                    {
                        propName = "Insurance",
                        newValue = value
                    });
                }
            }
        }

        public override string ToString()
        {
            return totalInsurance.ToString("c2");
        }

    }
}
