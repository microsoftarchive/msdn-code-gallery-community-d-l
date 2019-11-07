using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

public class groupSorter : IComparer<ListViewGroup>
{

    public int Compare(System.Windows.Forms.ListViewGroup x, System.Windows.Forms.ListViewGroup y)
    {
        return x.Name.CompareTo(y.Name);
    }

}

