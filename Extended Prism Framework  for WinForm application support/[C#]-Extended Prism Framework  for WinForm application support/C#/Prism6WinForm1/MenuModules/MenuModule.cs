using Prism.Modularity;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prism.Regions;

namespace MenuModules
{
    public class MenuModule : IModule
    {

        IUnityContainer m_unityContainer;
        IRegionManager m_regionManager;
        public MenuModule(IUnityContainer container, IRegionManager regionManager)
        {
            m_unityContainer = container;
            m_regionManager = regionManager;
        }

        public void Initialize()
        {
            AddNormalMenu();
        }

        private void AddNormalMenu()
        {
            MenuView view = m_unityContainer.Resolve<MenuView>();
            IRegion reg = m_regionManager.Regions["MenuRegion"];
            Panel panel = reg.RegionHost as Panel;
            reg.Add(view, "MenuBarView");
            reg.Activate(view);
            view.Dock = DockStyle.Top;
            panel.Height = view.Height;
        }


    }
}
