using Microsoft.EntityFrameworkCore;
using Prototipos.BAL.Interfaces;
using Prototipos.BAL.Repositorios;
using Prototipos.DAL.Models;
using Prototipos.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipos.BAL.Repositorys
{
    public class UsuariosRepository : BaseRepository<Usuario>, IUsuariosRepository
    {
        protected readonly PrototiposContext dbContext;
        public UsuariosRepository(PrototiposContext _dbContext) : base(_dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<Usuario> CreateUserIfNotExist(Usuario usuario)
        {
            var usuarioExist = await dbContext.Usuarios.FirstOrDefaultAsync(u=>u.Username == usuario.Username || (u.Email == usuario.Email && u.Contraseña == usuario.Contraseña));

            if(usuarioExist == null)
                usuario = await AddAsync(usuario);

            return usuario;
        }

        public Usuario CanDoLogin(LoginViewModel login)
        {
            return dbContext.Usuarios.FirstOrDefault(x => (x.Username.ToLower() == login.UserName.ToLower() || x.Email.ToLower() == login.UserName.ToLower()) && x.Contraseña.ToLower() == login.Password.ToLower() && !string.IsNullOrEmpty(x.Role));
        }
    }
}
