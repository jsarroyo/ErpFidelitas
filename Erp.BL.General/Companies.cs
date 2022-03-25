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
		public Request Validations()
		{
			throw new NotImplementedException();
		}
	}
    public class Currencys
    {

		Request request;
		readonly DB _db;
		public Currencys()
		{
			request = new Request();
		}

        public Request Insert(Erp.General.DataAccess.DataBase.Currencys insertar)
        {
			try
			{
				_db.OpenConnection();
				var Entidad = _db.dBEntities.Companies.Find(insertar.CurrencyId);
				
				if (Entidad == null)
				{
					_db.dBEntities.Currencys.Add(insertar);
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

        public Request GetAll()
        {
			try
			{
				_db.OpenConnection();
				var Entidades = _db.dBEntities.Currencys.ToList();

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

        public Request GetById(int id)
        {
			try
			{
				_db.OpenConnection();
				var Entidad = _db.dBEntities.Currencys.Where(c => c.CurrencyId == id).FirstOrDefault();
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

        public Request GetByCondition()
        {
			try
			{
				_db.OpenConnection();
				var Entidad = (from u in _db.dBEntities.Currencys.ToList()
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

        public Request UpdateById(Erp.General.DataAccess.DataBase.Currencys actualizar)
        {
			try
			{
				_db.OpenConnection();
				var Entidad = _db.dBEntities.Currencys.Where(c => c.CurrencyId == actualizar.CurrencyId).FirstOrDefault();
				if (Entidad == null)
				{
					_db.CloseConnection();
					return request.DoWarning();
				}
				Entidad.Name = actualizar.Name;
				Entidad.MovementsAccountsReceivable = actualizar.MovementsAccountsReceivable;
				Entidad.MovementsDebtsToPay = actualizar.MovementsDebtsToPay;
				Entidad.MovementsInventory = actualizar.MovementsInventory;
				Entidad.MovementsInventory1 = actualizar.MovementsInventory1;
				Entidad.Persons = actualizar.Persons;
				Entidad.Products = actualizar.Products;
				Entidad.Products1 = actualizar.Products1;

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

        public Request Delete(int id)
        {
			try
			{
				_db.OpenConnection();
				var Entidad = _db.dBEntities.Currencys.Where(c => c.CurrencyId == id).FirstOrDefault();
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

        public Request Validations()
        {
            throw new NotImplementedException();
        }
    }
    public class DocumentTypes
    {
		Request request;
		readonly DB _db;
		public DocumentTypes()
		{
			request = new Request();
		}

		public Request Delete(int id)
        {
			try
			{
				_db.OpenConnection();
				var Entidad = _db.dBEntities.DocumentTypes.Where(c => c.DocumentTypeId == id).FirstOrDefault();
				if (Entidad == null)
				{
					_db.CloseConnection();
					return request.DoWarning();
				}
				_db.dBEntities.DocumentTypes.Remove(Entidad);
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
				var Entidades = _db.dBEntities.DocumentTypes.ToList();

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
				var Entidad = (from u in _db.dBEntities.DocumentTypes.ToList()
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
				var Entidad = _db.dBEntities.DocumentTypes.Where(c => c.DocumentTypeId == id).FirstOrDefault();
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

        public Request Insert(Erp.General.DataAccess.DataBase.DocumentTypes insertar)
        {
			try
			{
				_db.OpenConnection();
				var Entidad = _db.dBEntities.DocumentTypes.Find(insertar.DocumentTypeId);

				if (Entidad == null)
				{
					_db.dBEntities.DocumentTypes.Add(insertar);
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

        public Request UpdateById(Erp.General.DataAccess.DataBase.DocumentTypes actualizar)
        {
			try
			{
				_db.OpenConnection();
				var Entidad = _db.dBEntities.DocumentTypes.Where(c => c.DocumentTypeId == actualizar.DocumentTypeId).FirstOrDefault();
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
    public class Parameters
    {
		Request request;
		readonly DB _db;
		public Parameters()
		{
			request = new Request();
		}
		public Request Delete(int id)
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
				_db.dBEntities.Parameters.Remove(Entidad);
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