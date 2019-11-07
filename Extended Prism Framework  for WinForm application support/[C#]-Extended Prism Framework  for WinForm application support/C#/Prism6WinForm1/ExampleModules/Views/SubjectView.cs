using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prism;
using Prism.Regions;

namespace ExampleModules
{
    public partial class SubjectView : UserControl, IWinFormDataContext
    {
        SubjectViewModel m_subjectViewModel;
        public SubjectView(SubjectViewModel subjectViewModel)
        {
            m_subjectViewModel = subjectViewModel;
            InitializeComponent();
        }

        public object GetViewModel()
        {
            return m_subjectViewModel;
        }
    }
}
