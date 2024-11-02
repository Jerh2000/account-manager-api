using ACCOUNT.MANAGER.API.Data.Repositories.Utilidades;
using ACCOUNT.MANAGER.API.Data.Repositories.Utilidades.Implements;

namespace ACCOUNT.MANAGER.API.Services.Implements
{
    public class UtilidadesServices:IUtilidadesServices
    {
        private readonly IConfiguration Configuration;

        public UtilidadesServices(IConfiguration Configuration)
        {
            this.Configuration = Configuration;

            Cliente = new ClienteRepository(Configuration);
            Tercero = new TerceroRepository(Configuration);
        }

        public ITerceroRepository Tercero { get; set; }
        public IClienteRepository Cliente { get; set; }
    }
}
