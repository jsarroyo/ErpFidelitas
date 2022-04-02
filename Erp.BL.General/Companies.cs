using System;
using System.Data.Entity;
using System.Linq;
using Erp.General.DataAccess.DataBase;

namespace Erp.BL.General
{
	
	
	public class Companies : IGeneralBase
	{ 
		Request request;
		readonly DB _db;
		public Companies() {
			request = new Request();
			_db = new DB();
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
				var Entidades = _db.dBEntities.Companies.Find();
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

			//using (var contexto = new LN_BDEntities())
			//{
			//	try
			//	{
			//		var datos = (from u in contexto.TUsuarios
			//					 select u).ToList();
			try
			{
				using (var Entidades = new ErpDBEntities())
				{
					var Entidad = Entidades.Companies.Find();
					if (Entidad == null)
					{
						_db.CloseConnection();
						return request.DoWarning();
					}
					_db.CloseConnection();
					return request.DoSuccess(Entidad);
				}



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
   
}