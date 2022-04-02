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
		Request GetById(int id);
		Request GetByCondition();
		Request UpdateById(Erp.General.DataAccess.DataBase.Companies actualizar);
		Request Delete(int id);
		Request Validations();

	}
	//
	public class Companies : GeneralBase
	{
		Request request;
		readonly DB _db;
		public Companies() {
			request = new Request();
		}

		public Request Delete(int id )
		{
			try
			{
				_db.OpenConnection();
				var Entidad = _db.dBEntities.Companies.Where(c => c.CompanyId == id).FirstOrDefault();
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
			try
			{
				_db.OpenConnection();
				var Entidades = _db.dBEntities.Companies.ToList();
				if (Entidades == null)
                {
                    _db.CloseConnection();
                    return request.DoWarning();
                }
				return request.DoSuccess(Entidades);
			}
			catch (Exception ex)
			{
				_db.CloseConnection();
				return request.DoError(ex.Message);
			}
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

		public Request GetById(int id)
		{
			try
			{
				_db.OpenConnection();
				var Entidad = _db.dBEntities.Companies.Where(c => c.CompanyId == id).FirstOrDefault();
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
				if (Entidad == null)
				{
					_db.dBEntities.Companies.Add(insertar);
					_db.Commit();
					_db.CloseConnection();
					return request.DoSuccess();
				}
				_db.CloseConnection();
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
				var Entidad = _db.dBEntities.Companies.Where(c => c.CompanyId == actualizar.CompanyId).FirstOrDefault();
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

			}
			catch (Exception ex)
			{
				_db.CloseConnection();
				return request.DoError(ex.Message);
			}
		}

        public Request GetAll()
        {
			try
			{
				_db.OpenConnection();
				var Entidades = _db.dBEntities.Parameters.ToList();

				_db.CloseConnection();

				if (Entidades == null)
					return request.DoWarning();


				return request.DoSuccess(Entidades);
			}
			catch (Exception ex)
			{
				_db.CloseConnection();
				return request.DoError(ex.Message);
			}
		}

        public Request GetByCondition()
        {
			try
			{
				_db.OpenConnection();
				var Entidad = (from u in _db.dBEntities.Parameters.ToList()
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

        public Request GetById(int id)
        {
			try
			{
				_db.OpenConnection();
				var Entidad = _db.dBEntities.Parameters.Where(c => c.ParameterId == id).FirstOrDefault();
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

        public Request Insert(Erp.General.DataAccess.DataBase.Parameters insertar)
        {
			try
			{
				_db.OpenConnection();
				var Entidad = _db.dBEntities.Parameters.Find(insertar.ParameterId);

				if (Entidad == null)
				{
					_db.dBEntities.Parameters.Add(insertar);
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

        public Request UpdateById(Erp.General.DataAccess.DataBase.Parameters actualizar)
        {
			try
			{
				_db.OpenConnection();
				var Entidad = _db.dBEntities.Parameters.Where(c => c.ParameterId == actualizar.ParameterId).FirstOrDefault();
				if (Entidad == null)
				{
					_db.CloseConnection();
					return request.DoWarning();
				}
				Entidad = actualizar;

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

        public Request Validations()
        {
            throw new NotImplementedException();
        }
    }

    public class Persons
    {
		Request request;
		readonly DB _db;
		public Persons()
		{
			request = new Request();
		}
		public Request Delete(int id)
        {
			try
			{
				_db.OpenConnection();
				var Entidad = _db.dBEntities.Persons.Where(c => c.PersonId == id).FirstOrDefault();
				if (Entidad == null)
				{
					_db.CloseConnection();
					return request.DoWarning();
				}
				_db.dBEntities.Persons.Remove(Entidad);
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
			try
			{
				_db.OpenConnection();
				var Entidades = _db.dBEntities.Persons.ToList();

				_db.CloseConnection();

				if (Entidades == null)
					return request.DoWarning();


				return request.DoSuccess(Entidades);
			}
			catch (Exception ex)
			{
				_db.CloseConnection();
				return request.DoError(ex.Message);
			}
		}

        public Request GetByCondition()
        {
			try
			{
				_db.OpenConnection();
				var Entidad = (from u in _db.dBEntities.Persons.ToList()
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

        public Request GetById(int id)
        {
			try
			{
				_db.OpenConnection();
				var Entidad = _db.dBEntities.Persons.Where(c => c.PersonId == id).FirstOrDefault();
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

        public Request Insert(Erp.General.DataAccess.DataBase.Persons insertar)
        {
			try
			{
				_db.OpenConnection();
				var Entidad = _db.dBEntities.Persons.Find(insertar.PersonId);

				if (Entidad == null)
				{
					_db.dBEntities.Persons.Add(insertar);
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

        public Request UpdateById(Erp.General.DataAccess.DataBase.Persons actualizar)
        {
			try
			{
				_db.OpenConnection();
				var Entidad = _db.dBEntities.Persons.Where(c => c.PersonId == actualizar.PersonId).FirstOrDefault();
				if (Entidad == null)
				{
					_db.CloseConnection();
					return request.DoWarning();
				}
				Entidad = actualizar;

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

        public Request Validations()
        {
            throw new NotImplementedException();
        }
    }
    public class TipoCambio
	{
	}


}