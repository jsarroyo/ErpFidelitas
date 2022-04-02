using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.BL.General
{
	public interface IGeneralBase
	{
		Request Insert(Erp.General.DataAccess.DataBase.Companies insertar);
		Request GetAll();
		Request GetById(int id);
		Request GetByCondition();
		Request UpdateById(Erp.General.DataAccess.DataBase.Companies actualizar);
		Request Delete(int id);
		Request Validations();

	}
}
