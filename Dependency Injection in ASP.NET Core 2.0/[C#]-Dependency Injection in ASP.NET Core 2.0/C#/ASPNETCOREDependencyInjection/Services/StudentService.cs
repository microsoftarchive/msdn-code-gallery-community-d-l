using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCOREDependencyInjection.Data;

namespace ASPNETCOREDependencyInjection.Services
{
    public class StudentService:IStudentDetailService
    {
		 
		public IEnumerable<StudentDetails> GetAllStudentDetails()
		{
			return new List<StudentDetails>
		{
			new  StudentDetails {studentName = "Afreen", Subject1 = ".Net Programming",Subject2="Operating System",Subject3="Web Programming",Subject4="Networks",Subject5="C# & OOP",Grade="A"},
			new StudentDetails {studentName = "kather", Subject1 = ".Net Programming",Subject2="Operating System",Subject3="Web Programming",Subject4="Networks",Subject5="C# & OOP",Grade="A" },
			new StudentDetails {studentName = "Asha", Subject1 = ".Net Programming",Subject2="Operating System",Subject3="Web Programming",Subject4="Networks",Subject5="C# & OOP",Grade="A" },
			new  StudentDetails {studentName = "Afraz", Subject1 = ".Net Programming",Subject2="Operating System",Subject3="Web Programming",Subject4="Networks",Subject5="C# & OOP",Grade="B" },
			new  StudentDetails {studentName = "Shanu", Subject1 = ".Net Programming",Subject2="Operating System",Subject3="Web Programming",Subject4="Networks",Subject5="C# & OOP",Grade="C" }
			
		};
		}
	}
}
