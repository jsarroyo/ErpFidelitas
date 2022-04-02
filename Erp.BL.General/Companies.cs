using System;
using System.Data.Entity;
using System.Linq;
using Erp.General.DataAccess.DataBase;

namespace Erp.BL.General
{
	public interface GeneralBase
	{
		Request Insert(Erp.General.DataAccess.DataBase.Companies insertar);
		Request GetAll();
		Request GetById(string id);
		Request GetByCondition();
		Request UpdateById(Erp.General.DataAccess.DataBase.Companies actualizar);
		Request Delete(string id);
		Request Validations(Erp.General.DataAccess.DataBase.Companies insertar);

	}
	//
	public class Companies : GeneralBase
	{
		Request request;
		readonly DB _db;
		public Companies() {
			request = new Request();
		}

		public Request Delete(string id)
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
				_db.dBEntities.Companies.Remove(Entidad);
				_db.Commit();
				_db.CloseConnection();
				return request.DoSuccess();

			}
			catch (Exception ex)
			{
				_db.CloseConnection();
				return request.DoError(ex.Message);
			}
		}

		public Request GetAll()
		{
			throw new NotImplementedException();
		}

		public Request GetByCondition()
		{
			try
			{
				_db.OpenConnection();
				var Entidad = (from u in _db.dBEntities.Companies.ToList()
							   select u
							   ).ToList();
				;
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

		public Request Insert(Erp.General.DataAccess.DataBase.Companies insertar)
		{
			request = Validations(insertar);
			if (request.Warning || request.Error)
			{
				return request;
			}
			try
			{
				_db.OpenConnection();
				var Entidad = _db.dBEntities.Companies.Find(insertar.CompanyId);
				;
				if (Entidad == null)
				{
					_db.dBEntities.Companies.Add(insertar);
					_db.Commit();
					_db.CloseConnection();
					return request.DoSuccess();
				}
				return request.DoWarning();
			}
			catch (Exception ex)
			{
				_db.CloseConnection();
				return request.DoError(ex.Message);
			}
		}

		public Request UpdateById(Erp.General.DataAccess.DataBase.Companies actualizar)
		{
			request = Validations(actualizar);
			if (request.Warning || request.Error) {
				return request;
			}
			try
			{
				_db.OpenConnection();
				var Entidad = _db.dBEntities.Companies.Find(actualizar.CompanyId);
				if (Entidad == null)
				{
					_db.CloseConnection();
					return request.DoWarning();
				}
				Entidad.Name = actualizar.Name;
				Entidad.Mision = actualizar.Mision;
				Entidad.Vision = actualizar.Vision;
				Entidad.PrincipalEmail = actualizar.PrincipalEmail;
				Entidad.Active = actualizar.Active;
				
				_db.Commit();
				_db.CloseConnection();
				return request.DoSuccess();
			}
			catch (Exception ex)
			{
				_db.CloseConnection();
				return request.DoError(ex.Message);
			}
		}
		public Request Validations(Erp.General.DataAccess.DataBase.Companies validar)
		{
			if (string.IsNullOrEmpty(validar.Name)) 
			{
				request.Details = "El nombre de la compañia no puede estar vacío";
				return request.DoWarning();
			}
			return request.DoSuccess();
		}
	}
	public class Currencys : GeneralBase
	{
		Request request;
		readonly DB _db;
		public Currencys()
		{
			request = new Request();
		}
		public Request Delete(string id)
		{
			try
			{
				_db.OpenConnection();
				var Entidad = _db.dBEntities.Currencys.Find(id);
				if (Entidad == null)
				{
					_db.CloseConnection();
					return request.DoWarning();
				}
				_db.dBEntities.Currencys.Remove(Entidad);
				_db.Commit();
				_db.CloseConnection();
				return request.DoSuccess();

			}
			catch (Exception ex)
			{
				_db.CloseConnection();
				return request.DoError(ex.Message);
			}
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
			throw new NotImplementedException();
		}

		public Request Insert(Erp.General.DataAccess.DataBase.Companies insertar)
		{
			throw new NotImplementedException();
		}

		public Request UpdateById(Erp.General.DataAccess.DataBase.Companies actualizar)
		{
			throw new NotImplementedException();
		}

		public Request Validations(Erp.General.DataAccess.DataBase.Companies insertar)
		{
			throw new NotImplementedException();
		}
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