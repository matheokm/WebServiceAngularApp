using AngularApp.Entidad;
using AngularApp.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServiceAngularApp.Helper;

namespace WebServiceAngularApp.Controllers
{
    public class GeneroController : ApiController
    {
        [HttpGet]
        public OperationResult<List<Genero>> ConsultaGenero()
        {
            try
            {
                var result = new GeneroNegocio().ConsultaGenero();
                if (result.Count() > 0)
                    return OperationResult<List<Genero>>.CreateSuccessResult(result);
                else
                    return OperationResult<List<Genero>>.CreateFailure();
            }
            catch (System.Exception ex)
            {
                return OperationResult<List<Genero>>.CreateFailure(ex);
            }
        }
    }
}
