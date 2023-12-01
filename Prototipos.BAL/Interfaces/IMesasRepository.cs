using Prototipos.DAL.Models;
using Prototipos.DAL.ViewModels;

namespace Prototipos.BAL.Interfaces
{
    public interface IMesasRepository : IRepository<Mesa>
    {
        Task<List<Mesa>> GetMesasDisponibles();

        Task<List<ComedorViewModel>> GetComedor();
        Task<Reserva> GetReservaInfo(int IdMesa);

        Task<Mesa> CreateMesaIfNotExist(Mesa mesa);
    }
}
