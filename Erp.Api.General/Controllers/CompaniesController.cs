using Erp.BL.General; 
using System.Web.Http; 

namespace Erp.General.Api.Controllers
{
    public class CompaniesController : ApiController
    {
        Companies myCompany;
        [HttpGet]
        [Route("api//ObtenerUsuarios")]
        public Request ObtenerUno(string id)
        {
            myCompany = new Companies();
            return myCompany.GetById(id);
        }
    }
}