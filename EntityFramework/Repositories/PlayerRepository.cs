using Contracts;
using Entites;
using Entites.ReponseType;
using EntityFramework.Repositories.Extensions;
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

        public void CreatePlayer(Player player)
        {
            Create(player);
        }

        public async Task<PagedList<Player>> GetPlayer(PlayerParameter parameter)
        {
            return FindByCondtion(player => player.DataCreated.Date >= parameter.MinDataCreated.Date &&
                                            player.DataCreated.Date <= parameter.MaxDataCreated.Date)
                .SearchByAccount(parameter.Account)
                .OrderByQuery(parameter.OrderBy)
                //.OrderBy(player => player.DataCreated)
                //.Skip((parameter.PageNumber - 1) * parameter.PageNumber)
                //.Take(parameter.PageSize)
                //.ToListAsync();
                .ToPagedList(parameter.PageNumber, parameter.PageSize);
        }

        public async Task<Player?> GetPlayerById(Guid playerId)
        {
            return await FindByCondtion(player => player.Id == playerId)
                .FirstOrDefaultAsync();
        }

        public async Task<Player?> GetPlayerWithCharacter(Guid playerId)
        {
            return await FindByCondtion(player => player.Id == playerId)
                .Include(player => player.Characters)
                .FirstOrDefaultAsync();
        }
    }
}
