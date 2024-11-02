using ACCOUNT.MANAGER.API.Data.Models.Modules.Utilidades;
using ACCOUNT.MANAGER.API.Data.Models.ParametersEndPoints.Utilidades;
using ACCOUNT.MANAGER.API.Data.Models.ResponsesEndPoints;
using ACCOUNT.MANAGER.API.Utils.Implements;

namespace ACCOUNT.MANAGER.API.Data.Repositories.Utilidades.Implements
{
    public class TerceroRepository: DataBaseManager,ITerceroRepository
    {
        private readonly IConfiguration _configurationManager;
        public TerceroRepository(IConfiguration configurationManager)
        {
            this._configurationManager = configurationManager;
        }

        public Task<ResponseInsert> CreateTercero(TerceroInsert terceroInsert)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tercero>> GetAllTercero(string KeyConnection)
        {
            throw new NotImplementedException();
        }

        public Task<Tercero> GetTerceroByCodigo(string codigo, string KeyConnection)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseInsert> UpdateTercero(TerceroUpdate terceroUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
