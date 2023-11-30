using Prototipos.BAL.Helpers;
using Prototipos.BAL.Interfaces;
using Prototipos.BAL.Repositorios;
using Prototipos.DAL.Models;

namespace Prototipos.BAL.Repositorys
{
    public class MesasRepository : BaseRepository<Mesa>, IMesasRepository
    {
        private readonly PrototiposContext dbContext;
        
        public MesasRepository(PrototiposContext _dbContext) : base(_dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<List<Mesa>> GetMesasDisponibles()
        {
            return dbContext.Mesas
                .Where(m => !dbContext.Reservas.Any(r => r.IdMesa == m.Id && r.EstadoReserva == ReservasStateReference.Reservada))
                .ToList();
        }
    }
}
