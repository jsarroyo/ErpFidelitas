using Erp.General.DataAccess.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.BL.General
{
	public class DB
	{
		DB() {
			OpenConnection();
		}
		public ErpDBEntities dBEntities;

		public void OpenConnection()
		{
			dBEntities = new ErpDBEntities();
		}
		public void CloseConnection()
		{
			dBEntities.Dispose();
		}
	}
}
