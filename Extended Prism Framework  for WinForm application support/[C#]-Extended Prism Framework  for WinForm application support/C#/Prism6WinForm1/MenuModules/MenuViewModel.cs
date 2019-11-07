using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Events;

namespace MenuModules
{
    public class MenuViewModel
    {
        private readonly IEventAggregator m_eventAggregator;
        public MenuViewModel(IEventAggregator eventAggregator)
        {
            m_eventAggregator = eventAggregator;
        }
    }
}
