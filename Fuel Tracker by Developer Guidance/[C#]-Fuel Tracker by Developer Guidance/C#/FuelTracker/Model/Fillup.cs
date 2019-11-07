// ===================================================================================
//  Microsoft Developer Guidance
//  Application Guidance for Windows Phone 7 
// ===================================================================================
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//  OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//  LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//  FITNESS FOR A PARTICULAR PURPOSE.
// ===================================================================================
//  The example companies, organizations, products, domain names,
//  e-mail addresses, logos, people, places, and events depicted
//  herein are fictitious.  No association with any real company,
//  organization, product, domain name, email address, logo, person,
//  places, or events is intended or should be inferred.
// ===================================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FuelTracker.Model
{
    public class Fillup : INotifyPropertyChanged
    {
        private DateTime _date;
        private float _fuelQuantity;
        private float _odometerReading;
        private float _pricePerFuelUnit;

        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (_date == value) return;
                _date = value;
                NotifyPropertyChanged("Date");
            }
        }

        public float OdometerReading
        {
            get { return _odometerReading; }
            set
            {
                var roundedValue = (float)Math.Round(value, 0);
                if (_odometerReading.Equals(roundedValue)) return;
                _odometerReading = roundedValue;
                NotifyPropertyChanged("OdometerReading");
            }
        }

        public float FuelQuantity
        {
            get { return _fuelQuantity; }
            set
            {
                var roundedValue = (float)Math.Round(value, 1);
                if (_fuelQuantity.Equals(roundedValue)) return;
                _fuelQuantity = roundedValue;
                NotifyPropertyChanged("FuelQuantity");
            }
        }

        public float PricePerFuelUnit
        {
            get { return _pricePerFuelUnit; }
            set
            {
                var roundedValue = (float)Math.Round(value, 2);
                if (_pricePerFuelUnit.Equals(roundedValue)) return;
                _pricePerFuelUnit = roundedValue;
                NotifyPropertyChanged("PricePerFuelUnit");
            }
        }

        public float FuelEfficiency
        {
            get { return DistanceDriven / FuelQuantity; }
        }

        public float DistanceDriven { get; set; }

        public IList<string> Validate()
        {
            var validationErrors = new List<string>();

            if (OdometerReading <= 0)
            {
                validationErrors.Add("The odometer value must be a number greater than zero.");
            }

            if (DistanceDriven <= 0)
            { 
                validationErrors.Add("The odometer value must be greater than the previous value.");
            }

            if (FuelQuantity <= 0) 
            {
               validationErrors.Add("The fuel quantity must be greater than zero.");
            }

            if (PricePerFuelUnit <= 0) 
            {
                validationErrors.Add("The fuel price must be greater than zero.");
            }
            
            return validationErrors;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
