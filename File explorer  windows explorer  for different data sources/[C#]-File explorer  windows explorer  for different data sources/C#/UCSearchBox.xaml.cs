using FileExplorer.Helper;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace FileExplorer
{
    /// <summary>
    /// Interaction logic for UCSearchBox.xaml
    /// </summary>
    public partial class UCSearchBox : UserControl
    {
        #region DP

        /// <summary>
        ///Keyword
        /// </summary>
        public static readonly DependencyProperty SearchKeywordProperty =
            DependencyProperty.Register("SearchKeyword", typeof(string), typeof(UCSearchBox));

        public static void SetSearchKeyword(DependencyObject element, string value)
        {
            if (element == null)
                return;
            element.SetValue(SearchKeywordProperty, value);
        }

        public static string GetSearchKeyword(DependencyObject element)
        {
            if (element == null) return null;
            return (string)element.GetValue(SearchKeywordProperty);
        }

        /// <summary>
        ///Not found hint
        /// </summary>
        public static readonly DependencyProperty NotFoundHintProperty =
            DependencyProperty.Register("NotFoundHint", typeof(string), typeof(UCSearchBox));

        public static void SetNotFoundHint(DependencyObject element, string value)
        {
            if (element == null)
                return;
            element.SetValue(NotFoundHintProperty, value);
        }

        public static string GetNotFoundHint(DependencyObject element)
        {
            if (element == null) return null;
            return (string)element.GetValue(NotFoundHintProperty);
        }

        /// <summary>
        ///Is Search completed
        /// </summary>
        public static readonly DependencyProperty IsSearchCompletedProperty =
            DependencyProperty.Register("IsSearchCompleted", typeof(bool), typeof(UCSearchBox));

        public static void SetIsSearchCompleted(DependencyObject element, bool value)
        {
            if (element == null)
                return;
            element.SetValue(IsSearchCompletedProperty, value);
        }

        public static bool GetIsSearchCompleted(DependencyObject element)
        {
            if (element == null)
                return false;
            return (bool)element.GetValue(IsSearchCompletedProperty);
        }


        /// <summary>
        ///Is Searching
        /// </summary>
        public static readonly DependencyProperty IsSearchingProperty =
            DependencyProperty.Register("IsSearching", typeof(bool), typeof(UCSearchBox));

        public static void SetIsSearching(DependencyObject element, bool value)
        {
            if (element == null)
                return;
            element.SetValue(IsSearchingProperty, value);
        }

        public static bool GetIsSearching(DependencyObject element)
        {
            if (element == null)
                return false;
            return (bool)element.GetValue(IsSearchingProperty);
        }

        #endregion

        public UCSearchBox()
        {
            InitializeComponent();
            this.btnClear.Click += btnClear_Click;
        }

        void btnClear_Click(object sender, RoutedEventArgs e)
        {
            this.txtSearch.Text = string.Empty;
            this.tbPrompt.Text = string.Empty;
        }
    }
}
