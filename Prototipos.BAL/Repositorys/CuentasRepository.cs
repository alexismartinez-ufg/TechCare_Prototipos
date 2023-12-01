using Prototipos.BAL.Helpers;
using Prototipos.BAL.Interfaces;
using Prototipos.BAL.Repositorios;
using Prototipos.DAL.Models;
using Prototipos.DAL.ViewModels;

namespace Prototipos.BAL.Repositorys
{
    public class CuentasRepository : BaseRepository<Cuenta>, ICuentasRepository
    {
        private readonly PrototiposContext dbContext;
        public CuentasRepository(PrototiposContext _dbContext) : base(_dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<bool> CreateCuentaByViewModel(CrearCuentaViewModel cuenta)
        {
           return await AddAsync(new Cuenta
           {
               CantidadPersonas = cuenta.CantidadPersonas,
               ComensalACargo = cuenta.PersonaACargo,
               EstadoCuenta = CuentasStateReferences.Asignada,
               FechaAsignacion = cuenta.FechaDeAsignacion,
               IdMesa = cuenta.Mesa.Id,
               IdMesero = cuenta.Mesero.Id
           }) != null;
        }
    }
}
