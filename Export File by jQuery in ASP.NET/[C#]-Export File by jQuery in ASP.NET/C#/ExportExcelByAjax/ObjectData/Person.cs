﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExportExcelByAjax.ObjectData
{
	public class Person
	{
		public int PersonID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime Birthday { get; set; }
		public string BirthPlace { get; set; }
	}
}