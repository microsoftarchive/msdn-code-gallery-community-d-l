using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleModules
{
    public class SubjectViewModel : IConfirmNavigationRequest
    {
        IEventAggregator m_eventAggregator;
        IRegionManager m_regionManager;
        public SubjectViewModel(IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            m_eventAggregator = eventAggregator;
            m_regionManager = regionManager;
        }


        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            // intentionally not implemented
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            // intentionally not implemented
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            object value = m_regionManager.Regions["MainRegion"].Context;
            if (value != null)
            {

            }
        }
    }
}
