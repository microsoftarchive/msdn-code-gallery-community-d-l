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
    public class StudentModule : IModule
    {
        IUnityContainer m_unityContainer;
        IRegionManager m_regionManager;
        StudentView m_studentView;
        public StudentModule(IUnityContainer container, IRegionManager regionManager)
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
            m_studentView = m_unityContainer.Resolve<StudentView>();
            IRegion reg = m_regionManager.Regions["MainRegion"];
            Panel panel = reg.RegionHost as Panel;
            m_studentView.Dock = DockStyle.Fill;
            reg.Add(m_studentView, "StudentView");
            //reg.Activate(m_studentView);
        }
    }
}
