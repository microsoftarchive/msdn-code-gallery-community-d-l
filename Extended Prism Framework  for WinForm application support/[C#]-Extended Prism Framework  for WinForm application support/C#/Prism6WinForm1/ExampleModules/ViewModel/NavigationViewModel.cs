using DataModel;
using EventManager;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExampleModules
{
    public class NavigationViewModel
    {
        IEventAggregator m_eventAggregator;
        IRegionManager m_regionManager;


        private List<Student> m_studntList;
        private List<Subject> m_subjectList;

        public List<Student> StudentList
        {
            get { return m_studntList; }
            set { m_studntList = value; }
        }
        public List<Subject> SubjectList // user can try with bindable list
        {
            get { return m_subjectList; }
            set { m_subjectList = value; }
        }

        public NavigationViewModel(IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            m_eventAggregator = eventAggregator;
            m_regionManager = regionManager;
            m_studntList = new List<Student>();
            m_subjectList = new List<Subject>();
        }




        public void ConfirmNavigationRequest(string url)
        {
            IRegion _mainRegion = m_regionManager.Regions["MainRegion"];
            string[] param = url.Split(';');
            Uri uri = new Uri(param[0], UriKind.RelativeOrAbsolute);
            var student = StudentList.Where(p => p.Name.Equals(param[1])).FirstOrDefault();
            _mainRegion.Context = student;
            _mainRegion.RequestNavigate(uri);
        }



    }
}
