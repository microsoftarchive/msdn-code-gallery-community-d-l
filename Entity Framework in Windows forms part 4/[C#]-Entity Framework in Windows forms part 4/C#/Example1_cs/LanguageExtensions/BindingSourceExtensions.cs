using EntityFrameWorkNorthWind_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example1_cs
{
    public static class BindingSourceExtensions
    {
        //public static Customer Customer(this BindingSource sender)
        //{
        //    return ((Customer)sender.Current);
        //}
        public static int CustomerIdentifier(this BindingSource sender)
        {
            return ((Customer)sender.Current).CustomerIdentifier;
        }
        public static string CompanyName(this BindingSource sender)
        {
            return ((Customer)sender.Current).CompanyName;
        }
    }
}
