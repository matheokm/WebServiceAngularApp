using AngularApp.Datos;
using AngularApp.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularApp.Negocio
{
    public class PersonaNegocio
    {
        public List<Persona> GetPersona()
        {
            try
            {
                var result = PersonaDato.GetPersonas();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ActualizarPersona(string accion ,Persona nuevaPersona)
        {
            try
            {
                var result = new PersonaDato().ActualizarPersona(accion,nuevaPersona);
                //return new PersonaDato().ActualizaPersona(accion, Persona);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
