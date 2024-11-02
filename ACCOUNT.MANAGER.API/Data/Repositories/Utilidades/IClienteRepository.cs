using ACCOUNT.MANAGER.API.Data.Models;
using ACCOUNT.MANAGER.API.Data.Models.Modules.Utilidades;
using ACCOUNT.MANAGER.API.Data.Models.ParametersEndPoints.Utilidades;
using ACCOUNT.MANAGER.API.Data.Models.ResponsesEndPoints;
using ACCOUNT.MANAGER.API.Utils;

namespace ACCOUNT.MANAGER.API.Data.Repositories.Utilidades
{
    public interface IClienteRepository:IDataBaseManager
    {
        Task<IEnumerable<Cliente>> GetAllCliente(string KeyConnection);
        Task<Cliente> GetClienteByCodigo(string codigo, string KeyConnection);
        Task<ResponseInsert> CreateCliente(ClienteInsert clienteInsert);
        Task<ResponseInsert> UpdateCliente(ClienteUpdate clienteUpdate);
    }
}
