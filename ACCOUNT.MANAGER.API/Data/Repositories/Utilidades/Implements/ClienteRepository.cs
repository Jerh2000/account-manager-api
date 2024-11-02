using ACCOUNT.MANAGER.API.Data.Models.Modules.Utilidades;
using ACCOUNT.MANAGER.API.Data.Models.ParametersEndPoints.Utilidades;
using ACCOUNT.MANAGER.API.Data.Models.ResponsesEndPoints;
using ACCOUNT.MANAGER.API.Services.Implements;
using ACCOUNT.MANAGER.API.Utils.Implements;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data;
using ACCOUNT.MANAGER.API.Utils.Statics;

namespace ACCOUNT.MANAGER.API.Data.Repositories.Utilidades.Implements
{
    public class ClienteRepository : DataBaseManager, IClienteRepository
    {
        private readonly IConfiguration _configurationManager;
        public ClienteRepository(IConfiguration configurationManager) 
        {
            this._configurationManager = configurationManager;
        }

        public async Task<IEnumerable<Cliente>> GetAllCliente(string KeyConnection)
        {
            List<Cliente> clientes = new List<Cliente>();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operation", Value = "GetAll"},
            };

            var query = await ExecuteQueryDataTable("SP_Cliente", "datos", CommandType.StoredProcedure, parms.ToArray(), KeyConnection);

            clientes = Functions.ConvertToList<Cliente>(query);

            return clientes;
        }

        public async Task<Cliente> GetClienteByCodigo(string codigo, string KeyConnection)
        {
            Cliente clientes = new Cliente();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operation", Value = "GetAll"},
                new SqlParameter { ParameterName = "@Codigo", Value = codigo},
            };

            var query = await ExecuteQueryDataTable("SP_Cliente", "datos", CommandType.StoredProcedure, parms.ToArray(), KeyConnection);

            clientes = Functions.ConvertToEntity<Cliente>(query);

            return clientes;
        }

        public async Task<ResponseInsert> CreateCliente(ClienteInsert clienteInsert)
        {
            ResponseInsert responseInserts = new ResponseInsert();

            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@Operation", Value = "Insert"},
                new SqlParameter { ParameterName = "@Nit", Value = clienteInsert.Nit},
                new SqlParameter { ParameterName = "@DV", Value = clienteInsert.DV},
                new SqlParameter { ParameterName = "@TipoDocumento", Value = clienteInsert.TipoDocumento},
                new SqlParameter { ParameterName = "@TipoPersona", Value = clienteInsert.TipoPersona},
                new SqlParameter { ParameterName = "@Nombre", Value = clienteInsert.Nombre},
                new SqlParameter { ParameterName = "@PrimerNombre", Value = clienteInsert.PrimerNombre},
                new SqlParameter { ParameterName = "@SegundoNombre", Value = clienteInsert.SegundoNombre},
                new SqlParameter { ParameterName = "@PrimerApellido", Value = clienteInsert.PrimerApellido},
                new SqlParameter { ParameterName = "@SegundoApellido", Value = clienteInsert.SegundoApellido},
                new SqlParameter { ParameterName = "@Telefono", Value = clienteInsert.Telefono},
                new SqlParameter { ParameterName = "@Celular", Value = clienteInsert.Celular},
                new SqlParameter { ParameterName = "@Email", Value = clienteInsert.Email,},
                new SqlParameter { ParameterName = "@Barrio", Value = clienteInsert.Barrio},
                new SqlParameter { ParameterName = "@Direccion", Value = clienteInsert.Direccion},
                new SqlParameter { ParameterName = "@Usuario", Value = clienteInsert.Usuario},
            };

            var query = await ExecuteQueryDataTable("SP_Cliente", "datos", CommandType.StoredProcedure, parms.ToArray(), clienteInsert.Conexion);
            responseInserts = Functions.ConvertToEntity<ResponseInsert>(query);

            return responseInserts;
        }

        public Task<ResponseInsert> UpdateCliente(ClienteUpdate clienteUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
