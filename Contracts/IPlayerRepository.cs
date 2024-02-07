using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entites.RequestFeatures;
using EntityFramework.Repositories;
using Entites.ReponseType;

namespace Contracts
{
    public interface IPlayerRepository:IBaseRepository<Player> //针对当前实体特有的方法
    {
        Task<PagedList<Player>> GetPlayer(PlayerParameter parameter);
        Task<Player?> GetPlayerById(Guid playerId);
        Task<Player?> GetPlayerWithCharacter(Guid playerId);

        //void CreatePlayer(Player player);
    }
}
