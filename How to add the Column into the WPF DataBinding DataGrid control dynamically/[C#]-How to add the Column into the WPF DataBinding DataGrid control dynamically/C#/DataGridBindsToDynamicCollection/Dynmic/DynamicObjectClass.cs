using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Dynamic;
using System.Windows;

namespace DataGridBindsToDynamicCollection
{
  public class DynamicObjectClass : DynamicObject, INotifyPropertyChanged
  {
    #region DynamicObject overrides

    public DynamicObjectClass()
    {
    }

    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {
      return members.TryGetValue(binder.Name, out result);
    }

    public override bool TrySetMember(SetMemberBinder binder, object value)
    {
      members[binder.Name] = value;
      OnPropertyChanged(binder.Name);
      return true;
    }

    public override IEnumerable<string> GetDynamicMemberNames()
    {
      return members.Keys;
    }

    public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
    {
      int index = (int)indexes[0];
      try
      {
        result = itemsCollection[index];
      }
      catch (ArgumentOutOfRangeException)
      {
        result = null;
        return false;
      }
      return true;
    }

    public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
    {
      int index = (int)indexes[0];
      itemsCollection[index] = value;
      OnPropertyChanged(System.Windows.Data.Binding.IndexerName);
      return true;
    }

    public override bool TryDeleteMember(DeleteMemberBinder binder)
    {
      if (members.ContainsKey(binder.Name))
      {
        members.Remove(binder.Name);
        return true;
      }
      return false;
    }

    public override bool TryDeleteIndex(DeleteIndexBinder binder, object[] indexes)
    {
      int index = (int)indexes[0];
      itemsCollection.RemoveAt(index);
      return true;
    }

    #endregion DynamicObject overrides

    #region INotifyPropertyChanged

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion INotifyPropertyChanged

    #region Public methods

    public object AddItem(object item)
    {
      itemsCollection.Add(item);
      OnPropertyChanged(Binding.IndexerName);
      return null;
    }

    #endregion Public methods

    #region Private data

    Dictionary<string, object> members = new Dictionary<string, object>();
    ObservableCollection<object> itemsCollection = new ObservableCollection<object>();

    #endregion Private data
  }
  
}

