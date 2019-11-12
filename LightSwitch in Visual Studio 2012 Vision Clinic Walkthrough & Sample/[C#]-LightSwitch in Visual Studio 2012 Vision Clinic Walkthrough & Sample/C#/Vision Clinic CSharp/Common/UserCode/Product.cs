using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.LightSwitch;
namespace LightSwitchApplication
{
    public partial class Product
    {
        partial void CurrentPrice_Compute(ref decimal result)
        {
            decimal rebates = default(decimal);

            foreach (var item in ProductRebates)
            {
                if (item.RebateStart <= System.DateTime.Today && item.RebateEnd >= System.DateTime.Today)
                {
                rebates = rebates += item.Rebate.Value;
            }
        }
            result = this.MSRP - rebates;
        }
    }
}
