using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.BL.General
{
	public class Persons
	{
		Request request;
		readonly DB _db;
		public Persons()
		{
			request = new Request();
			_db = new DB();
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
}
