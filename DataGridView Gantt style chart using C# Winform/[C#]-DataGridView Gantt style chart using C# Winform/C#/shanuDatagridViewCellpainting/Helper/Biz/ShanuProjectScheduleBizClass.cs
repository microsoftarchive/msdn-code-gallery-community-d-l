using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;


namespace shanuDatagridViewCellpainting.Helper.Biz
{
	class ShanuProjectScheduleBizClass : BizBase
	{
		public DataSet SelectList(SortedDictionary<string, string> sd)
		{
			try
			{
				return SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "usp_ProjectSchedule_Select", GetSdParameter(sd));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
