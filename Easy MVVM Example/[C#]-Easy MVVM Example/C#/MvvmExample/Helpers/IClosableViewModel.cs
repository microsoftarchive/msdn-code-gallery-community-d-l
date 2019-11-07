using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvvmExample.Helpers
{
    interface IClosableViewModel
    {
        event EventHandler CloseWindowEvent;
    }
}
