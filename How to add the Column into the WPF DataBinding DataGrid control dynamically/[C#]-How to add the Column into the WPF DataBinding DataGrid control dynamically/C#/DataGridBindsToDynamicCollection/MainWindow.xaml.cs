using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;
using System.Collections.ObjectModel;
using System.Dynamic;

namespace DataGridBindsToDynamicCollection
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    ObservableCollection<dynamic> items = new ObservableCollection<dynamic>();

    private IEnumerable<string> PropertyNames; //Store the properties names of the dynamic object

    public MainWindow()
    {
      InitializeComponent();

      PropertyNames = new List<string>();

      for (int i = 0; i < 5; i++)
      {
        dynamic item = new DynamicObjectClass();
        item.A = "Property A value - " + i.ToString();
        item.B = "Property B value - " + i.ToString();

        PropertyNames = item.GetDynamicMemberNames();
        items.Add(item);
      }

      //Add Columns
      dataGrid.Columns.Add(new DataGridTextColumn() {Header="A", Binding = new Binding("A") });
      dataGrid.Columns.Add(new DataGridTextColumn() {Header="B", Binding = new Binding("B") });
      dataGrid.ItemsSource = items;
    }

    private void AddRow_Click(object sender, RoutedEventArgs e)
    {
      dynamic item = new DynamicObjectClass();
      foreach (string PropertyName in PropertyNames)
      {
        item.TrySetMember(new SetPropertyBinder(PropertyName), "New Item - " + PropertyName);
      }
      items.Add(item);
    }

    int newColumnIndex = 1;
    private void AddColumn_Click(object sender, RoutedEventArgs e)
    {
      foreach (DynamicObjectClass item in items)
      {
        item.TrySetMember(new SetPropertyBinder("NewColumn" + newColumnIndex), "New Column Value - " + newColumnIndex.ToString());
        PropertyNames = item.GetDynamicMemberNames();
      }

      dataGrid.Columns.Add(new DataGridTextColumn() { Header = "New Column" + newColumnIndex, Binding = new Binding("NewColumn" + newColumnIndex) });

      newColumnIndex++;
    }
  }
}
