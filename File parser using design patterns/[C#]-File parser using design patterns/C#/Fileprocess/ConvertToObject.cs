using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fileprocess
{
    public class ConvertToObject
    {
        /// <summary>
        /// Converting the string of array into object. In order to avoid run time error the values are set to min value
        /// </summary>
        /// <param name="LineString"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static IEmployeeResult Getobject(string LineString, string separator)
        {
            string[] stringarray = LineString.Split(separator.ToCharArray());
            IEmployeeResult Emplyoee = new Employee()
            {
                Name = stringarray[0],
                DateOfBirth = Convert.ToDateTime((string.IsNullOrEmpty(stringarray[1]) ? DateTime.MinValue.ToString() : stringarray[1])),
                EmpNo = Convert.ToInt32((string.IsNullOrEmpty(stringarray[2])?int.MinValue.ToString():stringarray[2])),
                Sal = Convert.ToInt32((string.IsNullOrEmpty(stringarray[3])?int.MinValue.ToString():stringarray[3])),
            };

            return Emplyoee;
        }

        /// <summary>
        /// Converting datareader to object.In order to avoid run time error the values are set to min value
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static IEmployeeResult Getobject(OleDbDataReader reader)
        {
           
            IEmployeeResult Emplyoee = new Employee()
            {
                Name = Convert.ToString(reader[0] == DBNull.Value  ? "" : reader[0]),
                DateOfBirth = Convert.ToDateTime(reader[1] == DBNull.Value ? DateTime.MinValue   : reader[1]),
                EmpNo = Convert.ToInt32(reader[2] == DBNull.Value ? int.MinValue : reader[2]),
                Sal = Convert.ToInt32(reader[3] == DBNull.Value ? int.MinValue : reader[3]),
            };

            return Emplyoee;
        }
    }
}
