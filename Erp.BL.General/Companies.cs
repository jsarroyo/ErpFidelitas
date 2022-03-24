using System;
using System.Data.Entity; 
using Erp.General.DataAccess.DataBase;

namespace Erp.BL.General
{
	public interface GeneralBase
	{
		Request Insert();
		Request GetAll();
		Request GetById(string id);
		Request GetByCondition();
		Request UpdateById(string id);
		Request Delete(string id);
		Request Validations();

	}
	
	public class Companies : GeneralBase
	{ 
		Request request;
		readonly DB _db;

		public Request Delete(string id )
		{
			request = new Request();
			//using (ErpDBEntities dBEntities = new ErpDBEntities())
			//{
			//	var EntidadBorrar = dBEntities.Companies.Find(id);
			//	if (EntidadBorrar == null) {
			//		request.Message = ERROR_MSG;
			//		return request;
			//	}
			//	dBEntities.Companies.Remove(EntidadBorrar);
			//}
			return request;
		}

		public Request GetAll()
		{
			throw new NotImplementedException();
		}

		public Request GetByCondition()
		{
			throw new NotImplementedException();
		}

		public Request GetById(string id)
		{
			try
			{
				_db.OpenConnection();
				var Entidad = _db.dBEntities.Companies.Find(id);
				if (Entidad == null)
				{
					_db.CloseConnection();
					return request.DoWarning();
				}
				_db.CloseConnection();
				return request.DoSuccess(Entidad);

			}
			catch (Exception ex)
			{
				_db.CloseConnection();
				return request.DoError(ex.Message);
			}
		}
		

		

		public Request Insert()
		{
			throw new NotImplementedException();
		}

		public Request UpdateById(string id)
		{
			throw new NotImplementedException();
		}
		public Request Validations()
		{
			throw new NotImplementedException();
		}
	}
	public class Currencys
	{
	}
	public class DocumentTypes
	{
	}
	public class Parameters
	{
	}

	public class Persons
	{
	}
	public class TipoCambio
	{
	}


}