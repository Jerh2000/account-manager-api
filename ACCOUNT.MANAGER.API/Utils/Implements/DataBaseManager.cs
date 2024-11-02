using ACCOUNT.MANAGER.API.Data.Models.ParametersEndPoints.Utilidades;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ACCOUNT.MANAGER.API.Utils.Implements
{
    public class DataBaseManager: IDataBaseManager
    {
        private readonly IConfigurationManager _configurationManager;
        //public DataBaseManager(IConfigurationManager configurationManager) 
        //{ 
        //    this._configurationManager = configurationManager;
        //}

        public async Task<DataTable> ExecuteQueryDataTable(string pTextoComando, string pTabla, CommandType Type, SqlParameter[] QueryParameters, string KeyConection)
        {
            SqlConnection Connection = new SqlConnection(_configurationManager.GetConnectionString(KeyConection));

            SqlCommand QueryCommand = CreateCommand(pTextoComando, Type);
            QueryCommand.Connection = Connection;
            AddParameters(QueryParameters, QueryCommand);
            DataTable dtDatos = new DataTable();
            try
            {
                if (QueryCommand.Connection.State != ConnectionState.Open)
                    QueryCommand.Connection.Open();

                SqlDataAdapter? daAdapter = new SqlDataAdapter(QueryCommand);
                await Task.Run(() => daAdapter.Fill(dtDatos));
                daAdapter = null;
                return dtDatos;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                QueryCommand.Connection.Close();
            }
        }

        public Task<int> ExecuteStoredProcedureNonQuery(SqlParameter[] parametros, string storedProcedure)
        {
            throw new NotImplementedException();
        }

        #region Methods non public
        private SqlCommand CreateCommand(string pTextoComando, CommandType Type)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = pTextoComando;
            Command.CommandType = Type;
            Command.CommandTimeout = 180;
            return Command;
        }

        private void AddParameters(SqlParameter[] QueryParameters, SqlCommand QueryCommand)
        {
            if (QueryParameters != null)
            {
                foreach (SqlParameter parameter in QueryParameters)
                {
                    QueryCommand.Parameters.Add(parameter.ParameterName, parameter.SqlDbType).Value = parameter.Value;
                }
            }
        }

        #endregion
    }
}
