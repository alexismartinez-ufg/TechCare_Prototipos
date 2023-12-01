using Microsoft.EntityFrameworkCore;
using Prototipos.BAL.Interfaces;
using Prototipos.BAL.Repositorios;
using Prototipos.DAL.Models;

namespace Prototipos.BAL.Repositorys
{
    public class ZonasRepository : BaseRepository<Zona>, IZonasRepository
    {
        private readonly PrototiposContext dbContext;
        public ZonasRepository(PrototiposContext _dbContext) : base(_dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<Zona> CreateZonafNotExist(Zona zona)
        {
            var zonaExist = await dbContext.Zonas.FirstOrDefaultAsync(z=>z.NombreZona == zona.NombreZona);

            if (zonaExist == null)
            {
                zonaExist = await AddAsync(zona);
            }

            return zonaExist;
        }
    }
}
