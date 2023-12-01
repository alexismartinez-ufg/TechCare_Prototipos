using Microsoft.EntityFrameworkCore;
using Prototipos.BAL.Helpers;
using Prototipos.BAL.Interfaces;
using Prototipos.BAL.Repositorios;
using Prototipos.DAL.Models;
using Prototipos.DAL.ViewModels;

namespace Prototipos.BAL.Repositorys
{
    public class ReservasRepository : BaseRepository<Reserva>, IReservasRepository
    {
        private readonly PrototiposContext dbContext;
        public ReservasRepository(PrototiposContext _dbContext) : base(_dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<bool> DeleteReservasByMesaId(int idMesa)
        {
            var reservas = dbContext.Reservas.Where(x=>x.IdMesa == idMesa).ToList();
            var cuentas = dbContext.Cuentas.Where(x=>x.IdMesa == idMesa).ToList();

            dbContext.Reservas.RemoveRange(reservas);
            dbContext.Cuentas.RemoveRange(cuentas);

            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DoReserva(ReservaViewModel model)
        {
            var succes = false;

            var mesa = dbContext.Mesas.Include(x=>x.Zona).FirstOrDefault(m => m.Id == model.IdMesa);
            
            if (mesa != null && !dbContext.Reservas.Any(r=>r.IdMesa == mesa.Id && (r.EstadoReserva != ReservasStateReference.Reservada || r.FechaReserva.Value.AddHours(4) <= DateTime.Now)))
            {
                await AddAsync(new Reserva()
                {
                    Contacto = model.Contacto,
                    Correo = model.Correo,
                    EstadoReserva = ReservasStateReference.Reservada,
                    FechaReserva = model.FechaReserva,
                    IdMesa = mesa.Id,
                    PersonaACargo = model.PersonaACargo
                });

                model.MesaSeleccionada = mesa;

                succes = true;
            }

            return succes;
        }
    }
}
