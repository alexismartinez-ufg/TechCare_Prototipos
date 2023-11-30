using Prototipos.DAL.Models;
using Prototipos.DAL.ViewModels;

namespace Prototipos.BAL.Interfaces
{
    public interface IUsuariosRepository : IRepository<Usuario>
    {
        Task<Usuario> CreateUserIfNotExist(Usuario usuario);
        Usuario CanDoLogin(LoginViewModel login);
    }
}
