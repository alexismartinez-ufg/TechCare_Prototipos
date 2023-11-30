using Prototipos.DAL.Models;
using Prototipos.DAL.ViewModels;

namespace Prototipos.BAL.Interfaces
{
    public interface IReservasRepository : IRepository<Reserva>
    {
        Task<bool> DoReserva(ReservaViewModel model);
    }
}
