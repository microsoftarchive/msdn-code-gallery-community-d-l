using Prism.Modularity;
using Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExampleModules
{
    public class SubjectModule : IModule
    {

        IUnityContainer m_unityContainer;
        IRegionManager m_regionManager;
        SubjectView m_subjectView;
        public SubjectModule(IUnityContainer container, IRegionManager regionManager)
        {
            m_unityContainer = container;
            m_regionManager = regionManager;
        }
        public void Initialize()
        {
            AddNavView();
        }

        private void AddNavView()
        {
            m_subjectView = m_unityContainer.Resolve<SubjectView>();
            IRegion reg = m_regionManager.Regions["MainRegion"];
            Panel panel = reg.RegionHost as Panel;
            reg.Add(m_subjectView, "SubjectView");
            //reg.Activate(m_studentView);
        }
    }
}
