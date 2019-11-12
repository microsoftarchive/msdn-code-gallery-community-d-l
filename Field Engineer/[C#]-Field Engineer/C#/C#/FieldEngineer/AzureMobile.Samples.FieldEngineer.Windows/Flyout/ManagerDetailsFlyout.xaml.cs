// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using AzureMobile.Samples.FieldEngineer.Common;
using Windows.UI.Xaml.Controls;

namespace AzureMobile.Samples.FieldEngineer.Flyout
{
    public sealed partial class ManagerDetailsFlyout : SettingsFlyout
    {
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public ManagerDetailsFlyout()
        {
            this.InitializeComponent();
            this.DataContext = this.DefaultViewModel;
            this.BuildContactBar();
        }

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        private void BuildContactBar()
        {
            //TODO will enable these button in V2
            //var lstButtons = new List<Tuple<string, string>>
            //                     {
            //                         Tuple.Create("\uE13A", "Call"),
            //                         Tuple.Create("\uE15F", "Send message"),
            //                         Tuple.Create("\uE13B", "Video Call"),
            //                         Tuple.Create("\uE119", "E-mail")
            //                     };
            //this.DefaultViewModel["Items"] = lstButtons;
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as Tuple<string, string>;

            switch (item.Item2)
            {
                case "E-mail":
                    //TODO: Need to add UI to lauch email client
                    break;
                case "Send message":
                    //TODO: Need to add UI and may be move to common class
                    break;
                default:
                    //TODO: Need to add UI to lauch Skype
                    break;
            }
        }
    }
}
