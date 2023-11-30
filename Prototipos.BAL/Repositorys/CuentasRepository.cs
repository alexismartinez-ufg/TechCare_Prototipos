using Prototipos.BAL.Interfaces;
using Prototipos.BAL.Repositorios;
using Prototipos.DAL.Models;

namespace Prototipos.BAL.Repositorys
{
    public class CuentasRepository : BaseRepository<Cuenta>, ICuentasRepository
    {
        public CuentasRepository(PrototiposContext _dbContext) : base(_dbContext)
        {
        }
    }
}
