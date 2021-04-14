using AngularApp.Entidad;
using AngularApp.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularApp.Negocio
{
    public class GeneroNegocio
    {
        public List<Genero> ConsultaGenero()
        {
            try
            {
                var result = GeneroDatos.ConsultaGenero();
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Solverix", $"Flujos - Genero ==> ERROR: {ex.Message} - STACKTRACE: {ex.StackTrace} - INNEREXCEPTION: {ex.InnerException}", System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
        }
    }
}
