// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using InteractivityQuickstart.ViewModels;
using System.Windows.Controls;

namespace InteractivityQuickstart.Views
{
    /// <summary>
    /// Interaction logic for ItemSelectionView.xaml
    /// </summary>
    public partial class ItemSelectionView : UserControl
    {
        public ItemSelectionView()
        {
            this.DataContext = new ItemSelectionViewModel();
            InitializeComponent();
        }
    }
}
