using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngularApp.Entidad;
using Dapper;

namespace AngularApp.Datos
{
    public class GeneroDatos
    {
        // Utiliza la configuracion del web.config
        public static string connectionString
        {
            get { return ConfigurationManager.ConnectionStrings["Test"].ConnectionString; }
        }

        public static List<Genero> ConsultaGenero()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    var result = db.Query<Genero>("[ConsultaGenero]",
                    commandType: CommandType.StoredProcedure).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("MIProyecto", $"Flujos - Genero ==> ERROR: {ex.Message} - STACKTRACE: {ex.StackTrace} - INNEREXCEPTION: {ex.InnerException}", System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
        }
    }
}
