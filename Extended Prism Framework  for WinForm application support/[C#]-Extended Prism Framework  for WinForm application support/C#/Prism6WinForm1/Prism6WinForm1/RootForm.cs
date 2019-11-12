using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MenuModules;
using EventManager;
using Prism.Regions;
using Prism.Events;
using Microsoft.Practices.Unity;

namespace PrismApp
{
    public partial class RootForm : Form
    {
        IRegionManager m_regionManager;
        IUnityContainer m_container;
        IEventAggregator m_eventAggregator;
        public RootForm(IUnityContainer container, IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            InitializeComponent();
            m_regionManager = regionManager;
            m_container = container;
            m_eventAggregator = eventAggregator;
            eventAggregator.GetEvent<MenuItemClickEvent>().Subscribe(MenuClicked);

        }
        private IRegion CreateRegion(string regionName)
        {
            m_regionManager.Regions.Add(regionName, new Prism.Regions.Region());
            return m_regionManager.Regions[regionName];
        }
        private void MenuClicked(string obj)
        {
            if (obj.Equals("Exit"))
                Application.Exit();
            else
                MessageBox.Show("User selected " + obj);
        }
    }
}
