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
    public class NavigationModule : IModule
    {
        IUnityContainer m_unityContainer;
        IRegionManager m_regionManager;
        NavigationView m_navView;
        TreeView m_navTree;
        public NavigationModule(IUnityContainer container, IRegionManager regionManager)
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
            m_navView = m_unityContainer.Resolve<NavigationView>();
            IRegion reg = m_regionManager.Regions["NavigationRegion"];
            Panel panel = reg.RegionHost as Panel;
            reg.Add(m_navView, "NavigationView");
            reg.Activate(m_navView);
            InitialzeParentNode();
        }

        void InitialzeParentNode()
        {
            m_navTree = m_navView.Controls[0] as TreeView;
            m_navTree.ExpandAll();
            m_navTree.Nodes.Add("Students Master");
            m_navTree.Nodes.Add("Subject Master");
        }
    }
}
