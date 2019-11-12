using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.Collections.ObjectModel;


namespace IdentityMine.Avalon.Controls
{
    public class SeriesDataItems : ObservableCollection<SeriesDataItem>
    {
		//public SeriesDataItems() : base()
		//{

		//}

        public void AddValue(double value)
        {
            this.Add(new SeriesDataItem(this, value));
        }
    }
}
