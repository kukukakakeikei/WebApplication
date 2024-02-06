using Contracts;
using Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Repositories
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(WebApplicationDbContext repositoryContext) : base(repositoryContext)
        {

        }

        public async Task<List<Player>> GetAllPlayer()
        {
            return await FindAll().OrderBy(player => player.DataCreated).ToListAsync();
        }

        public async Task<Player?> GetPlayerById(Guid playerId)
        {
            return await FindByCondtion(player => player.Id == playerId)
                .FirstOrDefaultAsync();
        }

        public async Task<Player?> GetPlayerWithCharacter(Guid playerId)
        {
            return await FindByCondtion(player => player.Id == playerId)
                .Include(player=>player.Characters)
                .FirstOrDefaultAsync();
        }
    }
}
