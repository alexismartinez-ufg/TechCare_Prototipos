using Prototipos.DAL.Models;

namespace Prototipos.BAL.Interfaces
{
    public interface IZonasRepository : IRepository<Zona>
    {
        Task<Zona> CreateZonafNotExist(Zona zona);
    }
}
