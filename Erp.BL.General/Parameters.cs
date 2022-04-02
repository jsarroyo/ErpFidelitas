using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.BL.General
{
	public class Parameters
	{
		Request request;
		readonly DB _db;
		public Parameters()
		{
			request = new Request();
			_db = new DB();
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
}
