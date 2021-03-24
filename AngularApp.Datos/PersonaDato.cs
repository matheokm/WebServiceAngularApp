using AngularApp.Entidad;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularApp.Datos
{
    public class PersonaDato
    {
        // Utiliza la configuracion del web.config
        public static string connectionString
        {
            get { return ConfigurationManager.ConnectionStrings["Test"].ConnectionString; } 
        }

        //Consulta datos de la tabla/entidad Persona
        public static List<Persona> GetPersonas()
        {
            try
            {

                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    //db.Open();
                    //var result = db.Query<Persona>("SELECT  *  FROM Persona").ToList();
                    var result = db.Query<Persona>("[ConsultaPersona]",commandType: CommandType.StoredProcedure).ToList();
                    return result;
                }

            }
            catch (Exception ex)
            {
                //System.Diagnostics.EventLog.WriteEntry("TestApp", $" Persona ==> ERROR: {ex.Message} - STACKTRACE: {ex.StackTrace} - INNEREXCEPTION: {ex.InnerException}", System.Diagnostics.EventLogEntryType.Error);
                System.Diagnostics.EventLog.WriteEntry("MIPROYECTO", $" PERSONA  ==> ERROR: {ex.Message} - STACKTRACE: {ex.StackTrace} - INNEREXCEPTION: {ex.InnerException}", System.Diagnostics.EventLogEntryType.Error);
                throw;
            }

        }

        //Actualiza/Inserta/Elimina datos de la tabla/entidad Persona
        public int ActualizarPersona(string accion,Persona nuevaPersona)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    var parameters = new DynamicParameters();

                    parameters.Add("@IdPersona", nuevaPersona.IdPersona);
                    parameters.Add("@Identificacion", nuevaPersona.Identificacion);
                    parameters.Add("@Nombres", nuevaPersona.Nombres);
                    parameters.Add("@Edad", nuevaPersona.Edad);
                    parameters.Add("@accion", accion);
                    var result = db.Query<int>("[ActualizaPersona]", parameters, commandType: CommandType.StoredProcedure);
                    return 1;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("MIPROYECTO", $" PERSONA  ==> ERROR: {ex.Message} - STACKTRACE: {ex.StackTrace} - INNEREXCEPTION: {ex.InnerException}", System.Diagnostics.EventLogEntryType.Error);
                return 0;
            }
        }
    }
}
