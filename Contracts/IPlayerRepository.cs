using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPlayerRepository:IBaseRepository<Player> //针对当前实体特有的方法
    {
        Task<List<Player>> GetAllPlayer();
        Task<Player?> GetPlayerById(Guid playerId);
        Task<Player?> GetPlayerWithCharacter(Guid playerId);
    }
}
