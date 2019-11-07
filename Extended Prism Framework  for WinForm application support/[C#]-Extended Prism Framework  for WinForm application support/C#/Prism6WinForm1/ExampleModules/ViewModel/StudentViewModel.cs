using DataModel;
using EventManager;
using Prism.Events;
using Prism.Regions;
using Prism.Mvvm;
using System;

namespace ExampleModules
{
    public class StudentViewModel : BindableBase, IConfirmNavigationRequest
    {
        IEventAggregator m_eventAggregator;
        IRegionManager m_regionManager;
        private Student m_student;

        private string m_name;

        private bool m_addBtnVisible;
        private bool m_updateBtnVisible;
        public bool AddButtonVisible
        {
            get { return m_addBtnVisible; }
            set
            {
                m_addBtnVisible = value;
                UpdateButtonVisible = !value;
                NameEdit = !value;
                OnPropertyChanged(() => AddButtonVisible);
            }
        }

        private bool m_nameEdit;
        public bool NameEdit
        {
            get { return m_nameEdit; }
            set
            {
                m_nameEdit = value;
                OnPropertyChanged(() => NameEdit);
            }
        }
        public bool UpdateButtonVisible
        {
            get { return m_updateBtnVisible; }
            set
            {
                m_updateBtnVisible = value;
                OnPropertyChanged(() => UpdateButtonVisible);
            }
        }


        public string StudentName
        {
            get { return m_name; }
            set
            {
                m_name = value;
                OnPropertyChanged(() => StudentName);
            }
        }

        private string m_regNo;

        public string RegisterNo
        {
            get { return m_regNo; }
            set
            {
                m_regNo = value;
                OnPropertyChanged(() => RegisterNo);
            }
        }

        private DateTime? m_dob;

        public DateTime? DateOfBirth
        {
            get { return m_dob; }
            set
            {
                m_dob = value;
                OnPropertyChanged(() => DateOfBirth);
            }
        }

        public StudentViewModel(IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            m_eventAggregator = eventAggregator;
            m_regionManager = regionManager;
        }

        internal void ValidateAndAdd()
        {
            if (!string.IsNullOrEmpty(m_regNo) &&
                !string.IsNullOrEmpty(m_name))
            {
                m_student = new Student() { RegisterNo = m_regNo, Name = m_name, DateOfBirth = m_dob.Value };
                StudentName = String.Empty;
                RegisterNo = String.Empty;
                DateOfBirth = null;
                UpdateButtonVisible = false;
                m_eventAggregator.GetEvent<AddObjectEvent>().Publish(m_student);
            }

        }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            AssignStudentData();
        }

        private void AssignStudentData()
        {
            object value = m_regionManager.Regions["MainRegion"].Context;
            if (value != null)
            {
                Student _student = value as Student;
                StudentName = _student.Name;
                RegisterNo = _student.RegisterNo;
                DateOfBirth = _student.DateOfBirth;
                AddButtonVisible = false;
            }
            else
            {
                StudentName = String.Empty;
                RegisterNo = String.Empty;
                DateOfBirth = null;
                AddButtonVisible = true;
            }
        }
        internal void ValidateAndUpdate()
        {
            m_student = new Student() { RegisterNo = m_regNo, Name = m_name, DateOfBirth = m_dob.Value };
            StudentName = String.Empty;
            RegisterNo = String.Empty;
            DateOfBirth = null;
            UpdateButtonVisible = false;
            m_eventAggregator.GetEvent<AddObjectEvent>().Publish(m_student);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            //
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //Any addional params can be passed using navigationContext
            // for internal region navigation
            AssignStudentData();
        }
    }
}
