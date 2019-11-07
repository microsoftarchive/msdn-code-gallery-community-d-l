using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlashCardsService.Entities
{
    /// <summary>
    /// A collection of RegularExpressions to be used for input validations
    /// </summary>
    public static class RegularExpressions
    {
        public static string Email = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        public static string Uri = @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
    }
}
