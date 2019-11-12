using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.LightSwitch;
namespace LightSwitchApplication
{
    public partial class InvoiceDetail
    {
        partial void SubTotal_Compute(ref decimal result)
        {
            result = Quantity * UnitPrice;
        }
    }
}
