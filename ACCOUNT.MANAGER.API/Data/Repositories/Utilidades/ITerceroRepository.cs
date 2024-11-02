using ACCOUNT.MANAGER.API.Data.Models.Modules.Utilidades;
using ACCOUNT.MANAGER.API.Data.Models.ParametersEndPoints.Utilidades;
using ACCOUNT.MANAGER.API.Data.Models.ResponsesEndPoints;
using ACCOUNT.MANAGER.API.Utils;

namespace ACCOUNT.MANAGER.API.Data.Repositories.Utilidades
{
    public interface ITerceroRepository: IDataBaseManager
    {
        Task<IEnumerable<Tercero>> GetAllTercero(string KeyConnection);
        Task<Tercero> GetTerceroByCodigo(string codigo, string KeyConnection);
        Task<ResponseInsert> CreateTercero(TerceroInsert terceroInsert);
        Task<ResponseInsert> UpdateTercero(TerceroUpdate terceroUpdate);
    }
}
