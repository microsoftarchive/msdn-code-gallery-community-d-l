using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelBackEnd
{
    public static class NumericExtensions
    {
        public static bool IsOdd(this int value)
        {
            return value % 2 != 0;
        }
    }
}
