using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prism.Events;
using EventManager;

namespace MenuModules
{
    public partial class MenuView : UserControl
    {
        IEventAggregator m_eventAggregator;
        MenuViewModel m_menuViewModel;
        public MenuView(MenuViewModel viewModel, IEventAggregator eventAggregator)
        {
            InitializeComponent();
            m_menuViewModel = viewModel;
            m_eventAggregator = eventAggregator;
            Height = menuStrip1.Height + toolStrip1.Height;

        }

        private void WinFormMenuCtrl_Resize(object sender, EventArgs e)
        {

        }

        private void WinFormMenuCtrl_Load(object sender, EventArgs e)
        {

        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            m_eventAggregator.GetEvent<MenuItemClickEvent>().Publish(sender.ToString());
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
