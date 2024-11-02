using Microsoft.Data.SqlClient;
using System.Data;


namespace ACCOUNT.MANAGER.API.Utils
{
    public interface IDataBaseManager 
    {
        Task<int> ExecuteStoredProcedureNonQuery(SqlParameter[] parametros, string storedProcedure);

        /// <summary>
        /// Ejecuta una consulta con parámetros a base de datos sql.
        /// </summary>
        /// <param name="pTextoComando">Nombre de procedimiento almacenado o consulta sql.</param>
        /// <param name="pTabla">Nombre de la tabla resultado.</param>
        /// <param name="Type">Si es un procedimiento o texto.</param>
        /// <param name="QueryParameters">Parámetros sql.</param>
        /// <param name="Connection">Cadena de Conexión.</param>
        /// <returns>Un DataTable.</returns>
        Task<DataTable> ExecuteQueryDataTable(string pTextoComando, string pTabla, CommandType Type, SqlParameter[] QueryParameters, string KeyConection);
    }
}
