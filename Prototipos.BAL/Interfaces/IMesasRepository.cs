using Prototipos.DAL.Models;

namespace Prototipos.BAL.Interfaces
{
    public interface IMesasRepository : IRepository<Mesa>
    {
        Task<List<Mesa>> GetMesasDisponibles();
    }
}
