using Prototipos.DAL.Models;
using Prototipos.DAL.ViewModels;

namespace Prototipos.BAL.Interfaces
{
    public interface ICuentasRepository : IRepository<Cuenta>
    {
        Task<bool> CreateCuentaByViewModel(CrearCuentaViewModel model);
    }
}
