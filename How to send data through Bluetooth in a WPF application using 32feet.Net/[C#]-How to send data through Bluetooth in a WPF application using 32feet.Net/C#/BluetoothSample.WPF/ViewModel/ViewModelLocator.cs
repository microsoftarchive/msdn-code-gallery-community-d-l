// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewModelLocator.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   This class contains static references to all the view models in the
//   application and provides an entry point for the bindings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using BluetoothSample.Services;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace BluetoothSample.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IReceiverBluetoothService, ReceiverBluetoothService>();
            SimpleIoc.Default.Register<ISenderBluetoothService, SenderBluetoothService>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ReceiverViewModel>();
            SimpleIoc.Default.Register<SenderViewModel>();
        }

        /// <summary>
        /// Gets the main.
        /// </summary>
        /// <value>The main.</value>
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        /// <summary>
        /// Gets the Receiver view model.
        /// </summary>
        /// <value>The Receiver view model.</value>
        public ReceiverViewModel ReceiverViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ReceiverViewModel>();
            }
        }

        /// <summary>
        /// Gets the Sender view model.
        /// </summary>
        /// <value>The Sender view model.</value>
        public SenderViewModel SenderViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SenderViewModel>();
            }
        }

        /// <summary>
        /// Cleanups this instance.
        /// </summary>
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}