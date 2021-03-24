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
    public class PersonaController : ApiController
    {
        // GET: api/Persona
        [HttpGet]
        public OperationResult<List<Persona>> GetPersona()
        {

            try
            {
                var result = new PersonaNegocio().GetPersona();
                if (result.Count > 0)
                    return OperationResult<List<Persona>>.CreateSuccessResult(result);
                else
                    return OperationResult<List<Persona>>.CreateFailure();
            }
            catch (System.Exception ex)
            {
                return OperationResult<List<Persona>>.CreateFailure(ex);
            }
        }

        [HttpPost]
        public OperationResult<int> ActualizaPersona(string accion, Persona Persona)
        {
            try
            {
                var result = new PersonaNegocio().ActualizarPersona(accion, Persona);
                if (result == 1)
                {
                    return OperationResult<int>.CreateSuccessResult(result);
                }
                else
                {
                    return OperationResult<int>.CreateFailure("Ocurrió un error");
                }
            }
            catch (System.Exception ex)
            {
                return OperationResult<int>.CreateFailure(ex);
            }
        }

    }
}
