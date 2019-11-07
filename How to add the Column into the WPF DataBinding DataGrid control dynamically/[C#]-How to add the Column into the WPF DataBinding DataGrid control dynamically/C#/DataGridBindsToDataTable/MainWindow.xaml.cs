using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace DataGridBindsToDataTable
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    DataTable dt = new DataTable();

    public MainWindow()
    {
      InitializeComponent();

      dt.Columns.Add(new DataColumn("Column1"));
      dt.Columns.Add(new DataColumn("Column2"));

      DataRow dr;
      for (int i = 0; i < 5; i++)
      {
        dr = dt.NewRow();
        for (int columIndex = 0; columIndex < dt.Columns.Count; columIndex++)
          dr[columIndex] = i.ToString() + " - " + columIndex.ToString();
        dt.Rows.Add(dr);
      }

      dataGrid.ItemsSource = dt.DefaultView;
    }

    private void AddRow_Click(object sender, RoutedEventArgs e)
    {
      DataRow dr = dt.NewRow();
      for (int columIndex = 0; columIndex < dt.Columns.Count; columIndex++)
        dr[columIndex] = "New Row - " + columIndex.ToString();
      dt.Rows.Add(dr);
    }

    int newColumnIndex = 1;
    private void AddColumn_Click(object sender, RoutedEventArgs e)
    {
      dt.Columns.Add(new DataColumn("New Column" + newColumnIndex++));
      for (int i = 0; i < dt.Rows.Count; i++)
      {
        dt.Rows[i][dt.Columns.Count - 1] = i.ToString() + " - New Column";
      }

      // Refresh the DataGrid
      dataGrid.ItemsSource = null;
      dataGrid.ItemsSource = dt.DefaultView;
    }
  }
}
