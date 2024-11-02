using ACCOUNT.MANAGER.API.Data.Repositories.Utilidades;

namespace ACCOUNT.MANAGER.API.Services
{
    public interface IUtilidadesServices
    {
        public ITerceroRepository Tercero { get; set; }
        public IClienteRepository Cliente { get; set; }
    }
}
