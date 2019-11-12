// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using AzureMobile.Samples.FieldEngineer.DataModels;
using AzureMobile.Samples.FieldEngineer.DataSources;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AzureMobile.Samples.FieldEngineer.Common
{
    public class JobCardTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            Job job = item as Job;
            if (job.Status.Equals(Constants.CompletedStatus))
            {
                return App.Current.Resources[Constants.CompletedJobItemTemplate] as DataTemplate;
            }

            if (job.Status.Equals(Constants.PendingStatus))
            {
                return App.Current.Resources[Constants.JobItemTemplate] as DataTemplate;
            }

            if (job.Status.Equals(Constants.CurrentStatus))
            {
                return App.Current.Resources[Constants.CurrentJobItemTemplate] as DataTemplate;
            }

            return base.SelectTemplateCore(item, container);
        }
    }
}
