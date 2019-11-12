using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace FlashCards.UI.Common
{
    public static class Commands
    {
        public static RoutedUICommand SelectLeft = new RoutedUICommand("Select Left", "SelectLeft", typeof(Commands));
        public static RoutedUICommand SelectRight = new RoutedUICommand("Select Right", "SelectRight", typeof(Commands));
    }
}
