using Microsoft.EntityFrameworkCore;
using Prototipos.BAL.Helpers;
using Prototipos.BAL.Interfaces;
using Prototipos.BAL.Repositorios;
using Prototipos.DAL.Models;
using Prototipos.DAL.ViewModels;

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

        public async Task<List<ComedorViewModel>> GetComedor()
        {
            var mesas = await dbContext.Mesas.Include(m => m.Zona).ToListAsync();

            var model = mesas.Select(m => new ComedorViewModel
            {
                Mesa = m,
                Cuenta = dbContext.Cuentas.Include(c => c.Mesa.Zona)
                    .FirstOrDefault(c => c.IdMesa == m.Id && c.EstadoCuenta == CuentasStateReferences.Asignada),
                Estado = GetMesaState(dbContext, m),
                Reserva = dbContext.Reservas.FirstOrDefault(r=>r.IdMesa == m.Id && r.EstadoReserva == ReservasStateReference.Reservada && DateTime.Now < r.FechaReserva.Value.AddMinutes(15))
            }).ToList();

            return model;
        }

        public async Task<Reserva> GetReservaInfo(int idMesa)
        {
            var mesa = await dbContext.Mesas.Include(m => m.Zona).FirstOrDefaultAsync(x => x.Id == idMesa);

            if (mesa != null)
            {
                return dbContext.Reservas.FirstOrDefault(r => r.IdMesa == mesa.Id && r.EstadoReserva == ReservasStateReference.Reservada && DateTime.Now < r.FechaReserva.Value.AddMinutes(15));
            }

            return null;
        }

        private static string GetMesaState(PrototiposContext dbContext, Mesa m)
        {
            if (dbContext.Cuentas.Any(c => c.IdMesa == m.Id && c.EstadoCuenta == CuentasStateReferences.Asignada))
                return MesaStateReferences.Asignada;

            if (dbContext.Reservas.Any(r => r.IdMesa == m.Id
                && r.FechaReserva.Value.AddHours(-3) <= DateTime.Now
                && r.EstadoReserva == ReservasStateReference.Reservada
                && DateTime.Now < r.FechaReserva.Value.AddMinutes(15)))
                return MesaStateReferences.Reservada;

            return MesaStateReferences.Libre;
        }

        public async Task<Mesa> CreateMesaIfNotExist(Mesa mesa)
        {
            var mesaExist = await dbContext.Mesas.FirstOrDefaultAsync(m => m.NombreMesa == mesa.NombreMesa && m.Personas == mesa.Personas && m.IdZona == mesa.IdZona);

            if(mesaExist == null)
            {
                mesaExist = await AddAsync(mesa);
            }

            return mesaExist;
        }
    }
}
