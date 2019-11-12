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
using DataModel;
using Prism;
using Prism.Regions;

namespace ExampleModules
{
    public partial class NavigationView : UserControl, IWinFormDataContext
    {
        IEventAggregator m_eventAggregator;
        NavigationViewModel m_navModel;
        public NavigationView(NavigationViewModel viewModel, IEventAggregator eventAggregator)
        {
            m_navModel = viewModel;
            InitializeComponent();
            m_eventAggregator = eventAggregator;
            m_eventAggregator.GetEvent<AddObjectEvent>().Subscribe(AddObject);

        }

        public object GetViewModel()
        {
            return m_navModel;
        }

        private void AddObject(object obj)
        {
            if (obj.GetType() == typeof(Student))
            {
                Student _tmpStudent = obj as Student;
                if (m_navModel.StudentList.Where(p => p.Name.Equals(_tmpStudent.Name)).FirstOrDefault() == null)
                {
                    m_navModel.StudentList.Add(_tmpStudent);
                    TreeNode node = treeView1.Nodes[0];
                    node.Nodes.Add(new TreeNode(_tmpStudent.Name));
                    treeView1.ExpandAll();
                }
                else
                {
                    Student _exisStudent = m_navModel.StudentList.Where(p => p.Name.Equals(_tmpStudent.Name)).FirstOrDefault();
                    _exisStudent.DateOfBirth = _tmpStudent.DateOfBirth;
                    _exisStudent.RegisterNo = _tmpStudent.RegisterNo;
                }
            }
            if (obj.GetType() == typeof(Subject))
            {
                Subject tmpSubject = obj as Subject;
                if (!m_navModel.SubjectList.Contains(tmpSubject))
                {
                    m_navModel.SubjectList.Add(tmpSubject);
                    TreeNode node = treeView1.Nodes[1];
                    node.Nodes.Add(new TreeNode(tmpSubject.Name));
                    treeView1.ExpandAll();
                }
            }
        }
        private void treeView1_Click(object sender, EventArgs e)
        {
            MouseEventArgs mact = e as MouseEventArgs;
            TreeNode node = treeView1.GetNodeAt(mact.Location);

            if (node.Parent == null && node.Text.Equals("Students Master"))
            {
                m_navModel.ConfirmNavigationRequest("ExampleModules.StudentView;" + null);
            }
            else if (node.Parent == null && node.Text.Equals("Subject Master"))
            {
                m_navModel.ConfirmNavigationRequest("ExampleModules.SubjectView;" + null);
            }
            else if (node.Parent != null && node.Parent.Text.Equals("Students Master"))
            {
                m_navModel.ConfirmNavigationRequest("ExampleModules.StudentView;" + node.Text);
            }
            else
            {
                m_navModel.ConfirmNavigationRequest("ExampleModules.SubjectView;" + node.Text);
            }
        }
    }
}
