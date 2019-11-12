using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ApplicationNavigation.Model;
using System.ComponentModel;
using ApplicationNavigation.ViewModel;
using ApplicationNavigation.Helpers;

namespace ApplicationNavigation.View
{
    public partial class UserControl7 : UserControl
    {
        /// <summary>
        /// ManagementControl holds the form element that is displayed upon ComboBox selection
        /// </summary>

        public UIElement ManagementControl
        {
            get { return (UIElement)GetValue(ManagementControlProperty); }
            set { SetValue(ManagementControlProperty, value); }
        }

        public static readonly DependencyProperty ManagementControlProperty =
            DependencyProperty.Register("ManagementControl", typeof(UIElement), typeof(UserControl7), new UIPropertyMetadata(null));

        /// <summary>
        /// SelecedPerson is bound to the SelectedItem property of the ComboBox
        /// There is also a "property changed handler" (SelectedPersonChanged) which changes the user form, based on the selected item
        /// To keep such things organised, we have again placed this View creation code in the [previously described] ApplicationController
        /// </summary>

        public Person SelectedPerson
        {
            get { return (Person)GetValue(SelectedPersonProperty); }
            set { SetValue(SelectedPersonProperty, value); }
        }

        public static readonly DependencyProperty SelectedPersonProperty =
            DependencyProperty.Register("SelectedPerson", typeof(Person), typeof(UserControl7), new UIPropertyMetadata(null, SelectedPersonChanged));

        static void SelectedPersonChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var person = e.NewValue as Person;
            if (person != null)
            {
                var view = ApplicationController.MakePersonAdminControl(person.Id);
                (obj as UserControl7).ManagementControl = view;
            }
        }

        public UserControl7()
        {
            InitializeComponent();
            DataContext = this;
        }

    }
}
