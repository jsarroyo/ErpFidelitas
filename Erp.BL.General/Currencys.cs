using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.BL.General
{
	public class Currencys
	{

		Request request;
		readonly DB _db;
		public Currencys()
		{
			request = new Request();
			_db = new DB();
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
}
