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
using Prism.Regions;

namespace ExampleModules
{
    public partial class StudentView : UserControl, IWinFormDataContext
    {
        StudentViewModel m_studentViewModel;

        public StudentView(StudentViewModel studentViewModel)
        {
            m_studentViewModel = studentViewModel;
            InitializeComponent();
            this.studentViewModelBindingSource.DataSource = m_studentViewModel;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void StudentView_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_studentViewModel.ValidateAndAdd();

        }

        public object GetViewModel()
        {
            return m_studentViewModel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m_studentViewModel.ValidateAndUpdate();
        }
    }
}
