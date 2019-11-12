using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Student
    {
        private string m_regNo;

        public string RegisterNo
        {
            get { return m_regNo; }
            set { m_regNo = value; }
        }
        private string m_name;

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        private DateTime m_dob;

        public DateTime DateOfBirth
        {
            get { return m_dob; }
            set { m_dob = value; }
        }
    }

    public class Subject
    {
        private string m_name;

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        private int m_credits;

        public int NumberOfCredits
        {
            get { return m_credits; }
            set { m_credits = value; }
        }

        private int m_marks;

        public int TotalMarks
        {
            get { return m_marks; }
            set { m_marks = value; }
        }
        private int m_passMark;

        public int PassMark
        {
            get { return m_passMark; }
            set { m_passMark = value; }
        }

    }

}
