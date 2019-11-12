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
using System.Collections.ObjectModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Windows.Media.Imaging;

namespace FuelTracker.Model
{
    /// <summary>
    /// Represents the data-access layer of the Fuel Tracker application.
    /// </summary>
    public static class CarDataStore
    {
        private const string CAR_PHOTO_DIR_NAME = "FuelTracker";
        private const string CAR_PHOTO_FILE_NAME = "CarPhoto.jpg";
        private const string CAR_PHOTO_TEMP_FILE_NAME = "TempCarPhoto.jpg";
        private const string CAR_KEY = "FuelTracker.Car";
        private static readonly IsolatedStorageSettings appSettings =
            IsolatedStorageSettings.ApplicationSettings;
        private static Car _car;

        public static event EventHandler CarUpdated;

        /// <summary>
        /// Gets or sets the car data, loading the data from isolated storage
        /// (if there is any saved data) on the first access. 
        /// </summary>
        public static Car Car 
        { 
            get
            {
                if (_car == null)
                {
                    if (appSettings.Contains(CAR_KEY))
                    {
                        _car = (Car)appSettings[CAR_KEY];
                        _car.Picture = GetCarPhoto(CAR_PHOTO_FILE_NAME);
                    }
                    else
                    {
                        _car = new Car
                        {
                            FillupHistory = new ObservableCollection<Fillup>()
                        };
                    }
                }
                return _car;
            }
            set
            {
                _car = value;
                NotifyCarUpdated();
            }
        }

        /// <summary>
        /// Saves the car data to isolated storage. 
        /// </summary>
        /// <param name="errorCallback">The action to execute if the 
        /// storage attempt fails.</param>
        public static void SaveCar(Action errorCallback)
        {
            try
            {
                appSettings[CAR_KEY] = Car;
                appSettings.Save();
                DeleteTempCarPhoto();
                SaveCarPhoto(CAR_PHOTO_FILE_NAME, Car.Picture, errorCallback);
                NotifyCarUpdated();
            }
            catch (IsolatedStorageException)
            {
                errorCallback();
            }
        }

        /// <summary>
        /// Deletes the car data from isolated storage and resets the Car property.
        /// </summary>
        public static void DeleteCar()
        {
            appSettings.Remove(CAR_KEY);
            appSettings.Save();
            Car = null;
            DeleteCarPhoto();
            DeleteTempCarPhoto();
            NotifyCarUpdated();
        }

        /// <summary>
        /// Gets the temporary car photo from isolated storage.
        /// </summary>
        /// <returns>The temporary car photo.</returns>
        public static BitmapImage GetTempCarPhoto()
        {
            return GetCarPhoto(CAR_PHOTO_TEMP_FILE_NAME);
        }

        /// <summary>
        /// Saves the temporary car photo to isolated storage.
        /// </summary>
        /// <param name="carPicture">The image to save.</param>
        /// <param name="errorCallback">The action to execute if the storage
        /// attempt fails.</param>
        public static void SaveTempCarPhoto(BitmapImage carPicture, 
            Action errorCallback)
        {
            SaveCarPhoto(CAR_PHOTO_TEMP_FILE_NAME, carPicture, errorCallback);
        }

        /// <summary>
        /// Deletes the car photo from isolated storage.
        /// </summary>
        private static void DeleteCarPhoto()
        {
            DeletePhoto(CAR_PHOTO_FILE_NAME);
        }

        /// <summary>
        /// Deletes the temporary car photo from isolated storage.
        /// </summary>
        public static void DeleteTempCarPhoto()
        {
            DeletePhoto(CAR_PHOTO_TEMP_FILE_NAME);
        }

        /// <summary>
        /// Deletes the photo with the specified file name.
        /// </summary>
        /// <param name="fileName">The name of the photo file to delete.</param>
        private static void DeletePhoto(String fileName)
        {
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                var path = Path.Combine(CAR_PHOTO_DIR_NAME, fileName);
                if (store.FileExists(path)) store.DeleteFile(path);
            }
        }

        /// <summary>
        /// Gets the specified car photo from isolated storage.
        /// </summary>
        /// <param name="fileName">The filename of the photo to get.</param>
        /// <returns>The requested photo.</returns>
        private static BitmapImage GetCarPhoto(string fileName)
        {
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                string path = Path.Combine(CAR_PHOTO_DIR_NAME, fileName);

                if (!store.FileExists(path)) return null;

                using (var stream = store.OpenFile(path, FileMode.Open))
                {
                    var image = new BitmapImage();
                    image.SetSource(stream);
                    return image;
                }
            }
        }

        /// <summary>
        /// Saves the specified car photo to isolated storage using the 
        /// specified filename.
        /// </summary>
        /// <param name="fileName">The filename to use.</param>
        /// <param name="carPicture">The image to save.</param>
        /// <param name="errorCallback">The action to execute if the storage
        /// attempt fails.</param>
        private static void SaveCarPhoto(string fileName, BitmapImage carPicture,
            Action errorCallback)
        {
            if (carPicture == null) return;
            try
            {
                using (var store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    var bitmap = new WriteableBitmap(carPicture);
                    var path = Path.Combine(CAR_PHOTO_DIR_NAME, fileName);

                    if (!store.DirectoryExists(CAR_PHOTO_DIR_NAME))
                    {
                        store.CreateDirectory(CAR_PHOTO_DIR_NAME);
                    }

                    using (var stream = store.OpenFile(path, FileMode.Create))
                    {
                        bitmap.SaveJpeg(stream, bitmap.PixelWidth, bitmap.PixelHeight, 0, 100);
                    }
                }
            }
            catch (IsolatedStorageException)
            {
                errorCallback();
            }
        }

        /// <summary>
        /// Validates the specified Fillup and then, if it is valid, adds it to
        /// Car.FillupHistory collection. 
        /// </summary>
        /// <param name="fillup">The fill-up to save.</param>
        /// <param name="errorCallback">The action to execute if the storage
        /// attempt fails.</param>
        /// <returns>The validation results.</returns>
        public static SaveResult SaveFillup(Fillup fillup, Action errorCallback)
        {
            var lastReading =
                Car.FillupHistory.Count > 0 ?
                Car.FillupHistory.First().OdometerReading :
                Car.InitialOdometerReading;
            fillup.DistanceDriven = fillup.OdometerReading - lastReading;

            var saveResult = new SaveResult();
            var validationResults = fillup.Validate();
            if (validationResults.Count > 0)
            {
                saveResult.SaveSuccessful = false;
                saveResult.ErrorMessages = validationResults;
            }
            else
            {
                Car.FillupHistory.Insert(0, fillup);
                saveResult.SaveSuccessful = true;
                SaveCar(delegate { 
                    saveResult.SaveSuccessful = false; 
                    errorCallback(); });
            }
            return saveResult;
        }

        private static void NotifyCarUpdated()
        {
            var handler = CarUpdated;
            if (handler != null) handler(null, null);
        }
    }
}
